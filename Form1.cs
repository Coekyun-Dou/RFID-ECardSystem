using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO.Ports;
using System.Windows.Forms;

namespace ECardSystem
{
    public partial class MainForm : Form
    {
        //数据缓冲长度
        public const int MaxLen = 1024;
        //单条数据长度
        public const int MaxDataLen = 100;
        //数据读写锁标志
        public bool bLock = false;
        //线程运行标志
        public bool bThread = true;
        //数据缓冲区
        public byte[] byteRecBuff = new byte[MaxLen];
        //数据读缓冲区
        public byte[] bytesData = new byte[MaxDataLen];
        //数据进出标志
        public int iDataIn = 0,iDataOut = 0;
        //当前选择的系统模式，扣费or充值
        public bool bCurrentMode = true;
        //是否为唤醒状态
        public bool bWakeUp = false;
        //当前状态
        public int iState = 0;
        //当前操作0：无操作	1：扣费	2：查询	3：充值
        public int iCurrentHandle = 0;
        //当前余额
        public int iCurrentRemain = 0;
        private void initComComboBox()
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            comboSerial.Items.Clear();
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    comboSerial.Items.Add(sValue);
                    comboSerial.SelectedIndex = 0;
                }
            }
        }
        //切换类型线程
        public void SwitchCOMThread(string strCOM)
        {
            Thread newthread = new Thread(new ParameterizedThreadStart(SwitchCOM));
            newthread.Start((object)strCOM);
        }

        //切换类型
        public void SwitchCOM(object obj)
        {
            string strCOM = (string)obj;
            try
            {
                mSerialPort.BaudRate = 115200;
                mSerialPort.PortName = strCOM;
                mSerialPort.Open();
            }
            catch (Exception ex)
            {
                showMsg("串口：" + ex.Message);
            }
            Thread.Sleep(100);
            byte[] bytes = new byte[7];
            bytes[0] = (byte)0xAA;
            bytes[1] = (byte)bytes.Length;
            bytes[2] = (byte)0x01;
            bytes[3] = (byte)0x00;
            bytes[4] = (byte)0x01;
            bytes[5] = (byte)0x05;
            setSummationVerify(bytes);
            serialSend(bytes);
            Thread.Sleep(100);
            try
            {
                if (mSerialPort.IsOpen)
                {
                    mSerialPort.Close();
                }
                mSerialPort.BaudRate = 115200;
                mSerialPort.PortName = strCOM;
                mSerialPort.Open();
            }
            catch (Exception ex)
            {
                showMsg("串口：" + ex.Message);
            }
        }

        public byte[] String2Bytes(string str)
        {
            byte[] BytesTemp = Encoding.Default.GetBytes(str);
            if (BytesTemp.Length % 2 == 1)
                return null;
            byte[] BytesReturn = new byte[BytesTemp.Length / 2];
            for (int i = 0; i < BytesReturn.Length; i++)
            {
                if ((('0' <= BytesTemp[i * 2] && BytesTemp[i * 2] <= '9')
                    || ('A' <= BytesTemp[i * 2] && BytesTemp[i * 2] <= 'F')
                    || ('a' <= BytesTemp[i * 2] && BytesTemp[i * 2] <= 'f'))
                    && (('0' <= BytesTemp[i * 2 + 1] && BytesTemp[i * 2 + 1] <= '9')
                    || ('A' <= BytesTemp[i * 2 + 1] && BytesTemp[i * 2 + 1] <= 'F')
                    || ('a' <= BytesTemp[i * 2 + 1] && BytesTemp[i * 2 + 1] <= 'f')))
                {
                    BytesReturn[i] = (byte)(ASCII2byte(BytesTemp[i * 2]) * 16);
                    BytesReturn[i] += ASCII2byte(BytesTemp[i * 2 + 1]);
                }
                else
                    return null;
            }
            return BytesReturn;
        }

        //打开串口
        private void openSerial()
        {
            try
            {
                SwitchCOMThread(comboSerial.Text); 
                btnSerialConnect.Enabled = false; 
                btnSerialDisconnect.Enabled = true;
                showMsg("串口：连接成功！");
            }
            catch (Exception ex)
            {
                showMsg("串口：" + ex.Message);
            }
        }
        //关闭串口
        private void closeSerial()
        {
            try
            {
                if (mSerialPort.IsOpen)
                {
                    mSerialPort.Close();
                }
                //清空缓冲区 iDataIn = 0;
                iDataOut = 0; 
                btnSerialConnect.Enabled = true; 
                btnSerialDisconnect.Enabled = false;
                showMsg("串口：断开连接！");
            }
            catch (Exception ex)
            {
                showMsg("串口：" + ex.Message);
            }
        }
        //串口数据发送
        private bool serialSend(byte[] msg)
        {
            if (mSerialPort.IsOpen)
            {
                try
                {
                    mSerialPort.Write(msg, 0, msg.Length); 
                    return true;
                }
                catch (Exception ex)
                {
                    showMsg("串口：" + ex.Message);
                    return false;
                }
            }
            else
            {
                showMsg("串口：请先建立连接！");
            }
            return false;
        }
        //串口数据接收
        private void serialReceive()
        {
            if (mSerialPort.IsOpen)
            {
                try
                {
                    int i = 0;
                    int iDataLen = mSerialPort.BytesToRead;
                    if (iDataLen > 50) iDataLen = 50;
                    //读取缓冲区的数据到数组
                    mSerialPort.Read(bytesData, 0, iDataLen);
                    if (bLock == false)
                    {
                        bLock = true;
                        if (iDataIn + iDataLen <= MaxLen)
                        {
                            for (i = 0; i < iDataLen; i++)
                            {
                                byteRecBuff[iDataIn + i] = bytesData[i];
                            }
                            iDataIn += iDataLen;
                        }
                        else if (iDataIn + iDataLen == MaxLen)
                        {
                            for (i = 0; i < iDataLen; i++)
                            {
                                byteRecBuff[iDataIn + i] = bytesData[i];
                            }
                            iDataIn = 0;
                        }
                        else
                        {
                            for (i = iDataIn; i < MaxLen; i++)
                            {
                                byteRecBuff[i] = bytesData[i - iDataIn];
                            }
                            for (i = 0; i < iDataLen - MaxLen + iDataIn; i++)
                            {
                                byteRecBuff[i] = bytesData[i + MaxLen - iDataIn];
                            }
                            iDataIn = iDataLen - MaxLen + iDataIn;
                        }
                        bLock = false;
                    }
                }
                catch (Exception ex)
                {
                    showMsg("串口：" + ex.Message);
                    bLock = false;
                }
            }
        }
        //接收数据线程
        private void serialThreadReceive()
        {
            while (bThread)
            {
                serialReceive(); 
                Thread.Sleep(50);
            }
        }
        //启动接收线程
        private void recvThreadStart()
        {
            Thread newthread = new Thread(new ThreadStart(serialThreadReceive));
            newthread.Start();
        }
        //关闭接收线程
        private void recvThreadStop()
        {
            bThread = false;
        }
        private void scanData()
        {
            if (bLock == false)
            {
                bLock = true;
                int iValidLen, iPacketLen;
                while (iDataIn != iDataOut)
                {
                    if (byteRecBuff[dataOutAdd(0)] == (byte)0x00 && byteRecBuff[dataOutAdd(1)] == (byte)0x00 && byteRecBuff[dataOutAdd(2)] == (byte)0xFF)//判断包头
                    {
                        if (byteRecBuff[dataOutAdd(3)] == (byte)0x00)
                        {
                            iDataOut = dataOutAdd(6);
                            bLock = false;
                            //包含有效数据长度
                            iValidLen = validReceiveLen();
                            if (iState == 0 && iValidLen < 8)
                            {
                                HF1356MReadUid();
                            }
                            return;
                        }
                        else
                        {
                            //包含有效数据长度
                            iValidLen = validReceiveLen();
                            if (iValidLen < 8)
                            {
                                bLock = false; 
                                return;
                            }
                            iPacketLen = byteRecBuff[dataOutAdd(3)] + 7;
                            if (iValidLen < iPacketLen)
                            {
                                bLock = false;
                                return;
                            }
                            // 判断数据包是否完整
                            if (iPacketLen > 7 && iPacketLen < 40)
                            {
                                //读出一个数据包
                                byte[] Packet = new byte[iPacketLen];
                                for (int i = 0; i < iPacketLen; i++)
                                {
                                    Packet[i] = byteRecBuff[dataOutAdd(i)];
                                }
                                handleData(Packet);
                                iDataOut = dataOutAdd(iPacketLen); bLock = false;
                                return;
                            }
                        }
                    }
                    iDataOut = dataOutAdd(1);
                }
                bLock = false;
            }
        }
        //返回数据缓冲区内的有效数据长度
        private int validReceiveLen()
        {
            if (iDataOut < iDataIn)
            {
                return (iDataIn - iDataOut);
            }
            else if (iDataOut > iDataIn)
            {
                return (MaxLen - iDataOut + iDataIn);
            }
            return 0;
        }
        //返回后面第 iNum 有效数据的位置
        private int dataOutAdd(int iNum)
        {
            int ret = 0;
            if (iDataOut + iNum < MaxLen)
            {
                ret = iDataOut + iNum;
            }
            else if (iDataOut + iNum > MaxLen)
            {
                ret = iDataOut + iNum - MaxLen;
            }
            return ret;
        }
        private void handleData(byte[] Packet)
        {
            //判断校验位
            if (CheckHF1356MVerify(Packet))
            {
                int iDatalen = Packet[3];
                if (iDatalen > 0)
                {
                    byte bCommand = Packet[6]; 
                    byte bPD1 = Packet[7];
                    if (bCommand == (byte)0x15)
                    {
                        if (bPD1 == (byte)0x16)
                        {
                            bWakeUp = true;
                            showMsg("提示：模块唤醒成功");
                            if (radioPay.Checked)
                            {
                                groupPay.Enabled = true;
                            }
                            else if (radioCharge.Checked)
                            {
                                groupCharge.Enabled = true;
                            }
                        }
                    }
                    else if (bCommand == (byte)0x41)
                    {
                        if (iState == 1)//验证密码 A
                        {
                            if (iCurrentHandle == 1)
                            {
                                if (bPD1 == (byte)0x00)
                                {
                                    labelPay.Text = "密码验证成功";
                                    iState = 2;
                                    HF1356MReadData(4);
                                }
                                else
                                {
                                    labelPay.Text = "密码验证失败";
                                }
                            }
                            else if (iCurrentHandle == 2 || iCurrentHandle == 3)
                            {
                                if (bPD1 == (byte)0x00)
                                {
                                    labelCharge.Text = "密码验证成功"; 
                                    iState = 2;
                                    HF1356MReadData(4);
                                }
                                else
                                {
                                    labelCharge.Text = "密码验证失败";
                                }
                            }
                        }
                        else if (iState == 2)
                        {
                            if (bPD1 == (byte)0x00)
                            {
                                string strData = "";
                                for (int i = 0; i < 16; i++)
                                {
                                    strData += String.Format("{0:X2}", Packet[i + 8]);
                                }
                                int iRemain = Convert.ToInt32(strData, 16); 
                                if (iRemain >= 65535)
                                    iRemain = 0;
                                if (iCurrentHandle == 1)
                                {
                                    labelPay.Text = "读取余额成功";
                                    iState = 3;
                                    if (radio08.Checked)
                                    {
                                        iRemain -= 8;
                                    }
                                    else if (radio16.Checked)
                                    {
                                        iRemain -= 16;
                                    }
                                    else if (radio24.Checked)
                                    {
                                        iRemain -= 24;
                                    }
                                    else if (radioOther.Checked)
                                    {
                                        try
                                        {
                                            double dDecrease = double.Parse(textOther.Text) * 10;
                                            iRemain -= (int)dDecrease;
                                        }
                                        catch(Exception e)
                                        {
                                            labelPay.Text = "请输入正确的金额";
                                            return;
                                        }
                                    }
                                    if(iRemain < 0)
                                    {
                                        labelPay.Text = "余额不足"; 
                                        return;
                                    }
                                    HF1356MWriteData(4, string.Format("{0:X32}", iRemain));
                                    iCurrentRemain = iRemain;
                                }
                                else if(iCurrentHandle == 2)
                                {
                                    if (iRemain != 0)
                                    {
                                        //为方便存储，存储的金额为实际金额的 10 倍
                                        double dRemain = (double)(iRemain / 10.0);
                                        labelCharge.Text = string.Format("当前卡片中余额为:{0:f1}元",dRemain);
                                           
                                    }
                                    else
                                    {
                                        labelCharge.Text = string.Format("当前卡片中余额为：0.0 元");
                                    }
                                }
                                else if (iCurrentHandle == 3)
                                {
                                    labelCharge.Text = "读取余额成功";
                                    iState = 3;
                                    if (radio20.Checked)
                                    {
                                        iRemain += 200;
                                    }
                                    else if (radio50.Checked)
                                    {
                                        iRemain += 500;
                                    }
                                    else if (radio100.Checked)
                                    {
                                        iRemain += 1000;
                                    }
                                    //为方便存储，存储的金额为实际金额的 10 倍
                                    HF1356MWriteData(4, string.Format("{0:X32}", iRemain));
                                    iCurrentRemain = iRemain;

                                }
                            }
                            else
                            {
                                if (iCurrentHandle == 1)
                                {
                                    labelPay.Text = "读取余额失败";
                                }
                                else if (iCurrentHandle == 2 || iCurrentHandle == 3)
                                {
                                    labelCharge.Text = "读取余额失败";
                                }
                            }
                        }
                        else if (iState == 3)
                        {
                            if (iCurrentHandle == 1)
                            {
                                if (bPD1 == (byte)0x00)
                                {
                                    //为方便存储，存储的金额为实际金额的 10 倍
                                    double dRemain = (double)(iCurrentRemain / 10.0);
                                    labelPay.Text = string.Format("扣款成功，当前卡片中余额为：{0:f1}元", dRemain);
                                }
                                else
                                {
                                    labelPay.Text = "扣款失败";
                                }
                            }
                            else if(iCurrentHandle == 3)
                            {
                                if (bPD1 == (byte)0x00)
                                {
                                    //为方便存储，存储的金额为实际金额的 10 倍
                                    double dRemain = (double)(iCurrentRemain / 10.0); 
                                    labelCharge.Text = string.Format("充值成功，当前卡片中余额为：{0:f1}元", dRemain);

                                }
                                else
                                {
                                    labelCharge.Text = "充值失败";
                                }
                            }
                        }
                    }
                    else if (bCommand == (byte)0x4B)
                    {
                        if (bPD1 == (byte)0x01)
                        {
                            byte bUidlen = Packet[12];
                            string strUID = "";
                            for (int i = 0; i < bUidlen; i++)
                            {
                                strUID += String.Format("{0:X2}", Packet[i + 13]);
                            }
                            if(iCurrentHandle == 1)
                            {
                                labelPay.Text = String.Format("读取到标签{0:s}", strUID); 
                                iState = 1;
                                HF1356MCheckPwdA(4, strUID, "FFFFFFFFFFFF");
                            }
                            else if (iCurrentHandle == 2 || iCurrentHandle == 3)
                            {
                                labelCharge.Text = String.Format("读取到标签{0:s}", strUID); 
                                iState = 1;
                                HF1356MCheckPwdA(4, strUID, "FFFFFFFFFFFF");

                            }
                        }
                    }
                }
            }
        }
        public void StartWakeUpThread()
        {
            if (!bWakeUp)
            {
                showMsg("提示：正在唤醒模块，请稍后...");
                groupPay.Enabled = false; 
                groupCharge.Enabled = false;
                Thread newthread = new Thread(new ThreadStart(HF1356MWakeupDev)); 
                newthread.Start();

            }
        }
        //唤醒模块
        public void HF1356MWakeupDev()
        {
            Thread.Sleep(500);
            byte[] Buff = new byte[24]; 
            Buff[0] = (byte)0x55;
            Buff[1] = (byte)0x55;
            for (int i = 0; i < 14; i++)
            {
                Buff[i + 2] = (byte)0x00;
            }
            Buff[16] = (byte)0xFF; 
            Buff[17] = (byte)0x03;
            Buff[18] = (byte)0xFD; 
            Buff[19] = (byte)0xD4; 
            Buff[20] = (byte)0x14; 
            Buff[21] = (byte)0x01; 
            Buff[22] = (byte)0x17; 
            Buff[23] = (byte)0x00;
            serialSend(Buff);
        }
        //读取标签UID
        public void HF1356MReadUid()
        {
            byte[] Buff = new byte[11]; 
            Buff[0] = (byte)0x00; 
            Buff[1] = (byte)0x00;
            Buff[2] = (byte)0xFF; 
            Buff[3] = (byte)0x04;
            Buff[4] = (byte)(~Buff[3] + 1);
            Buff[5] = (byte)0xD4;
            Buff[6] = (byte)0x4A; 
            Buff[7] = (byte)0x02; 
            Buff[8] = (byte)0x00;
            Buff[9] = (byte)SetHF1356MVerify(Buff); 
            Buff[10] = (byte)0x00;
            serialSend(Buff);
        }
        //校验密码A
        public void HF1356MCheckPwdA(int section, string uID, string pwd)
        {
            byte[] byteUID = String2Bytes(uID);
            byte[] bytePWD = String2Bytes(pwd);
            byte[] Buff = new byte[18 + byteUID.Length]; 
            Buff[0] = (byte)0x00;
            Buff[1] = (byte)0x00; 
            Buff[2] = (byte)0xFF;
            Buff[3] = (byte)(0x0B + byteUID.Length);
            Buff[4] = (byte)(~Buff[3] + 1);
            Buff[5] = (byte)0xD4; Buff[6] = (byte)0x40;
            Buff[7] = (byte)0x01; Buff[8] = (byte)0x60;
            Buff[9] = (byte)section; for (int i = 0; i < 6; i++)
            {
                Buff[i + 10] = (byte)bytePWD[i];
            }
            for (int i = 0; i < byteUID.Length; i++)
            {
                Buff[i + 16] = (byte)byteUID[i];
            }
            Buff[16 + byteUID.Length] = (byte)SetHF1356MVerify(Buff); 
            Buff[16 + byteUID.Length + 1] = (byte)0x00; 
            serialSend(Buff);
        }
        //校验密码B
        public void HF1356MCheckPwdB(int section, string uID, string pwd)
        {
            byte[] byteUID = String2Bytes(uID);
            byte[] bytePWD = String2Bytes(pwd);
            byte[] Buff = new byte[18 + byteUID.Length]; 
            Buff[0] = (byte)0x00;
            Buff[1] = (byte)0x00;
            Buff[2] = (byte)0xFF;
            Buff[3] = (byte)(0x0B + byteUID.Length); 
            Buff[4] = (byte)(~Buff[3] + 1);
            Buff[5] = (byte)0xD4; 
            Buff[6] = (byte)0x40;
            Buff[7] = (byte)0x01; 
            Buff[8] = (byte)0x61;
            Buff[9] = (byte)section;
            for (int i = 0; i < 6; i++)
            {
                Buff[i + 10] = (byte)bytePWD[i];
            }
            for (int i = 0; i < byteUID.Length; i++)
            {
                Buff[i + 16] = (byte)byteUID[i];
            }
            Buff[16 + byteUID.Length] = (byte)SetHF1356MVerify(Buff);
            Buff[16 + byteUID.Length + 1] = (byte)0x00; 
            serialSend(Buff);
        }
        //读数据
        public void HF1356MReadData(int section)
        {
            byte[] Buff = new byte[12];
            Buff[0] = (byte)0x00;
            Buff[1] = (byte)0x00;
            Buff[2] = (byte)0xFF;
            Buff[3] = (byte)0x05;
            Buff[4] = (byte)(~Buff[3] + 1); 
            Buff[5] = (byte)0xD4;
            Buff[6] = (byte)0x40;
            Buff[7] = (byte)0x01; 
            Buff[8] = (byte)0x30; 
            Buff[9] = (byte)section;
            Buff[10] = (byte)SetHF1356MVerify(Buff); 
            Buff[11] = (byte)0x00;
            serialSend(Buff);

        }
        //写数据
        public void HF1356MWriteData(int section, string data)
        {
            byte[] byteData = String2Bytes(data);
            byte[] Buff = new byte[28];
            Buff[0] = (byte)0x00; Buff[1] = (byte)0x00; 
            Buff[2] = (byte)0xFF; Buff[3] = (byte)0x15;
            Buff[4] = (byte)(~Buff[3] + 1); Buff[5] = (byte)0xD4;
            Buff[6] = (byte)0x40; 
            Buff[7] = (byte)0x01;
            Buff[8] = (byte)0xA0; 
            Buff[9] = (byte)section; 
            for (int i = 0; i < 16; i++)
            {
                Buff[i + 10] = byteData[i];
            }
            Buff[26] = (byte)SetHF1356MVerify(Buff); 
            Buff[27] = (byte)0x00;
            serialSend(Buff);
        }
        //校验13.56M
        private bool CheckHF1356MVerify(byte[] bytes)
        {
            int iDatalen = bytes[3];
            byte b = 0x00;
            for (int i = 0; i < iDatalen; i++)
            {
                b += bytes[i + 5];
            }
            if ((byte)(bytes[bytes.Length - 2] + b) == 0x00)
            {
                return true;
            }
            return false;
        }
        //设置13.56M检验值
        private byte SetHF1356MVerify(byte[] bytes)
        {
            int iDatalen = bytes[3]; 
            byte bRet, b = 0x00;
            for (int i = 0; i < iDatalen; i++)
            {
                b += bytes[i + 5];
            }
            bRet = (byte)(~b + 1);
            return bRet;
        }
        //信息栏信息显示
        private void showMsg(string strMsg)
        {
            mInfo.Text = strMsg;
        }
        //显示字符数组
        private void showBytesMsg(byte[] msg)
        {
            string strTemp = "";
            for (int i = 0; i < msg.Length; i++)
            {
                strTemp += string.Format("{0:X2} ", msg[i]);
            }
            showMsg(strTemp);
        }
        //设置校验值
        private void setSummationVerify(byte[] bytes)
        {
            byte b = 0x00;
            for (int i = 0; i < bytes.Length - 1; i++)
            {
                b += bytes[i];
            }
            bytes[bytes.Length - 1] = b;
        }
        //ASCII转化为16进制字符
        public byte ASCII2byte(byte src)
        {
            byte ret = 0;
            if ('0' <= src && src <= '9')
            {
                ret = (byte)(src - '0');
            }
            else if ('A' <= src && src <= 'F')
            {
                ret = (byte)(src - 'A' + 10);
            }
            return ret;
        }

        public MainForm()
                    {
                        InitializeComponent();
                    }

                    private void MainForm_Load(object sender, EventArgs e)
                    {
                        initComComboBox();
                        mTimer.Start();
                        recvThreadStart();

                    }
                    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
                    {
                        recvThreadStop();
                        closeSerial();
                        mTimer.Stop();
                    }

                    private void btnSerialRefresh_Click(object sender, EventArgs e)
                    {
                        closeSerial();
                        initComComboBox();
                    }

                    private void btnSerialConnect_Click(object sender, EventArgs e)
                    {
                        openSerial();
                    }

                    private void btnSerialDisconnect_Click(object sender, EventArgs e)
                    {
                        closeSerial();
                    }

                    private void radioPay_CheckedChanged(object sender, EventArgs e)
                    {
                        if (bWakeUp)
                        {
                            bCurrentMode = true;
                            groupPay.Enabled = true;
                            groupCharge.Enabled = false;
                        }
                    }

                    private void radioCharge_CheckedChanged(object sender, EventArgs e)
                    {
                        if (bWakeUp)
                        {
                            bCurrentMode = false;
                            groupPay.Enabled = false;
                            groupCharge.Enabled = true;
                        }
                    }

                    private void radio08_CheckedChanged(object sender, EventArgs e)
                    {
                        textOther.Enabled = false;
                    }

                    private void radio16_CheckedChanged(object sender, EventArgs e)
                    {
                        textOther.Enabled = false;
                    }

                    private void radio24_CheckedChanged(object sender, EventArgs e)
                    {
                        textOther.Enabled = false;
                    }

                    private void radioOther_CheckedChanged(object sender, EventArgs e)
                    {
                        textOther.Enabled = true;
                    }

                    private void btnPaySubmit_Click(object sender, EventArgs e)
                    {
                        HF1356MReadUid();
                        iCurrentHandle = 1;
                        iState = 0;
                        showMsg("提示：完成费用支付操作前，请勿将卡片移开！");
                    }

                    private void btnChargeQuery_Click(object sender, EventArgs e)
                    {
                        HF1356MReadUid();
                        iCurrentHandle = 2;
                        iState = 0;
                        showMsg("提示：完成余额查询操作前，请勿将卡片移开！");
                    }

                    private void btnChargeSubmit_Click(object sender, EventArgs e)
                    {
                        HF1356MReadUid();
                        iCurrentHandle = 3;
                        iState = 0;
                        showMsg("提示：完成充值操作前，请勿将卡片移开！");
                    }

                    private void mTimer_Tick(object sender, EventArgs e)
                    {
                        scanData();
                    }
                }
}

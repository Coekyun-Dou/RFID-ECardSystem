## RFID综合实训项目 | 基于 13.56M TypeA 标签卡的一卡通管理系统

> *`From Felix Du`*

<h1 align="center">Hi 👋, I'm Felix Du</h1>
<h3 align="center">唯有文字能担此任，宣告生命曾经在场</h3>

------

<a href="https://github.com/Coekyun-Dou">
<img align="right" src="https://github-readme-stats.vercel.app/api?username=Coekyun-Dou&show_icons=true">
</a>

- 🔭 I’m currently major in <strong>Internet of Things Engineering</strong>
- 🌱 I’m currently learning <strong>Machine Learning and Deep Learning</strong>
- 💬 My hobbies <strong>🏀 basketball 📔 reading 🎞️ watching movie</strong>
- 📫 How to reach me <strong>less_duuuzx@163.com</strong>


<h3 align="left">Languages and Tools:</h3>
<p align="left">  <a href="https://www.w3schools.com/cpp/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/cplusplus/cplusplus-original.svg" alt="cplusplus" width="40" height="40"/> </a> <a href="https://git-scm.com/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> </a> <a href="https://www.linux.org/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/linux/linux-original.svg" alt="linux" width="40" height="40"/> </a> <a href="https://www.mathworks.com/" target="_blank" rel="noreferrer"> <img src="https://upload.wikimedia.org/wikipedia/commons/2/21/Matlab_Logo.png" alt="matlab" width="40" height="40"/> </a> <a href="https://www.mysql.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/mysql/mysql-original-wordmark.svg" alt="mysql" width="40" height="40"/> </a> <a href="https://nodejs.org" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/nodejs/nodejs-original-wordmark.svg" alt="nodejs" width="40" height="40"/> </a> <a href="https://opencv.org/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/opencv/opencv-icon.svg" alt="opencv" width="40" height="40"/> </a> <a href="https://pandas.pydata.org/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/2ae2a900d2f041da66e950e4d48052658d850630/icons/pandas/pandas-original.svg" alt="pandas" width="40" height="40"/> </a> <a href="https://www.python.org" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/python/python-original.svg" alt="python" width="40" height="40"/> </a> <a href="https://pytorch.org/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/pytorch/pytorch-icon.svg" alt="pytorch" width="40" height="40"/> </a> <a href="https://www.qt.io/" target="_blank" rel="noreferrer"> <img src="https://upload.wikimedia.org/wikipedia/commons/0/0b/Qt_logo_2016.svg" alt="qt" width="40" height="40"/> </a> <a href="https://www.tensorflow.org" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/tensorflow/tensorflow-icon.svg" alt="tensorflow" width="40" height="40"/> </a> </p>

------

### 【作者介绍】

> Felix Du：物联网工程本科大二在读（2025）
>
> - 研究方向与技术栈：
>   - 计算机视觉
>   - 多模态
>   - 前端开发(html、wxml、Vue...)
>   - 后端：MySql...

### 【实验目的】

1. 熟悉 Visual Studio 的使用
2. 熟练掌握 C#语言 WinForm 开发
3. 熟悉 13.56M TypeA 标签卡操作协议

### 【实验设备】

1. 硬件：13.56M 高频 RFID 模块、ISO14443 TypeA 标签卡，miniUSB 线，PC 电脑；

![image-20250531010430921](https://github.com/Coekyun-Dou/RFID-ECardSystem/blob/master/image/image-20250531010430921.png?raw=true)

![image-20250531010523286](https://raw.githubusercontent.com/Coekyun-Dou/RFID-ECardSystem/refs/heads/master/image/image-20250531010523286.png)



2. 软件： PC 机操作系统 Windows（XP、7、10) ＋ Visual Studio 2017 开发环境

### 【实验内容】

在Visual Studio 平台上使用C#语言Winform 开发基于 13.56M TypeA 标签卡的一卡通管理系统。

### 【页面展示】

![image-20250531010652126](https://github.com/Coekyun-Dou/RFID-ECardSystem/blob/master/image/image-20250531010652126.png?raw=true)

### 【运行效果】

1、将实验箱通电，使用 MiniUSB 线连接 PC 机和 13.56M 模块，同时将模块上的拨码开关拨到右边(USB)，这样才能保证模块和 PC 能够正常通讯

![image-20250605204232489](https://github.com/Coekyun-Dou/RFID-ECardSystem/blob/master/image/5-1.jpg?raw=true)

2、运行程序“EcardSystem.exe”，程序运行成功后主登录界面，此时暂时无法操作扣费系统也无法操作充值系统，如下图：

![image-5-2](https://github.com/Coekyun-Dou/RFID-ECardSystem/blob/master/image/5-2.jpg?raw=true)

3、软件中选择正确的串口号（在设备管理器当中查看 USB 转串口的串口号，如果未出现串口号，需要先安装 CP2102 USB 转串口驱动）并点击连接，此时程序会自动发送唤醒模块的指令，如果唤醒成功，扣费系统和充值系统就可以正常使用了；

![image-20250605204449021](https://github.com/Coekyun-Dou/RFID-ECardSystem/blob/master/image/5-3.jpg?raw=true)

![image-20250605204452851](https://github.com/Coekyun-Dou/RFID-ECardSystem/blob/master/image/5-4.jpg?raw=true)

4、将 13.56M TypeA 标签卡放在读卡器天线区域上，选择扣费金额，点击“确认扣费”，即可进行扣费操作，如果标签内余额不足时，会提示余额不足；

![image-20250605204552364](https://github.com/Coekyun-Dou/RFID-ECardSystem/blob/master/image/5-5.jpg?raw=true)

![image-20250605204556514](https://github.com/Coekyun-Dou/RFID-ECardSystem/blob/master/image/5-6.jpg?raw=true)

5、点击充值系统单选框，切换至充值系统，点击“查询余额”，可以查看到当前标签卡内余额情况；

![image-20250605204605610](https://github.com/Coekyun-Dou/RFID-ECardSystem/blob/master/image/5-7.jpg?raw=true)

6、选择充值金额，然后点击“确认充值”，即可向标签卡进行充值操作。

![image-20250605204618128](https://github.com/Coekyun-Dou/RFID-ECardSystem/blob/master/image/5-8.jpg?raw=true)
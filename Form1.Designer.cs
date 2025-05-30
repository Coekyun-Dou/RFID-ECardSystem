namespace ECardSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupSetting = new System.Windows.Forms.GroupBox();
            this.radioCharge = new System.Windows.Forms.RadioButton();
            this.radioPay = new System.Windows.Forms.RadioButton();
            this.btnSerialDisconnect = new System.Windows.Forms.Button();
            this.btnSerialConnect = new System.Windows.Forms.Button();
            this.comboSerial = new System.Windows.Forms.ComboBox();
            this.btnSerialRefresh = new System.Windows.Forms.Button();
            this.groupPay = new System.Windows.Forms.GroupBox();
            this.labelPay = new System.Windows.Forms.Label();
            this.radio08 = new System.Windows.Forms.RadioButton();
            this.radio16 = new System.Windows.Forms.RadioButton();
            this.radio24 = new System.Windows.Forms.RadioButton();
            this.radioOther = new System.Windows.Forms.RadioButton();
            this.textOther = new System.Windows.Forms.TextBox();
            this.btnPaySubmit = new System.Windows.Forms.Button();
            this.groupSetting.SuspendLayout();
            this.groupPay.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSetting
            // 
            this.groupSetting.Controls.Add(this.radioCharge);
            this.groupSetting.Controls.Add(this.radioPay);
            this.groupSetting.Controls.Add(this.btnSerialDisconnect);
            this.groupSetting.Controls.Add(this.btnSerialConnect);
            this.groupSetting.Controls.Add(this.comboSerial);
            this.groupSetting.Controls.Add(this.btnSerialRefresh);
            this.groupSetting.Location = new System.Drawing.Point(28, 29);
            this.groupSetting.Name = "groupSetting";
            this.groupSetting.Size = new System.Drawing.Size(700, 90);
            this.groupSetting.TabIndex = 0;
            this.groupSetting.TabStop = false;
            this.groupSetting.Text = "设置";
            // 
            // radioCharge
            // 
            this.radioCharge.AutoSize = true;
            this.radioCharge.Location = new System.Drawing.Point(589, 37);
            this.radioCharge.Name = "radioCharge";
            this.radioCharge.Size = new System.Drawing.Size(88, 19);
            this.radioCharge.TabIndex = 5;
            this.radioCharge.TabStop = true;
            this.radioCharge.Text = "充值系统\r\n";
            this.radioCharge.UseVisualStyleBackColor = true;
            this.radioCharge.CheckedChanged += new System.EventHandler(this.radioCharge_CheckedChanged);
            // 
            // radioPay
            // 
            this.radioPay.AutoSize = true;
            this.radioPay.Location = new System.Drawing.Point(495, 37);
            this.radioPay.Name = "radioPay";
            this.radioPay.Size = new System.Drawing.Size(88, 19);
            this.radioPay.TabIndex = 4;
            this.radioPay.TabStop = true;
            this.radioPay.Text = "扣费系统\r\n";
            this.radioPay.UseVisualStyleBackColor = true;
            this.radioPay.CheckedChanged += new System.EventHandler(this.radioPay_CheckedChanged);
            // 
            // btnSerialDisconnect
            // 
            this.btnSerialDisconnect.Location = new System.Drawing.Point(386, 28);
            this.btnSerialDisconnect.Name = "btnSerialDisconnect";
            this.btnSerialDisconnect.Size = new System.Drawing.Size(90, 30);
            this.btnSerialDisconnect.TabIndex = 3;
            this.btnSerialDisconnect.Text = "断开";
            this.btnSerialDisconnect.UseVisualStyleBackColor = true;
            this.btnSerialDisconnect.Click += new System.EventHandler(this.btnSerialDisconnect_Click);
            // 
            // btnSerialConnect
            // 
            this.btnSerialConnect.Location = new System.Drawing.Point(281, 28);
            this.btnSerialConnect.Name = "btnSerialConnect";
            this.btnSerialConnect.Size = new System.Drawing.Size(90, 30);
            this.btnSerialConnect.TabIndex = 2;
            this.btnSerialConnect.Text = "连接";
            this.btnSerialConnect.UseVisualStyleBackColor = true;
            this.btnSerialConnect.Click += new System.EventHandler(this.btnSerialConnect_Click);
            // 
            // comboSerial
            // 
            this.comboSerial.FormattingEnabled = true;
            this.comboSerial.Location = new System.Drawing.Point(146, 33);
            this.comboSerial.Name = "comboSerial";
            this.comboSerial.Size = new System.Drawing.Size(120, 23);
            this.comboSerial.TabIndex = 1;
            // 
            // btnSerialRefresh
            // 
            this.btnSerialRefresh.Location = new System.Drawing.Point(38, 28);
            this.btnSerialRefresh.Name = "btnSerialRefresh";
            this.btnSerialRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnSerialRefresh.TabIndex = 0;
            this.btnSerialRefresh.Text = "刷新串口";
            this.btnSerialRefresh.UseVisualStyleBackColor = true;
            this.btnSerialRefresh.Click += new System.EventHandler(this.btnSerialRefresh_Click);
            // 
            // groupPay
            // 
            this.groupPay.Controls.Add(this.btnPaySubmit);
            this.groupPay.Controls.Add(this.textOther);
            this.groupPay.Controls.Add(this.radioOther);
            this.groupPay.Controls.Add(this.radio24);
            this.groupPay.Controls.Add(this.radio16);
            this.groupPay.Controls.Add(this.radio08);
            this.groupPay.Controls.Add(this.labelPay);
            this.groupPay.Enabled = false;
            this.groupPay.Location = new System.Drawing.Point(29, 146);
            this.groupPay.Name = "groupPay";
            this.groupPay.Size = new System.Drawing.Size(328, 441);
            this.groupPay.TabIndex = 1;
            this.groupPay.TabStop = false;
            this.groupPay.Text = "扣费系统 ";
            // 
            // labelPay
            // 
            this.labelPay.AutoSize = true;
            this.labelPay.Font = new System.Drawing.Font("宋体", 13F);
            this.labelPay.Location = new System.Drawing.Point(108, 58);
            this.labelPay.Name = "labelPay";
            this.labelPay.Size = new System.Drawing.Size(109, 22);
            this.labelPay.TabIndex = 0;
            this.labelPay.Text = "信息提示 ";
            // 
            // radio08
            // 
            this.radio08.AutoSize = true;
            this.radio08.Location = new System.Drawing.Point(32, 175);
            this.radio08.Name = "radio08";
            this.radio08.Size = new System.Drawing.Size(67, 19);
            this.radio08.TabIndex = 1;
            this.radio08.TabStop = true;
            this.radio08.Text = "0.8元";
            this.radio08.UseVisualStyleBackColor = true;
            this.radio08.CheckedChanged += new System.EventHandler(this.radio08_CheckedChanged);
            // 
            // radio16
            // 
            this.radio16.AutoSize = true;
            this.radio16.Location = new System.Drawing.Point(129, 175);
            this.radio16.Name = "radio16";
            this.radio16.Size = new System.Drawing.Size(67, 19);
            this.radio16.TabIndex = 2;
            this.radio16.TabStop = true;
            this.radio16.Text = "1.6元";
            this.radio16.UseVisualStyleBackColor = true;
            this.radio16.CheckedChanged += new System.EventHandler(this.radio16_CheckedChanged);
            // 
            // radio24
            // 
            this.radio24.AutoSize = true;
            this.radio24.Location = new System.Drawing.Point(222, 175);
            this.radio24.Name = "radio24";
            this.radio24.Size = new System.Drawing.Size(67, 19);
            this.radio24.TabIndex = 3;
            this.radio24.TabStop = true;
            this.radio24.Text = "2.4元";
            this.radio24.UseVisualStyleBackColor = true;
            this.radio24.CheckedChanged += new System.EventHandler(this.radio24_CheckedChanged);
            // 
            // radioOther
            // 
            this.radioOther.AutoSize = true;
            this.radioOther.Location = new System.Drawing.Point(50, 238);
            this.radioOther.Name = "radioOther";
            this.radioOther.Size = new System.Drawing.Size(88, 19);
            this.radioOther.TabIndex = 4;
            this.radioOther.TabStop = true;
            this.radioOther.Text = "指定金额";
            this.radioOther.UseVisualStyleBackColor = true;
            this.radioOther.CheckedChanged += new System.EventHandler(this.radioOther_CheckedChanged);
            // 
            // textOther
            // 
            this.textOther.Location = new System.Drawing.Point(144, 237);
            this.textOther.Name = "textOther";
            this.textOther.Size = new System.Drawing.Size(111, 25);
            this.textOther.TabIndex = 5;
            // 
            // btnPaySubmit
            // 
            this.btnPaySubmit.Location = new System.Drawing.Point(112, 296);
            this.btnPaySubmit.Name = "btnPaySubmit";
            this.btnPaySubmit.Size = new System.Drawing.Size(84, 29);
            this.btnPaySubmit.TabIndex = 6;
            this.btnPaySubmit.Text = "确认扣费";
            this.btnPaySubmit.UseVisualStyleBackColor = true;
            this.btnPaySubmit.Click += new System.EventHandler(this.btnPaySubmit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 598);
            this.Controls.Add(this.groupPay);
            this.Controls.Add(this.groupSetting);
            this.Name = "MainForm";
            this.Text = "电子钱包系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupSetting.ResumeLayout(false);
            this.groupSetting.PerformLayout();
            this.groupPay.ResumeLayout(false);
            this.groupPay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSetting;
        private System.Windows.Forms.Button btnSerialRefresh;
        private System.Windows.Forms.ComboBox comboSerial;
        private System.Windows.Forms.Button btnSerialConnect;
        private System.Windows.Forms.Button btnSerialDisconnect;
        private System.Windows.Forms.RadioButton radioPay;
        private System.Windows.Forms.RadioButton radioCharge;
        private System.Windows.Forms.GroupBox groupPay;
        private System.Windows.Forms.RadioButton radio08;
        private System.Windows.Forms.Label labelPay;
        private System.Windows.Forms.RadioButton radio16;
        private System.Windows.Forms.RadioButton radio24;
        private System.Windows.Forms.RadioButton radioOther;
        private System.Windows.Forms.TextBox textOther;
        private System.Windows.Forms.Button btnPaySubmit;
    }
}


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
            this.btnSerialRefresh = new System.Windows.Forms.Button();
            this.comboSerial = new System.Windows.Forms.ComboBox();
            this.btnSerialConnect = new System.Windows.Forms.Button();
            this.btnSerialDisconnect = new System.Windows.Forms.Button();
            this.radioPay = new System.Windows.Forms.RadioButton();
            this.radioCharge = new System.Windows.Forms.RadioButton();
            this.groupSetting.SuspendLayout();
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
            // comboSerial
            // 
            this.comboSerial.FormattingEnabled = true;
            this.comboSerial.Location = new System.Drawing.Point(146, 33);
            this.comboSerial.Name = "comboSerial";
            this.comboSerial.Size = new System.Drawing.Size(120, 23);
            this.comboSerial.TabIndex = 1;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 535);
            this.Controls.Add(this.groupSetting);
            this.Name = "MainForm";
            this.Text = "电子钱包系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupSetting.ResumeLayout(false);
            this.groupSetting.PerformLayout();
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
    }
}


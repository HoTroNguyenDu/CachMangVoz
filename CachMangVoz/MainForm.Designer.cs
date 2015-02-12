// -----------------------------------------------------------------------
// <copyright file="Form1.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace CachMangVoz
{

    using System;
    using System.ComponentModel;

    partial class CachMangVoz
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StartButton = new System.Windows.Forms.Button();
            this.CaptchaPictureBox = new System.Windows.Forms.PictureBox();
            this.CaptchaTextBox = new System.Windows.Forms.TextBox();
            this.CaptchaButton = new System.Windows.Forms.Button();
            this.AccountTextBox = new System.Windows.Forms.TextBox();
            this.ConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BoxTextBox = new System.Windows.Forms.TextBox();
            this.SpamLabel = new System.Windows.Forms.Label();
            this.SpamTextBox = new System.Windows.Forms.TextBox();
            this.AccountLabel = new System.Windows.Forms.Label();
            this.CaptchaGroupBox = new System.Windows.Forms.GroupBox();
            this.ErrorLog = new System.Windows.Forms.TextBox();
            this.WorkingTimer = new System.Windows.Forms.Timer(this.components);
            this.TopicSpamButton = new System.Windows.Forms.Button();
            this.TopicIdTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).BeginInit();
            this.ConfigurationGroupBox.SuspendLayout();
            this.CaptchaGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(24, 281);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(303, 28);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Bắt đầu spam tất cả topic mới";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CaptchaPictureBox
            // 
            this.CaptchaPictureBox.Location = new System.Drawing.Point(12, 19);
            this.CaptchaPictureBox.Name = "CaptchaPictureBox";
            this.CaptchaPictureBox.Size = new System.Drawing.Size(201, 61);
            this.CaptchaPictureBox.TabIndex = 1;
            this.CaptchaPictureBox.TabStop = false;
            // 
            // CaptchaTextBox
            // 
            this.CaptchaTextBox.Location = new System.Drawing.Point(12, 103);
            this.CaptchaTextBox.Name = "CaptchaTextBox";
            this.CaptchaTextBox.Size = new System.Drawing.Size(282, 20);
            this.CaptchaTextBox.TabIndex = 2;
            // 
            // CaptchaButton
            // 
            this.CaptchaButton.Location = new System.Drawing.Point(12, 129);
            this.CaptchaButton.Name = "CaptchaButton";
            this.CaptchaButton.Size = new System.Drawing.Size(282, 23);
            this.CaptchaButton.TabIndex = 3;
            this.CaptchaButton.Text = "Gõ Captcha";
            this.CaptchaButton.UseVisualStyleBackColor = true;
            this.CaptchaButton.Click += new System.EventHandler(this.CaptchaButton_Click);
            // 
            // AccountTextBox
            // 
            this.AccountTextBox.Location = new System.Drawing.Point(9, 32);
            this.AccountTextBox.Multiline = true;
            this.AccountTextBox.Name = "AccountTextBox";
            this.AccountTextBox.Size = new System.Drawing.Size(294, 214);
            this.AccountTextBox.TabIndex = 4;
            this.AccountTextBox.Text = "HoTroNguyenDu\tPasswordCuaTuiMay";
            // 
            // ConfigurationGroupBox
            // 
            this.ConfigurationGroupBox.Controls.Add(this.label1);
            this.ConfigurationGroupBox.Controls.Add(this.BoxTextBox);
            this.ConfigurationGroupBox.Controls.Add(this.SpamLabel);
            this.ConfigurationGroupBox.Controls.Add(this.SpamTextBox);
            this.ConfigurationGroupBox.Controls.Add(this.AccountLabel);
            this.ConfigurationGroupBox.Controls.Add(this.AccountTextBox);
            this.ConfigurationGroupBox.Location = new System.Drawing.Point(24, 12);
            this.ConfigurationGroupBox.Name = "ConfigurationGroupBox";
            this.ConfigurationGroupBox.Size = new System.Drawing.Size(910, 263);
            this.ConfigurationGroupBox.TabIndex = 5;
            this.ConfigurationGroupBox.TabStop = false;
            this.ConfigurationGroupBox.Text = "Cấu hình";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(647, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Box Link";
            // 
            // BoxTextBox
            // 
            this.BoxTextBox.Location = new System.Drawing.Point(650, 32);
            this.BoxTextBox.Multiline = true;
            this.BoxTextBox.Name = "BoxTextBox";
            this.BoxTextBox.Size = new System.Drawing.Size(294, 214);
            this.BoxTextBox.TabIndex = 8;
            this.BoxTextBox.Text = "http://vozforums.com/forumdisplay.php?f=17\r\nhttp://vozforums.com/forumdisplay.php" +
    "?f=33";
            // 
            // SpamLabel
            // 
            this.SpamLabel.AutoSize = true;
            this.SpamLabel.Location = new System.Drawing.Point(325, 16);
            this.SpamLabel.Name = "SpamLabel";
            this.SpamLabel.Size = new System.Drawing.Size(58, 13);
            this.SpamLabel.TabIndex = 5;
            this.SpamLabel.Text = "Spam Text";
            // 
            // SpamTextBox
            // 
            this.SpamTextBox.Location = new System.Drawing.Point(328, 32);
            this.SpamTextBox.Multiline = true;
            this.SpamTextBox.Name = "SpamTextBox";
            this.SpamTextBox.Size = new System.Drawing.Size(294, 214);
            this.SpamTextBox.TabIndex = 6;
            this.SpamTextBox.Text = "Hóng chap mới. Hay là nồi thớt bị chửi nên trốn luôn rồi. Cuối cùng đây là review" +
    " hay chuyện hư cấu?";
            // 
            // AccountLabel
            // 
            this.AccountLabel.AutoSize = true;
            this.AccountLabel.Location = new System.Drawing.Point(6, 16);
            this.AccountLabel.Name = "AccountLabel";
            this.AccountLabel.Size = new System.Drawing.Size(101, 13);
            this.AccountLabel.TabIndex = 0;
            this.AccountLabel.Text = "Account/Password,";
            // 
            // CaptchaGroupBox
            // 
            this.CaptchaGroupBox.Controls.Add(this.CaptchaButton);
            this.CaptchaGroupBox.Controls.Add(this.CaptchaPictureBox);
            this.CaptchaGroupBox.Controls.Add(this.CaptchaTextBox);
            this.CaptchaGroupBox.Location = new System.Drawing.Point(352, 281);
            this.CaptchaGroupBox.Name = "CaptchaGroupBox";
            this.CaptchaGroupBox.Size = new System.Drawing.Size(306, 158);
            this.CaptchaGroupBox.TabIndex = 6;
            this.CaptchaGroupBox.TabStop = false;
            this.CaptchaGroupBox.Text = "Captcha";
            // 
            // ErrorLog
            // 
            this.ErrorLog.Enabled = false;
            this.ErrorLog.Location = new System.Drawing.Point(674, 281);
            this.ErrorLog.Multiline = true;
            this.ErrorLog.Name = "ErrorLog";
            this.ErrorLog.Size = new System.Drawing.Size(260, 181);
            this.ErrorLog.TabIndex = 7;
            // 
            // WorkingTimer
            // 
            this.WorkingTimer.Interval = 1000;
            this.WorkingTimer.Tick += new System.EventHandler(this.WorkingTimer_Tick);
            // 
            // TopicSpamButton
            // 
            this.TopicSpamButton.Location = new System.Drawing.Point(24, 333);
            this.TopicSpamButton.Name = "TopicSpamButton";
            this.TopicSpamButton.Size = new System.Drawing.Size(107, 28);
            this.TopicSpamButton.TabIndex = 8;
            this.TopicSpamButton.Text = "Spam topic";
            this.TopicSpamButton.UseVisualStyleBackColor = true;
            this.TopicSpamButton.Click += new System.EventHandler(this.TopicSpamButton_Click);
            // 
            // TopicIdTextBox
            // 
            this.TopicIdTextBox.Location = new System.Drawing.Point(137, 338);
            this.TopicIdTextBox.Name = "TopicIdTextBox";
            this.TopicIdTextBox.Size = new System.Drawing.Size(190, 20);
            this.TopicIdTextBox.TabIndex = 4;
            this.TopicIdTextBox.Text = "4089309";
            // 
            // CachMangVoz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 492);
            this.Controls.Add(this.TopicIdTextBox);
            this.Controls.Add(this.TopicSpamButton);
            this.Controls.Add(this.ErrorLog);
            this.Controls.Add(this.CaptchaGroupBox);
            this.Controls.Add(this.ConfigurationGroupBox);
            this.Controls.Add(this.StartButton);
            this.Name = "CachMangVoz";
            this.Text = "CachMangVoz";
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).EndInit();
            this.ConfigurationGroupBox.ResumeLayout(false);
            this.ConfigurationGroupBox.PerformLayout();
            this.CaptchaGroupBox.ResumeLayout(false);
            this.CaptchaGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PictureBox CaptchaPictureBox;
        private System.Windows.Forms.TextBox CaptchaTextBox;
        private System.Windows.Forms.Button CaptchaButton;
        private System.Windows.Forms.TextBox AccountTextBox;
        private System.Windows.Forms.GroupBox ConfigurationGroupBox;
        private System.Windows.Forms.Label SpamLabel;
        private System.Windows.Forms.TextBox SpamTextBox;
        private System.Windows.Forms.Label AccountLabel;
        private System.Windows.Forms.GroupBox CaptchaGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BoxTextBox;
        private System.Windows.Forms.TextBox ErrorLog;
        private System.Windows.Forms.Timer WorkingTimer;
        private System.Windows.Forms.Button TopicSpamButton;
        private System.Windows.Forms.TextBox TopicIdTextBox;
    }
}

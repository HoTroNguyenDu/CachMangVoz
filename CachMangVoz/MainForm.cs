// -----------------------------------------------------------------------
// <copyright file="Form1.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace CachMangVoz
{
    using Fizzler.Systems.HtmlAgilityPack;
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;
    using HtmlDocument = HtmlAgilityPack.HtmlDocument;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class CachMangVoz : Form
    {
        private List<string> _boxes = new List<string>();
        private List<VozAccount> _accounts;

        private VozHelper _vozHelper;

        private string _spamMode = "Topic";
        private int _secondCounter = 0;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public CachMangVoz()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ValidateUserInput();
            _spamMode = "All";
            WorkingTimer.Enabled = true;
        }

        private void CaptchaButton_Click(object sender, EventArgs e)
        {
            _vozHelper.PostReplyCallback(CaptchaTextBox.Text);
            SpamAllNewTopic();
        }

        private void TopicSpamButton_Click(object sender, EventArgs e)
        {
            ValidateUserInput();
            _spamMode = "Topic";
            WorkingTimer.Enabled = true;
        }

        private void WorkingTimer_Tick(object sender, EventArgs e)
        {
            ErrorLog.Text = string.Format("Chờ {0} giây để spam", _secondCounter);
            if (_secondCounter == 0)
            {
                Spam();
                _secondCounter = 60;
                ErrorLog.Text = string.Empty;
            }

            _secondCounter--;
        }

        private void Spam()
        {
            _vozHelper = new VozHelper(CaptchaPictureBox, SpamTextBox);

            var hasAccount = RandomUseAccount();
            if (!hasAccount)
            {
                MessageBox.Show("Account đã bị ban hết, đóng chương trình, nhập lại account mới");
                return;
            }

            if (_spamMode == "Topic")
            {
                SpamTopic();
            }
            else
            {
                SpamAllNewTopic();
            }
        }

        private void SpamAllNewTopic()
        {
            var threadIdList = _vozHelper.FindNewPost(_boxes);
            if (threadIdList.Count > 0)
            {
                var threadId = threadIdList[0];
                _vozHelper.PostReply(threadId);
                ErrorLog.Text += string.Format("Spam to topic {0}\r\n", threadId);
            }
        }

        private void SpamTopic()
        {
            var threadId = int.Parse(TopicIdTextBox.Text);
            _vozHelper.PostReply(threadId);
            ErrorLog.Text += string.Format("Spam to topic {0}\r\n",threadId);
        }

        private bool RandomUseAccount()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var randomIndex = random.Next(0, _accounts.Count - 1);

            var randomAccount = _accounts[randomIndex];

            while (_accounts.Count > 0)
            {
                var login = _vozHelper.Login(randomAccount);
                if (login)
                {
                    return true;
                }

                ErrorLog.Text += string.Format("Account {0} was banned.\r\n", randomAccount.Username);
                _accounts.Remove(randomAccount);
            }

            return false;
        }

        private void ValidateUserInput()
        {
            _boxes = BoxTextBox.Text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
            _accounts = AccountExtracter.ExtractAccount(AccountTextBox.Text);

            if (_accounts.Count == 0)
            {
                throw new Exception("Bà mẹ. Mỗi hàng là 1 cặp username=>tab=>password");
            }
        }


    }
}


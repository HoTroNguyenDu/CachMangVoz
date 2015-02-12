using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace CachMangVoz
{
    public class VozHelper
    {
        private const string LoginUrl = "http://vozforums.com/vbdev/login_api.php";
        private WebClientEx _client = new WebClientEx();
        private string _currentReplyLink;
        private string _securityToken;
        private PictureBox _captchaPictureBox;
        private TextBox _spamTextbox;

        public VozHelper(PictureBox captchaPictureBox, TextBox spamTextbox)
        {
            _captchaPictureBox = captchaPictureBox;
            _spamTextbox = spamTextbox;
        }

        #region Login

        public bool Login(VozAccount account)
        {
            var loginData = GetLoginData(account);

            _client = new WebClientEx();
            _client.AddAjaxHeaders();
            var loginResult = _client.UploadString(LoginUrl, loginData);
            var salt = TextExtracter.GetJsonValue(loginResult, "salt");
            var captcha = TextExtracter.GetJsonValue(loginResult, "captcha");

            if (!string.IsNullOrEmpty(salt))
            {
                return true;
            }

            if (string.IsNullOrEmpty(captcha))
            {
                return false;
            }

            var dataWithCaptcha = loginData + captcha;
            return TryLoginWithCaptcha(dataWithCaptcha);
        }

        private string GetLoginData(VozAccount account)
        {
            string dataFormat = "do=login&api_cookieuser=1&securitytoken=guest&api_vb_login_md5password={0}"
                + "&api_vb_login_md5password_utf={0}&api_vb_login_password={1}&api_vb_login_username={2}&api_2factor=&api_salt=&api_captcha=";


            var passwordHash = Md5Helper.CalculateMD5Hash(account.Password);

            return string.Format(dataFormat, passwordHash, account.Password, account.Username);
        }

        private bool TryLoginWithCaptcha(string dataWithCaptcha)
        {
            // Submit Captcha
            _client.AddAjaxHeaders();
            var captchaResult = _client.UploadString(LoginUrl, dataWithCaptcha);
            var salt = TextExtracter.GetJsonValue(captchaResult, "salt");

            return !string.IsNullOrEmpty(salt);
        }

        #endregion

        #region FindNewPost

        public List<int> FindNewPost(List<string> boxes)
        {
            var result = new List<int>();
            foreach (var box in boxes)
            {
                _client.AddHeaders();
                var htmlText = _client.DownloadString(box);
                var html = new HtmlDocument();
                html.LoadHtml(htmlText);

                var document = html.DocumentNode;
                var threadsList = document.QuerySelector("#threadslist");
                if (threadsList == null)
                {
                    continue;
                }

                var rows = threadsList.QuerySelectorAll("tr");
                foreach (var row in rows)
                {
                    var cols = row.QuerySelectorAll("td").ToList();
                    if (cols.Count != 5)
                    {
                        continue;
                    }

                    var postCountText = cols[4].InnerText.Trim();
                    var postCount = 0;
                    if (!int.TryParse(postCountText, out postCount) || postCount >= 10)
                    {
                        continue;
                    }

                    var threadIdText = cols[1].GetAttributeValue("id", "");
                    threadIdText = threadIdText.Replace("td_threadtitle_", "").Trim();
                    var threadId = 0;
                    if (!int.TryParse(threadIdText, out threadId) || threadId == 0)
                    {
                        continue;
                    }

                    result.Add(threadId);
                }
            }

            return result;
        }

        #endregion

        #region Spam

        public bool PostReply(int threadId)
        {
            _currentReplyLink = GetPostIdOfThread(threadId);
            // SecurityToken
            _client.AddHeaders();
            var htmlText = _client.DownloadString(_currentReplyLink);

            // Hash
            var html = new HtmlDocument();
            html.LoadHtml(htmlText);
            var documentNode = html.DocumentNode;

            _securityToken = documentNode.QuerySelector("input[name=securitytoken]").GetAttributeValue("value", "");
            var title = documentNode.QuerySelector("input[name=title]").GetAttributeValue("value", "");
            var hashNode = documentNode.QuerySelector("#hash");
            if (hashNode == null)
            {
                // "Oh không cần captcha,
                PostReplyCallback(string.Empty);
                return true;
            }
            else
            {
                GetReplyCaptcha(htmlText, documentNode);
                FlashWindowHelper.FlashMainWindow();
                MessageBox.Show("Gõ captcha, nhấn nút Gõ Captcha để spam vào topic" + title);
                return false;
            }
        }

        public void PostReplyCallback(string captcha)
        {
            var spamText = _spamTextbox.GetTextThreadSafe();
            spamText += Guid.NewGuid().ToString();
            var data = string.Format(
                "do=postreply&multiquoteempty=&emailupdate=9999&message={0}&humanverify[hash]={1}&humanverify[input]={2}&securitytoken={3}",
                Uri.EscapeUriString(spamText),
                Md5Helper.CalculateMD5Hash(captcha),
                captcha,
                _securityToken
                );

            _client.AddHeaders();
            var result = _client.UploadString(_currentReplyLink, data);
        }

        private string GetPostIdOfThread(int threadId)
        {
            string threadUrl = "http://vozforums.com/showthread.php?t=" + threadId;
            _client.AddHeaders();
            var htmlText = _client.DownloadString(threadUrl);

            var html = new HtmlDocument();
            html.LoadHtml(htmlText);
            var document = html.DocumentNode;

            var firstReplyLink = document.QuerySelectorAll("td.smallfont a").FirstOrDefault();

            return firstReplyLink == null
                ? null
                : "http://vozforums.com/" + WebUtility.HtmlDecode(firstReplyLink.GetAttributeValue("href", ""));
        }

        private void GetReplyCaptcha(string htmlText, HtmlNode documentNode)
        {
            var securityToken = TextExtracter.ExtractText(htmlText, "var SECURITYTOKEN = \"", "\"");

            var hash = documentNode.QuerySelector("#hash").GetAttributeValue("value", "");

            // Actual image hash
            var postData = "securitytoken=" + securityToken + "&do=imagereg&hash=" + hash;
            _client.AddAjaxHeaders();
            var ajaxText = _client.UploadString("http://vozforums.com/ajax.php?do=imagereg", postData);
            var imageHash = TextExtracter.ExtractText(ajaxText, "<hash>", "</hash>");

            // Get Image
            var imageUrl = "http://vozforums.com/image.php?type=hv&hash=" + imageHash;
            var tempFile = Path.GetTempFileName() + ".png";
            _client.AddHeaders();
            _client.DownloadFile(imageUrl, tempFile);
            _captchaPictureBox.SetImageLocationThreadSafe(tempFile);
        }

        #endregion        
    }
}

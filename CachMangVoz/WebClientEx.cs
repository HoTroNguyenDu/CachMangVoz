// -----------------------------------------------------------------------
// <copyright file="WebClientEx.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace CachMangVoz
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class WebClientEx : WebClient
    {
        public WebClientEx()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            this.Encoding = Encoding.UTF8;
        }

        public void AddHeaders()
        {
            AddHeaderItem("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:35.0) Gecko/20100101 Firefox/35.0");
            AddHeaderItem("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            AddHeaderItem("Accept-Language", "en-US,en;q=0.5");
            AddHeaderItem("Pragma", "no-cache");
            AddHeaderItem("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            AddHeaderItem("Cache-Control", "no-cache");

            var ajaxHeader = this.Headers.Get("X-Requested-With");
            if (!string.IsNullOrEmpty(ajaxHeader))
            {
                this.Headers.Remove("X-Requested-With");
            }
        }

        public void AddAjaxHeaders()
        {
            AddHeaderItem("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:35.0) Gecko/20100101 Firefox/35.0");
            AddHeaderItem("Accept", "application/json, text/javascript, */*; q=0.01");
            AddHeaderItem("Accept-Language", "en-US,en;q=0.5");
            AddHeaderItem("Pragma", "no-cache");
            AddHeaderItem("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            AddHeaderItem("X-Requested-With", "XMLHttpRequest");
            AddHeaderItem("Cache-Control", "no-cache");
        }

        private void AddHeaderItem(string name, string value)
        {
            var headerItem = this.Headers.Get(name);
            if (!string.IsNullOrEmpty(headerItem))
            {
                this.Headers.Remove(name);
            }

            this.Headers.Add(name, value);
        }

        private readonly CookieContainer container = new CookieContainer();
        private CookieCollection cookieCollection = new CookieCollection();

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest r = base.GetWebRequest(address);
            var request = r as HttpWebRequest;
            request.AllowAutoRedirect = true;
            if (request != null)
            {
                request.CookieContainer = container;
            }
            return r;
        }

        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
        {

            WebResponse response = base.GetWebResponse(request, result);
            ReadCookies(response);
            return response;

        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);
            ReadCookies(response);
            return response;
        }

        private void ReadCookies(WebResponse r)
        {
            var response = r as HttpWebResponse;
            if (response != null)
            {
                cookieCollection = response.Cookies;
                container.Add(cookieCollection);
            }
        }

        public string GetCookie(string key)
        {
            return cookieCollection[key].Value;
        }
    }
}

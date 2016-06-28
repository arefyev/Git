using ADV.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;

namespace ADV.Web.Code
{
    public class UIHelper
    {
        private static List<string> Languages { get; set; }
        private static string DefaultLang { get { return "en"; } }

        static UIHelper()
        {
            Languages = ConfigurationManager.AppSettings["Languages"].Split(',').ToList();
        }

        /// <summary>
        /// Returns language from cookie if exists or default value
        /// </summary>
        /// <returns></returns>
        private static string GetLangFromCookie()
        {
            var lang = String.Empty;
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(Variables.LangCookieName) && HttpContext.Current.Request.Cookies[Variables.LangCookieName]["Lang"] != null)
                lang = HttpContext.Current.Request.Cookies[Variables.LangCookieName]["Lang"];
            return lang;
        }

        public static string DetectLang()
        {
            var coo = GetLangFromCookie();
            if (!String.IsNullOrEmpty(coo))
                return coo;

            var val = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            if (Languages.Contains(val))
                return val;

            return DefaultLang;
        }
        /// <summary>
        /// Sets selected language to cookie
        /// </summary>
        /// <param name="lang"></param>
        public static void SetLangToCookie(string lang)
        {
            var cookie = new HttpCookie(Variables.LangCookieName);
            cookie["Lang"] = lang;
            if (!HttpContext.Current.Request.IsLocal)
                cookie.Domain = "dmitry-arefyev.net";
            cookie.Expires = DateTime.Now.AddDays(365);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static SelectedLanguage GetCurrentLanguage()
        {
            var lang = DetectLang();
            return new SelectedLanguage { CssSlass = lang, Lang = lang };
        }

    }
}
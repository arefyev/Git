using System;
using System.Web.Mvc;
using ADV.Web.Code;

//using TestJS.Models;

namespace ADV.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            if (!(lang == "en" || lang == "ru" || lang == "de")) //life hack
                lang = "en";
            UIHelper.SetLangToCookie(lang);
            if (String.IsNullOrEmpty(returnUrl))
                returnUrl = "/";
            return Redirect(returnUrl);
        }
    }
}

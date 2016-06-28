using System.Web.Mvc;

namespace ADV.Web.Controllers
{
    public class ErrorsController : Controller
    {
        //
        // GET: /Errors/

        public ActionResult E404()
        {
            return View();
        }

        public ActionResult E500()
        {
            return View();
        }
    }
}

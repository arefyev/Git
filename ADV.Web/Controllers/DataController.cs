using System.Web.Http;
using ADV.Web.Code;
using ADV.Web.Models;


namespace ADV.Web.Controllers
{
    public class DataController : ApiController
    {
        [AcceptVerbs("POST")]
        [HttpPost]
        public ProjectsViewModel GetPortfolioData()
        {
            var data = DataHelper.GetProjectsSolution();
            return data;
        }
    }
}

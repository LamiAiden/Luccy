using System.Web.Mvc;

namespace Luccy.Web.Controllers
{
    public class HomeController : LuccyControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
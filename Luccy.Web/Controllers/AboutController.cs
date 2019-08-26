using System.Web.Mvc;

namespace Luccy.Web.Controllers
{
    public class AboutController : LuccyControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
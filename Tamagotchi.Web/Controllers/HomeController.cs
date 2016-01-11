using System.Web.Mvc;

namespace Tamagotchi.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("~/about")]
        public ActionResult About()
        {
            return View();
        }
    }
}
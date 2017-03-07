using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ivaylo Tsvetkov aka. ^KRONIK^";

            return View();
        }
    }
}
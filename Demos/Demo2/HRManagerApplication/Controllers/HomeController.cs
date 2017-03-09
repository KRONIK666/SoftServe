using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Manage company employees database.";

            return View();
        }
    }
}
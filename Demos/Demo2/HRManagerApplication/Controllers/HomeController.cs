using HRManagerApplication.Models;
using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class HomeController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        public ActionResult Index()
        {
            ViewBag.Message = "Manage company employees database.";

            return View();
        }
    }
}
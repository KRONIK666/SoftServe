using HRManagerApplication.Models;
using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class HomeController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        public ActionResult Index()
        {
            return View();
        }
    }
}
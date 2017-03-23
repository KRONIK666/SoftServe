using System.Web.Mvc;

using HRManagementSystem.Models;

namespace HRManagementSystem.Controllers
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
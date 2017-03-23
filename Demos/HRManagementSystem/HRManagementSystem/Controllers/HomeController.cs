using HRManagementSystem.Models;
using System.Web.Mvc;

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
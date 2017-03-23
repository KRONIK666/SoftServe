using HRManagerSystem.Models;
using System.Web.Mvc;

namespace HRManagerSystem.Controllers
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
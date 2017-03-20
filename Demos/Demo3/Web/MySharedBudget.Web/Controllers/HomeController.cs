namespace MySharedBudget.Web.Controllers
{
    using System.Web.Mvc;

    using Base;

    public class HomeController : BaseDataController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
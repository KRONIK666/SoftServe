using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using HRManagementSystem.Models;

namespace HRManagementSystem.Controllers
{
    public class CEOsController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        // GET: CEO from database.
        public ActionResult Index()
        {
            return View(db.CEOs.ToList());
        }

        // GET: Details of CEO.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CEO cEO = db.CEOs.Find(id);
            if (cEO == null)
            {
                return HttpNotFound();
            }
            return View(cEO);
        }

        // GET: CEO to Edit.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CEO cEO = db.CEOs.Find(id);
            if (cEO == null)
            {
                return HttpNotFound();
            }
            return View(cEO);
        }

        // POST: Edit CEO.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone")] CEO cEO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cEO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cEO);
        }

        // Disposing the database.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
using HRManagerApplication.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class CEOsController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        // GET: CEOs
        public ActionResult Index()
        {
            return View(db.CEOs.ToList());
        }

        // GET: CEOs/Details/5
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

        // GET: CEOs/Edit/5
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

        // POST: CEOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
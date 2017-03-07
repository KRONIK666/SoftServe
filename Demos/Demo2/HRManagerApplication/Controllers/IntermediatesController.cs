using HRManagerApplication.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class IntermediatesController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        // GET: Intermediates
        public ActionResult Index()
        {
            var intermediates = db.Intermediates.Include(i => i.Project).Include(i => i.TeamLeader);
            return View(intermediates.ToList());
        }

        // GET: Intermediates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intermediate intermediate = db.Intermediates.Find(id);
            if (intermediate == null)
            {
                return HttpNotFound();
            }
            return View(intermediate);
        }

        // GET: Intermediates/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Project_Name");
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name");
            return View();
        }

        // POST: Intermediates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Position,Salary,City,E_mail,Phone,ProjectID,ManagerID")] Intermediate intermediate)
        {
            if (ModelState.IsValid)
            {
                db.Intermediates.Add(intermediate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Project_Name", intermediate.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", intermediate.ManagerID);
            return View(intermediate);
        }

        // GET: Intermediates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intermediate intermediate = db.Intermediates.Find(id);
            if (intermediate == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Project_Name", intermediate.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", intermediate.ManagerID);
            return View(intermediate);
        }

        // POST: Intermediates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Position,Salary,City,E_mail,Phone,ProjectID,ManagerID")] Intermediate intermediate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intermediate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Project_Name", intermediate.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", intermediate.ManagerID);
            return View(intermediate);
        }

        // GET: Intermediates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intermediate intermediate = db.Intermediates.Find(id);
            if (intermediate == null)
            {
                return HttpNotFound();
            }
            return View(intermediate);
        }

        // POST: Intermediates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Intermediate intermediate = db.Intermediates.Find(id);
            db.Intermediates.Remove(intermediate);
            db.SaveChanges();
            return RedirectToAction("Index");
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
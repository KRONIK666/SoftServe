using HRManagerApplication.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class JuniorsController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        // GET: Juniors
        public ActionResult Index()
        {
            var juniors = db.Juniors.Include(j => j.Project).Include(j => j.TeamLeader);
            return View(juniors.ToList());
        }

        // GET: Juniors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Junior junior = db.Juniors.Find(id);
            if (junior == null)
            {
                return HttpNotFound();
            }
            return View(junior);
        }

        // GET: Juniors/Create
        public ActionResult Create()
        {
            Junior position = new Junior()
            {
                Position = "Junior"
            };

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName");
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name");
            return View(position);
        }

        // POST: Juniors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ProjectID,ManagerID")] Junior junior)
        {
            if (ModelState.IsValid)
            {
                db.Juniors.Add(junior);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", junior.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", junior.ManagerID);
            return View(junior);
        }

        // GET: Juniors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Junior junior = db.Juniors.Find(id);
            if (junior == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", junior.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", junior.ManagerID);
            return View(junior);
        }

        // POST: Juniors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ProjectID,ManagerID")] Junior junior)
        {
            if (ModelState.IsValid)
            {
                db.Entry(junior).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", junior.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", junior.ManagerID);
            return View(junior);
        }

        // GET: Juniors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Junior junior = db.Juniors.Find(id);
            if (junior == null)
            {
                return HttpNotFound();
            }
            return View(junior);
        }

        // POST: Juniors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Junior junior = db.Juniors.Find(id);
            db.Juniors.Remove(junior);
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
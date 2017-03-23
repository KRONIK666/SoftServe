using HRManagementSystem.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HRManagementSystem.Controllers
{
    public class IntermediatesController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        // GET: All Intermediates from database.
        public ActionResult Index()
        {
            var intermediates = db.Intermediates.Include(i => i.Project).Include(i => i.TeamLeader);
            return View(intermediates.ToList());
        }

        // GET: Details of Intermediates.
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

        // GET: Intermediates to Create.
        public ActionResult Create()
        {
            Intermediate position = new Intermediate()
            {
                Position = "Intermediate"
            };

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName");
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name");
            return View(position);
        }

        // POST: Create Intermediates.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ProjectID,ManagerID")] Intermediate intermediate)
        {
            if (ModelState.IsValid)
            {
                db.Intermediates.Add(intermediate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", intermediate.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", intermediate.ManagerID);
            return View(intermediate);
        }

        // GET: Intermediates to Edit.
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
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", intermediate.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", intermediate.ManagerID);
            return View(intermediate);
        }

        // POST: Edit Intermediates.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ProjectID,ManagerID")] Intermediate intermediate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intermediate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", intermediate.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", intermediate.ManagerID);
            return View(intermediate);
        }

        // GET: Intermediates to Delete.
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

        // POST: Delete Intermediates.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Intermediate intermediate = db.Intermediates.Find(id);
            db.Intermediates.Remove(intermediate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Members of the teams working on projects.
        public ActionResult Team(int? id)
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

            var query1 = (from row in db.TeamLeaders
                          where row.Project.ProjectName == intermediate.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query2 = (from row in db.Seniors
                          where row.Project.ProjectName == intermediate.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query3 = (from row in db.Intermediates
                          where row.Project.ProjectName == intermediate.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query4 = (from row in db.Juniors
                          where row.Project.ProjectName == intermediate.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query5 = (from row in db.Trainees
                          where row.Project.ProjectName == intermediate.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query = query1.Concat(query2).Concat(query3).Concat(query4).Concat(query5);

            var team = new List<Intermediate>();

            foreach (var item in query)
            {
                team.Add(new Intermediate()
                {
                    Name = item.Name,
                    Position = item.Position,
                    Project = item.Project
                });
            }

            return View(team);
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
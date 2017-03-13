using HRManagerApplication.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class SeniorsController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        // GET: Seniors
        public ActionResult Index()
        {
            var seniors = db.Seniors.Include(s => s.Project).Include(s => s.TeamLeader);
            return View(seniors.ToList());
        }

        // GET: Seniors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Senior senior = db.Seniors.Find(id);
            if (senior == null)
            {
                return HttpNotFound();
            }
            return View(senior);
        }

        // GET: Seniors/Create
        public ActionResult Create()
        {
            Senior position = new Senior()
            {
                Position = "Senior"
            };

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName");
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name");
            return View(position);
        }

        // POST: Seniors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ProjectID,ManagerID")] Senior senior)
        {
            if (ModelState.IsValid)
            {
                db.Seniors.Add(senior);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", senior.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", senior.ManagerID);
            return View(senior);
        }

        // GET: Seniors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Senior senior = db.Seniors.Find(id);
            if (senior == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", senior.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", senior.ManagerID);
            return View(senior);
        }

        // POST: Seniors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ProjectID,ManagerID")] Senior senior)
        {
            if (ModelState.IsValid)
            {
                db.Entry(senior).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", senior.ProjectID);
            ViewBag.ManagerID = new SelectList(db.TeamLeaders, "ID", "Name", senior.ManagerID);
            return View(senior);
        }

        // GET: Seniors to Delete.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Senior senior = db.Seniors.Find(id);
            if (senior == null)
            {
                return HttpNotFound();
            }
            return View(senior);
        }

        // POST: Delete Seniors.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Senior senior = db.Seniors.Find(id);
            db.Seniors.Remove(senior);
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

            Senior senior = db.Seniors.Find(id);

            if (senior == null)
            {
                return HttpNotFound();
            }

            var query1 = (from row in db.TeamLeaders
                          where row.Project.ProjectName == senior.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query2 = (from row in db.Seniors
                          where row.Project.ProjectName == senior.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query3 = (from row in db.Intermediates
                          where row.Project.ProjectName == senior.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query4 = (from row in db.Juniors
                          where row.Project.ProjectName == senior.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query5 = (from row in db.Trainees
                          where row.Project.ProjectName == senior.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query = query1.Concat(query2).Concat(query3).Concat(query4).Concat(query5);

            var team = new List<Senior>();

            foreach (var item in query)
            {
                team.Add(new Senior()
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
using HRManagerSystem.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HRManagerSystem.Controllers
{
    public class ProjectsController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        // GET: All Projects from database.
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.ProjectManager);
            return View(projects.ToList());
        }

        // GET: Details of Projects.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects to Create.
        public ActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(db.ProjectManagers, "ID", "Name");
            return View();
        }

        // POST: Create Projects.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectName,ManagerID")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(db.ProjectManagers, "ID", "Name", project.ManagerID);
            return View(project);
        }

        // GET: Projects to Edit.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(db.ProjectManagers, "ID", "Name", project.ManagerID);
            return View(project);
        }

        // POST: Edit Projects.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectName,ManagerID")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(db.ProjectManagers, "ID", "Name", project.ManagerID);
            return View(project);
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
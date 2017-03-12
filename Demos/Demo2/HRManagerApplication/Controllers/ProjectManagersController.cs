using HRManagerApplication.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class ProjectManagersController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        // GET: ProjectManagers
        public ActionResult Index()
        {
            var projectManagers = db.ProjectManagers.Include(p => p.DeliveryDirector);
            return View(projectManagers.ToList());
        }

        // GET: ProjectManagers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectManager = db.ProjectManagers.Find(id);
            if (projectManager == null)
            {
                return HttpNotFound();
            }
            return View(projectManager);
        }

        // GET: ProjectManagers/Create
        public ActionResult Create()
        {
            ProjectManager position = new ProjectManager()
            {
                Position = "Project Manager"
            };

            ViewBag.ManagerID = new SelectList(db.DeliveryDirectors, "ID", "Name");
            return View(position);
        }

        // POST: ProjectManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ManagerID")] ProjectManager projectManager)
        {
            if (ModelState.IsValid)
            {
                db.ProjectManagers.Add(projectManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(db.DeliveryDirectors, "ID", "Name", projectManager.ManagerID);
            return View(projectManager);
        }

        // GET: ProjectManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectManager = db.ProjectManagers.Find(id);
            if (projectManager == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(db.DeliveryDirectors, "ID", "Name", projectManager.ManagerID);
            return View(projectManager);
        }

        // POST: ProjectManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ManagerID")] ProjectManager projectManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(db.DeliveryDirectors, "ID", "Name", projectManager.ManagerID);
            return View(projectManager);
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
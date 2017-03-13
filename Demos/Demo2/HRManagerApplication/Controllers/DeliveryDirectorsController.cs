using HRManagerApplication.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class DeliveryDirectorsController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        // GET: All Delivery Directors from database.
        public ActionResult Index()
        {
            var deliveryDirectors = db.DeliveryDirectors.Include(d => d.CEO);
            return View(deliveryDirectors.ToList());
        }

        // GET: Details of Delivery Directors.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDirector deliveryDirector = db.DeliveryDirectors.Find(id);
            if (deliveryDirector == null)
            {
                return HttpNotFound();
            }
            return View(deliveryDirector);
        }

        // GET: Delivery Directors to Create.
        public ActionResult Create()
        {
            DeliveryDirector position = new DeliveryDirector()
            {
                Position = "Delivery Director"
            };

            ViewBag.ManagerID = new SelectList(db.CEOs, "ID", "Name");
            return View(position);
        }

        // POST: Create Delivery Directors.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ManagerID")] DeliveryDirector deliveryDirector)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryDirectors.Add(deliveryDirector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(db.CEOs, "ID", "Name", deliveryDirector.ManagerID);
            return View(deliveryDirector);
        }

        // GET: Delivery Directors to Edit.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDirector deliveryDirector = db.DeliveryDirectors.Find(id);
            if (deliveryDirector == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(db.CEOs, "ID", "Name", deliveryDirector.ManagerID);
            return View(deliveryDirector);
        }

        // POST: Edit Delivery Directors.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ManagerID")] DeliveryDirector deliveryDirector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryDirector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(db.CEOs, "ID", "Name", deliveryDirector.ManagerID);
            return View(deliveryDirector);
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
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

        // GET: DeliveryDirectors
        public ActionResult Index()
        {
            var deliveryDirectors = db.DeliveryDirectors.Include(d => d.CEO);
            return View(deliveryDirectors.ToList());
        }

        // GET: DeliveryDirectors/Details/5
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

        // GET: DeliveryDirectors/Create
        public ActionResult Create()
        {
            DeliveryDirector position = new DeliveryDirector()
            {
                Position = "Delivery Director"
            };

            ViewBag.ManagerID = new SelectList(db.CEOs, "ID", "Name");
            return View(position);
        }

        // POST: DeliveryDirectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: DeliveryDirectors/Edit/5
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

        // POST: DeliveryDirectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: DeliveryDirectors/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: DeliveryDirectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryDirector deliveryDirector = db.DeliveryDirectors.Find(id);
            db.DeliveryDirectors.Remove(deliveryDirector);
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
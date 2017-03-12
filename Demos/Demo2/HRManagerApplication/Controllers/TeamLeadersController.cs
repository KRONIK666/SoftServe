﻿using HRManagerApplication.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HRManagerApplication.Controllers
{
    public class TeamLeadersController : Controller
    {
        private EmployeesDb db = new EmployeesDb();

        // GET: TeamLeaders
        public ActionResult Index()
        {
            var teamLeaders = db.TeamLeaders.Include(t => t.Project).Include(t => t.ProjectManager);
            return View(teamLeaders.ToList());
        }

        // GET: TeamLeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamLeader teamLeader = db.TeamLeaders.Find(id);
            if (teamLeader == null)
            {
                return HttpNotFound();
            }
            return View(teamLeader);
        }

        // GET: TeamLeaders/Create
        public ActionResult Create()
        {
            TeamLeader position = new TeamLeader()
            {
                Position = "Team Leader"
            };

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName");
            ViewBag.ManagerID = new SelectList(db.ProjectManagers, "ID", "Name");
            return View(position);
        }

        // POST: TeamLeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ProjectID,ManagerID")] TeamLeader teamLeader)
        {
            if (ModelState.IsValid)
            {
                db.TeamLeaders.Add(teamLeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", teamLeader.ProjectID);
            ViewBag.ManagerID = new SelectList(db.ProjectManagers, "ID", "Name", teamLeader.ManagerID);
            return View(teamLeader);
        }

        // GET: TeamLeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamLeader teamLeader = db.TeamLeaders.Find(id);
            if (teamLeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", teamLeader.ProjectID);
            ViewBag.ManagerID = new SelectList(db.ProjectManagers, "ID", "Name", teamLeader.ManagerID);
            return View(teamLeader);
        }

        // POST: TeamLeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Position,Salary,City,Email,Phone,ProjectID,ManagerID")] TeamLeader teamLeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamLeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", teamLeader.ProjectID);
            ViewBag.ManagerID = new SelectList(db.ProjectManagers, "ID", "Name", teamLeader.ManagerID);
            return View(teamLeader);
        }

        public ActionResult Team(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TeamLeader teamLeader = db.TeamLeaders.Find(id);

            if (teamLeader == null)
            {
                return HttpNotFound();
            }

            var query1 = (from row in db.TeamLeaders
                          where row.Project.ProjectName == teamLeader.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query2 = (from row in db.Seniors
                          where row.Project.ProjectName == teamLeader.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query3 = (from row in db.Intermediates
                          where row.Project.ProjectName == teamLeader.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query4 = (from row in db.Juniors
                          where row.Project.ProjectName == teamLeader.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query5 = (from row in db.Trainees
                          where row.Project.ProjectName == teamLeader.Project.ProjectName
                          select new { row.Name, row.Position, row.Project, row.Project.ProjectManager });

            var query = query1.Concat(query2).Concat(query3).Concat(query4).Concat(query5);

            var team = new List<TeamLeader>();

            foreach (var item in query)
            {
                team.Add(new TeamLeader()
                {
                    Name = item.Name,
                    Position = item.Position,
                    Project = item.Project
                });
            }

            return View(team);
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
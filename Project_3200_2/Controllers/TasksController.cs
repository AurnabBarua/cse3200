using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_3200_2.Models;


namespace Project_3200_2.Controllers
{
    public class TasksController : Controller
    {
        private Project_3214_Model2 db = new Project_3214_Model2();
        
        // GET: Tasks
        public ActionResult Index()
        {          
            return View(db.Tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }
        public ActionResult DashBoard()
        {
            var type = Session["DoctorType"];
           // Task task = db.Tasks.Find(type);
            ViewBag.type = type;
            return View(db.Tasks);
        }
        
        public ActionResult SendOperation(int? id)
        {
            Task task = db.Tasks.Find(id);
            Operation operation = new Operation();
            operation.PatientId = task.PatientId;
            operation.Activity = "Not Done";
            operation.NurseId = 1;
            operation.OperationDateTime = task.TaskDateTime;
            switch (task.TaskProblem)
            {
                case "Skin":
                    {
                        operation.DoctorName = "Professor Dr. Ataur Rahman";
                        break;
                    }
                case "Eye":
                    {
                        operation.DoctorName = "Dr. Muhammad Rahman";
                        break;
                    }
                case "Dental":
                    {
                        operation.DoctorName = "Professor. Dr. Ruhul Amin";
                        break;
                    }
                case "Neurology":
                    {
                        operation.DoctorName = "Dr. Afzal Momin";
                        break;
                    }
                case "Cardiology":
                    {
                        operation.DoctorName = "Professor Dr. Ashok Kumar Dutta";
                        break;
                    }

            }
            db.Operations.Add(operation);
            db.SaveChanges();
            return View();
        }
        
        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskId,TaskProblem,TaskDateTime,PatientId")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }
        
        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,TaskProblem,TaskDateTime,PatientId")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "TaskId,TaskProblem,TaskDateTime,PatientId,Activity")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DashBoard");
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
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

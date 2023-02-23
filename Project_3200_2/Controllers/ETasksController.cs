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
    public class ETasksController : Controller
    {
        private Project_3214_Model2 db = new Project_3214_Model2();

        // GET: ETasks
        public ActionResult Index()
        {
            return View(db.ETasks.ToList());
        }

        // GET: ETasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETask eTask = db.ETasks.Find(id);
            if (eTask == null)
            {
                return HttpNotFound();
            }
            return View(eTask);
        }
        public ActionResult DashBoard()
        {
            ViewBag.Id = (int)Session["EmployeeId"];
            return View(db.ETasks.ToList());
        }

        // GET: ETasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ETasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ETaskId,ETaskName,ETaskStartTime,ETaskEndTime,EmployeeId")] ETask eTask)
        {
            if (ModelState.IsValid)
            {
                db.ETasks.Add(eTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.EmployeeName = new SelectList(db.Employees, "EmployeeId", "EmployeeName", eTask.EmployeeId);
            return View(eTask);
        }

        // GET: ETasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETask eTask = db.ETasks.Find(id);
            if (eTask == null)
            {
                return HttpNotFound();
            }
            return View(eTask);
        }

        // POST: ETasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ETaskId,ETaskName,ETaskStartTime,ETaskEndTime")] ETask eTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eTask);
        }

        // GET: ETasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETask eTask = db.ETasks.Find(id);
            if (eTask == null)
            {
                return HttpNotFound();
            }
            return View(eTask);
        }

        // POST: ETasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ETask eTask = db.ETasks.Find(id);
            db.ETasks.Remove(eTask);
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

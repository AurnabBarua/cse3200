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
    public class EmergenciesController : Controller
    {
        private Model2 db = new Model2();
        private Project_3214_Model2 db2 = new Project_3214_Model2();

        // GET: Emergencies
        public ActionResult Index()
        {
            return View(db.Emergencies.ToList());
        }

        public ActionResult AllEmergency()
        {
            return View(db.Emergencies.ToList());
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TempUserDoctor tempUser)
        {
            if (ModelState.IsValid)
            {
                var user = db2.Doctors.Where(u => u.DoctorEmail.Equals(tempUser.DoctorEmail)
                  && u.DoctorPassword.Equals(tempUser.DoctorPassword)).FirstOrDefault();
                if (user != null)
                {                    
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.LoginFailed = "User not found or password mismatch";
                    return View();
                }
            }
            return View();
        }
        // GET: Emergencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emergency emergency = db.Emergencies.Find(id);
            if (emergency == null)
            {
                return HttpNotFound();
            }
            return View(emergency);
        }

        // GET: Emergencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emergencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmergencyId,EmergencyProblem,EmergencyLink")] Emergency emergency)
        {
            if (ModelState.IsValid)
            {
                db.Emergencies.Add(emergency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emergency);
        }

        // GET: Emergencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emergency emergency = db.Emergencies.Find(id);
            if (emergency == null)
            {
                return HttpNotFound();
            }
            return View(emergency);
        }

        // POST: Emergencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmergencyId,EmergencyProblem,EmergencyLink")] Emergency emergency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emergency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emergency);
        }

        // GET: Emergencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emergency emergency = db.Emergencies.Find(id);
            if (emergency == null)
            {
                return HttpNotFound();
            }
            return View(emergency);
        }

        // POST: Emergencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emergency emergency = db.Emergencies.Find(id);
            db.Emergencies.Remove(emergency);
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

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
    public class TreatmentsController : Controller
    {
        private Project_3214_Model2 db = new Project_3214_Model2();
        // private PROJECT_3200Entities2 db3 = new PROJECT_3200Entities2();

        Task task = new Task();
        
        // GET: Treatments
        public ActionResult Index()
        {
            return View(db.Treatments.ToList());
        }

        // GET: Treatments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // GET: Treatments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Treatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentId,TreatmentProblem,TreatmentDateTime")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {                
                db.Treatments.Add(treatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(treatment);
        }
        public ActionResult TakeService()
        {
            return View();
        }

        // POST: Treatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeService([Bind(Include = "TreatmentId,TreatmentProblem,TreatmentDateTime")] Treatment treatment)
        {
            try
            {
               // treatment.TreatmentDateTime =DateTime.Now.ToString();
                if (ModelState.IsValid)
                {
                    int doctorId = 4;
                    switch (treatment.TreatmentProblem)
                    {
                        case "Skin":
                            {
                                doctorId = 4;
                                break;
                            }
                        case "Eye":
                            {
                                doctorId = 5;
                                break;
                            }
                        case "Dental":
                            {
                                doctorId = 6;
                                break;
                            }
                        case "Neurology":
                            {
                                doctorId = 7;
                                break;
                            }
                        case "Cardiology":
                            {
                                doctorId = 8;
                                break;
                            }
                    }
                    
                    treatment.PatientId = (int)Session["PatientId"];
                    var doctor = db.Doctors.Find(doctorId);
                    ViewBag.doctorName = doctor.DoctorName+" at floor "+doctor.DoctorRoom;
                    task.TaskProblem = treatment.TreatmentProblem;
                    task.TaskDateTime = treatment.TreatmentDateTime;
                    task.Activity = "Not Done";
                    task.PatientId = (int)treatment.PatientId;
                    db.Tasks.Add(task);
                    db.SaveChanges();
                    db.Treatments.Add(treatment);
                    db.SaveChanges();
                    return View(treatment);
                }
                return View(treatment);
            }
            catch (Exception)
            {
                ViewBag.doctorName = "Please fill up properly";
                return View(treatment);
            }

        }
        // GET: Treatments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentId,TreatmentProblem,TreatmentDateTime")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treatment);
        }

        // GET: Treatments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // POST: Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treatment treatment = db.Treatments.Find(id);
            db.Treatments.Remove(treatment);
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

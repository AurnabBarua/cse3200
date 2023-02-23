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
    
    public class PatientsController : Controller
    {
        private Project_3214_Model2 db = new Project_3214_Model2();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TempUserPatient tempUser)
        {
            if (ModelState.IsValid)
            {
                var user = db.Patients.Where(u => u.PatientEmail.Equals(tempUser.PatientEmail)
                  && u.PatientPassword.Equals(tempUser.PatientPassword)).FirstOrDefault();
                if (user != null)
                {
                    Session["PatientId"] = user.PatientId;
                    Session["PatientName"] = user.PatientName;
                   
                    return RedirectToAction("DashBoard", new { email = user.PatientEmail });
                }
                else
                {
                    ViewBag.LoginFailed = "User not found or password mismatch";
                    return View();
                }
            }
            return View();
        }
        public ActionResult DashBoard(string email)
        {            
            var user = db.Patients.Where(u => u.PatientEmail.Equals(email)).FirstOrDefault();
            if (user != null)
            {               
                return View(user);
            }
            return RedirectToAction("Login");
        }
        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp([Bind(Include = "PatientId,PatientName,PatientPhone,PatientAddress,PatientEmail,PatientPassword")] Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (patient.PatientPhone.Length == 11
                        && patient.PatientPhone[0] == 0 && patient.PatientPhone[1] == 1
                        && patient.PatientEmail.Contains("@gmail.com") &&
                        patient.PatientPassword.Length>=8)
                    {
                        db.Patients.Add(patient);
                        db.SaveChanges();
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                return View(patient);
            }
            catch (Exception)
            {
                ViewBag.SignUpFailed = "Please fillup the form properly";
                return View(patient);
            }



        }
        // GET: Patients/Create
        public ActionResult Create()
        {           
            return View();
        }
        

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,PatientName,PatientPhone,PatientAddress,PatientEmail,PatientPassword")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "PatientId,PatientName,PatientPhone,PatientAddress,PatientEmail,PatientPassword")] Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(patient).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("DashBoard", new { email = patient.PatientEmail });
                }
                return View(patient);
            }
            catch (Exception)
            {
                ViewBag.EditFailed = "Please fill up the form correctly";
                return View();
            }
            
        }
        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientId,PatientName,PatientPhone,PatientAddress,PatientEmail,PatientPassword")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

       
        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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

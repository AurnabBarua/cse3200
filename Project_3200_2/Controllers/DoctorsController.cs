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
    public class DoctorsController : Controller
    {
        private Project_3214_Model2 db = new Project_3214_Model2();

        // GET: Doctors
        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
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
                var user = db.Doctors.Where(u => u.DoctorEmail.Equals(tempUser.DoctorEmail)
                  && u.DoctorPassword.Equals(tempUser.DoctorPassword)).FirstOrDefault();
                if (user != null)
                {
                    Session["DoctorType"] = user.DoctorCatagory;
                    Session["Doctor_Id"] = user.DoctorId;
                    return RedirectToAction("DashBoard", new { email = user.DoctorEmail });
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
            var user = db.Doctors.Where(u => u.DoctorEmail.Equals(email)).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        }
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "DoctorId,DoctorName,DoctorEmail,DoctorPassword,DoctorAddress,DoctorCatagory,DoctorPhone,DoctorRoom")] Doctor doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                      db.Entry(doctor).State = EntityState.Modified;
                      db.SaveChanges();
                      return RedirectToAction("DashBoard", new { email = doctor.DoctorEmail });

                    
                }

                return View(doctor);
            }
            catch (Exception)
            {

                ViewBag.EditFailed = "Please fill up the form correctly";
                return View();
            }
           
        }
        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,DoctorName,DoctorEmail,DoctorPassword,DoctorAddress,DoctorCatagory,DoctorPhone,DoctorRoom")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,DoctorName,DoctorEmail,DoctorPassword,DoctorAddress,DoctorCatagory,DoctorPhone,DoctorRoom")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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

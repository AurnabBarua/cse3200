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
    public class NursesController : Controller
    {
        private Project_3214_Model2 db = new Project_3214_Model2();

        // GET: Nurses
        public ActionResult Index()
        {
            return View(db.Nurses.ToList());
        }

        // GET: Nurses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TempUserNurse tempUser)
        {
            if (ModelState.IsValid)
            {
                var user = db.Nurses.Where(u => u.NurseEmail.Equals(tempUser.NurseEmail)
                  && u.NursePassword.Equals(tempUser.NursePassword)).FirstOrDefault();
                if (user != null)
                {
                    Session["nurseId"] = user.NurseId;
                    Session["nurseName"] = user.NurseName;
                    return RedirectToAction("DashBoard", new { email = user.NurseEmail });
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
            var user = db.Nurses.Where(u => u.NurseEmail.Equals(email)).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        }
        
        // GET: Nurses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nurses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NurseId,NurseName,NurseEmail,NursePassword,NurseAddress,NursePhone")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                db.Nurses.Add(nurse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nurse);
        }

        // GET: Nurses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }

        // POST: Nurses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NurseId,NurseName,NurseEmail,NursePassword,NurseAddress,NursePhone")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nurse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nurse);
        }
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }

        // POST: Nurses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "NurseId,NurseName,NurseEmail,NursePassword,NurseAddress,NursePhone")] Nurse nurse)
        {
            try
            {
                
                    if (ModelState.IsValid)
                    {
                        db.Entry(nurse).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("DashBoard", new { email = nurse.NurseEmail });

                    }
                return View(nurse);

            }
            catch (Exception)
            {
                ViewBag.EditFailed = "Please fill up the form correctly";
                return View();
            }
           
        }

        // GET: Nurses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }

        // POST: Nurses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nurse nurse = db.Nurses.Find(id);
            db.Nurses.Remove(nurse);
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

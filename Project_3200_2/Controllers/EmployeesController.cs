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
    public class EmployeesController : Controller
    {
        private Project_3214_Model2 db = new Project_3214_Model2();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TempUserEmployee tempUser)
        {
            if (ModelState.IsValid)
            {
                var user = db.Employees.Where(u => u.EmployeeEmail.Equals(tempUser.EmployeeEmail)
                  && u.EmployeePassword.Equals(tempUser.EmployeePassword)).FirstOrDefault();
                if (user != null)
                {
                   
                    return RedirectToAction("DashBoard", new { email = user.EmployeeEmail });
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
            var user = db.Employees.Where(u => u.EmployeeEmail.Equals(email)).FirstOrDefault();
            if (user != null)
            {
                Session["EmployeeId"] = user.EmployeeId;
                return View(user);
            }
            return RedirectToAction("Login");
        }
        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeName,EmployeeEmail,EmployeePassword,EmployeeAddress,EmployeePhone")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "EmployeeId,EmployeeName,EmployeeEmail,EmployeePassword,EmployeeAddress,EmployeePhone")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)

                { 
                        db.Entry(employee).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("DashBoard", new { email = employee.EmployeeEmail });

                    
                   
                }
                return View(employee);
            }
            catch (Exception)
            {

                ViewBag.EditFailed = "Please fill up the form correctly";
                return View();
            }
            
        }
        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeName,EmployeeEmail,EmployeePassword,EmployeeAddress,EmployeePhone")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SYSTEM_MANAGEMENT.Models;
using SYSTEM_MANAGEMENT.Models.BussinessModel;

namespace SYSTEM_MANAGEMENT.Controllers
{
    [AuthorizeBussiness]
    public class DEPARTMENTsController : Controller
    {
        
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: DEPARTMENTs
        public ActionResult Index()
        {
            var dEPARTMENTS = db.DEPARTMENTS.Include(d => d.USER);
            return View(dEPARTMENTS.ToList());
        }
        public ActionResult Department_Users(string id)
        {

            var users = (from u in db.USER_METAS
                         where u.DEPARTMENT_ID == id
                         select u).ToList();
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: DEPARTMENTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENTS.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Create
        public ActionResult Create()
        {
            ViewBag.MANAGER = new SelectList(db.USERS, "USER_ID", "USERNAME");
            return View();
        }

        // POST: DEPARTMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEPARTMENT_ID,DEPARTMENT_NAME,MANAGER,NOTED")] DEPARTMENT dEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTMENTS.Add(dEPARTMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MANAGER = new SelectList(db.USERS, "USER_ID", "USERNAME", dEPARTMENT.MANAGER);
            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENTS.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.MANAGER = new SelectList(db.USERS, "USER_ID", "USERNAME", dEPARTMENT.MANAGER);
            return View(dEPARTMENT);
        }

        // POST: DEPARTMENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEPARTMENT_ID,DEPARTMENT_NAME,MANAGER,NOTED")] DEPARTMENT dEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPARTMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MANAGER = new SelectList(db.USERS, "USER_ID", "USERNAME", dEPARTMENT.MANAGER);
            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENTS.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT);
        }

        // POST: DEPARTMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DEPARTMENT dEPARTMENT = db.DEPARTMENTS.Find(id);
            db.DEPARTMENTS.Remove(dEPARTMENT);
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

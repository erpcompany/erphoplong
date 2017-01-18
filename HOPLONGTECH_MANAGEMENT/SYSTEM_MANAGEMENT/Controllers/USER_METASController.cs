using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SYSTEM_MANAGEMENT.Models;

namespace SYSTEM_MANAGEMENT.Controllers
{
    public class USER_METASController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: USER_METAS
        public ActionResult Index(int? id)
        {
            var uSER_METAS = db.USER_METAS.Where(x => x.USER_ID == id);
            return View(uSER_METAS.ToList());
        }

        // GET: USER_METAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER_METAS uSER_METAS = db.USER_METAS.Find(id);
            if (uSER_METAS == null)
            {
                return HttpNotFound();
            }
            return View(uSER_METAS);
        }

        // GET: USER_METAS/Create
        public ActionResult Create()
        {
            ViewBag.DEPARTMENT_ID = new SelectList(db.DEPARTMENTS, "DEPARTMENT_ID", "DEPARTMENT_NAME");
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME");
            return View();
        }

        // POST: USER_METAS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USER_ID,DEPARTMENT_ID,SEX,BIRTHDAY,START_TIME,NUMBER_PHONE,SENIORITY,NATIVE_LAND,LITERACY")] USER_METAS uSER_METAS)
        {
            if (ModelState.IsValid)
            {
                db.USER_METAS.Add(uSER_METAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPARTMENT_ID = new SelectList(db.DEPARTMENTS, "DEPARTMENT_ID", "DEPARTMENT_NAME", uSER_METAS.DEPARTMENT_ID);
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", uSER_METAS.USER_ID);
            return View(uSER_METAS);
        }

        // GET: USER_METAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER_METAS uSER_METAS = db.USER_METAS.Find(id);
            if (uSER_METAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPARTMENT_ID = new SelectList(db.DEPARTMENTS, "DEPARTMENT_ID", "DEPARTMENT_NAME", uSER_METAS.DEPARTMENT_ID);
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", uSER_METAS.USER_ID);
            return View(uSER_METAS);
        }

        // POST: USER_METAS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USER_ID,DEPARTMENT_ID,SEX,BIRTHDAY,START_TIME,NUMBER_PHONE,SENIORITY,NATIVE_LAND,LITERACY")] USER_METAS uSER_METAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSER_METAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPARTMENT_ID = new SelectList(db.DEPARTMENTS, "DEPARTMENT_ID", "DEPARTMENT_NAME", uSER_METAS.DEPARTMENT_ID);
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", uSER_METAS.USER_ID);
            return View(uSER_METAS);
        }

        // GET: USER_METAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER_METAS uSER_METAS = db.USER_METAS.Find(id);
            if (uSER_METAS == null)
            {
                return HttpNotFound();
            }
            return View(uSER_METAS);
        }

        // POST: USER_METAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USER_METAS uSER_METAS = db.USER_METAS.Find(id);
            db.USER_METAS.Remove(uSER_METAS);
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

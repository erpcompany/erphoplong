using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SYSTEM_MANAGEMENT.Models;

namespace SYSTEM_MANAGEMENT.Areas.HopLong.Controllers
{
    public class COMPANiesController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/COMPANies
        public ActionResult Index()
        {
            var cOMPANYS = db.COMPANYS.Include(c => c.COMPANY_CATEGORIES).Include(c => c.USER).Include(c => c.COMPANY1);
            return View(cOMPANYS.ToList());
        }

        // GET: HopLong/COMPANies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY cOMPANY = db.COMPANYS.Find(id);
            if (cOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY);
        }

        // GET: HopLong/COMPANies/Create
        public ActionResult Create()
        {
            ViewBag.COMPANY_CATEGORY_ID = new SelectList(db.COMPANY_CATEGORIES, "COMPANY_CATEGORY_ID", "COMPANY_CATEGORY_NAME");
            ViewBag.MANAGER = new SelectList(db.USERS, "USER_ID", "USERNAME");
            ViewBag.PARENT_COMPANY = new SelectList(db.COMPANYS, "COMPANY_ID", "COMPANY_NAME");
            return View();
        }

        // POST: HopLong/COMPANies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COMPANY_ID,COMPANY_NAME,PARENT_COMPANY,MANAGER,COMPANY_CATEGORY_ID,NOTED")] COMPANY cOMPANY)
        {
            if (ModelState.IsValid)
            {
                db.COMPANYS.Add(cOMPANY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COMPANY_CATEGORY_ID = new SelectList(db.COMPANY_CATEGORIES, "COMPANY_CATEGORY_ID", "COMPANY_CATEGORY_NAME", cOMPANY.COMPANY_CATEGORY_ID);
            ViewBag.MANAGER = new SelectList(db.USERS, "USER_ID", "USERNAME", cOMPANY.MANAGER);
            ViewBag.PARENT_COMPANY = new SelectList(db.COMPANYS, "COMPANY_ID", "COMPANY_NAME", cOMPANY.PARENT_COMPANY);
            return View(cOMPANY);
        }

        // GET: HopLong/COMPANies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY cOMPANY = db.COMPANYS.Find(id);
            if (cOMPANY == null)
            {
                return HttpNotFound();
            }
            ViewBag.COMPANY_CATEGORY_ID = new SelectList(db.COMPANY_CATEGORIES, "COMPANY_CATEGORY_ID", "COMPANY_CATEGORY_NAME", cOMPANY.COMPANY_CATEGORY_ID);
            ViewBag.MANAGER = new SelectList(db.USERS, "USER_ID", "USERNAME", cOMPANY.MANAGER);
            ViewBag.PARENT_COMPANY = new SelectList(db.COMPANYS, "COMPANY_ID", "COMPANY_NAME", cOMPANY.PARENT_COMPANY);
            return View(cOMPANY);
        }

        // POST: HopLong/COMPANies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMPANY_ID,COMPANY_NAME,PARENT_COMPANY,MANAGER,COMPANY_CATEGORY_ID,NOTED")] COMPANY cOMPANY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPANY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COMPANY_CATEGORY_ID = new SelectList(db.COMPANY_CATEGORIES, "COMPANY_CATEGORY_ID", "COMPANY_CATEGORY_NAME", cOMPANY.COMPANY_CATEGORY_ID);
            ViewBag.MANAGER = new SelectList(db.USERS, "USER_ID", "USERNAME", cOMPANY.MANAGER);
            ViewBag.PARENT_COMPANY = new SelectList(db.COMPANYS, "COMPANY_ID", "COMPANY_NAME", cOMPANY.PARENT_COMPANY);
            return View(cOMPANY);
        }

        // GET: HopLong/COMPANies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY cOMPANY = db.COMPANYS.Find(id);
            if (cOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY);
        }

        // POST: HopLong/COMPANies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COMPANY cOMPANY = db.COMPANYS.Find(id);
            db.COMPANYS.Remove(cOMPANY);
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

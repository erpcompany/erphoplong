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
    public class COMPANY_CATEGORIESController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: COMPANY_CATEGORIES
        public ActionResult Index()
        {
            return View(db.COMPANY_CATEGORIES.ToList());
        }
        public ActionResult Company_user (String Id)
        {
            var Company_Category = db.COMPANYS.Where(d=> d.COMPANY_CATEGORY_ID==Id);
            return View(Company_Category.ToList());
        }

        // GET: COMPANY_CATEGORIES/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY_CATEGORIES cOMPANY_CATEGORIES = db.COMPANY_CATEGORIES.Find(id);
            if (cOMPANY_CATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY_CATEGORIES);
        }

        // GET: COMPANY_CATEGORIES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: COMPANY_CATEGORIES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COMPANY_CATEGORY_ID,COMPANY_CATEGORY_NAME,NOTED")] COMPANY_CATEGORIES cOMPANY_CATEGORIES)
        {
            if (ModelState.IsValid)
            {
                db.COMPANY_CATEGORIES.Add(cOMPANY_CATEGORIES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOMPANY_CATEGORIES);
        }

        // GET: COMPANY_CATEGORIES/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY_CATEGORIES cOMPANY_CATEGORIES = db.COMPANY_CATEGORIES.Find(id);
            if (cOMPANY_CATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY_CATEGORIES);
        }

        // POST: COMPANY_CATEGORIES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMPANY_CATEGORY_ID,COMPANY_CATEGORY_NAME,NOTED")] COMPANY_CATEGORIES cOMPANY_CATEGORIES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPANY_CATEGORIES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOMPANY_CATEGORIES);
        }

        // GET: COMPANY_CATEGORIES/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY_CATEGORIES cOMPANY_CATEGORIES = db.COMPANY_CATEGORIES.Find(id);
            if (cOMPANY_CATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY_CATEGORIES);
        }

        // POST: COMPANY_CATEGORIES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COMPANY_CATEGORIES cOMPANY_CATEGORIES = db.COMPANY_CATEGORIES.Find(id);
            db.COMPANY_CATEGORIES.Remove(cOMPANY_CATEGORIES);
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

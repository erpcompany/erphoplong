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

namespace SYSTEM_MANAGEMENT.Areas.HopLong.Controllers
{
    [AuthorizeBussiness]
    public class PRODUCT_CATEGORY_DETAILSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/PRODUCT_CATEGORY_DETAILS
        public ActionResult Index()
        {
            var pRODUCT_CATEGORY_DETAILS = db.PRODUCT_CATEGORY_DETAILS.Include(p => p.PRODUCT_CATEGORIES);
            return View(pRODUCT_CATEGORY_DETAILS.ToList());
        }
        

        
        // GET: HopLong/PRODUCT_CATEGORY_DETAILS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_CATEGORY_DETAILS pRODUCT_CATEGORY_DETAILS = db.PRODUCT_CATEGORY_DETAILS.Find(id);
            if (pRODUCT_CATEGORY_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_CATEGORY_DETAILS);
        }

        // GET: HopLong/PRODUCT_CATEGORY_DETAILS/Create
        public ActionResult Create()
        {
            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG");
            return View();
        }

        // POST: HopLong/PRODUCT_CATEGORY_DETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_CHI_TIET_NHOM_HANG,MA_NHOM_HANG,MO_TA")] PRODUCT_CATEGORY_DETAILS pRODUCT_CATEGORY_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCT_CATEGORY_DETAILS.Add(pRODUCT_CATEGORY_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG", pRODUCT_CATEGORY_DETAILS.MA_NHOM_HANG);
            return View(pRODUCT_CATEGORY_DETAILS);
        }

        // GET: HopLong/PRODUCT_CATEGORY_DETAILS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_CATEGORY_DETAILS pRODUCT_CATEGORY_DETAILS = db.PRODUCT_CATEGORY_DETAILS.Find(id);
            if (pRODUCT_CATEGORY_DETAILS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG", pRODUCT_CATEGORY_DETAILS.MA_NHOM_HANG);
            return View(pRODUCT_CATEGORY_DETAILS);
        }

        // POST: HopLong/PRODUCT_CATEGORY_DETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_CHI_TIET_NHOM_HANG,MA_NHOM_HANG,MO_TA")] PRODUCT_CATEGORY_DETAILS pRODUCT_CATEGORY_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT_CATEGORY_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG", pRODUCT_CATEGORY_DETAILS.MA_NHOM_HANG);
            return View(pRODUCT_CATEGORY_DETAILS);
        }

        // GET: HopLong/PRODUCT_CATEGORY_DETAILS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_CATEGORY_DETAILS pRODUCT_CATEGORY_DETAILS = db.PRODUCT_CATEGORY_DETAILS.Find(id);
            if (pRODUCT_CATEGORY_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_CATEGORY_DETAILS);
        }

        // POST: HopLong/PRODUCT_CATEGORY_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCT_CATEGORY_DETAILS pRODUCT_CATEGORY_DETAILS = db.PRODUCT_CATEGORY_DETAILS.Find(id);
            db.PRODUCT_CATEGORY_DETAILS.Remove(pRODUCT_CATEGORY_DETAILS);
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

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
    public class PRODUCT_METAController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/PRODUCT_META
        public ActionResult Index()
        {
            var pRODUCT_META = db.PRODUCT_META.Include(p => p.PRODUCT);
            return View(pRODUCT_META.ToList());
        }

        // GET: HopLong/PRODUCT_META/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_META pRODUCT_META = db.PRODUCT_META.Find(id);
            if (pRODUCT_META == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_META);
        }

        // GET: HopLong/PRODUCT_META/Create
        public ActionResult Create()
        {
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP");
            return View();
        }

        // POST: HopLong/PRODUCT_META/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_HANG_HT,SL_1LOT,SL_1THUNG,SL_1PALLET,THE_TICH_BOX")] PRODUCT_META pRODUCT_META)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCT_META.Add(pRODUCT_META);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", pRODUCT_META.MA_HANG_HT);
            return View(pRODUCT_META);
        }

        // GET: HopLong/PRODUCT_META/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_META pRODUCT_META = db.PRODUCT_META.Find(id);
            if (pRODUCT_META == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", pRODUCT_META.MA_HANG_HT);
            return View(pRODUCT_META);
        }

        // POST: HopLong/PRODUCT_META/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_HANG_HT,SL_1LOT,SL_1THUNG,SL_1PALLET,THE_TICH_BOX")] PRODUCT_META pRODUCT_META)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT_META).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", pRODUCT_META.MA_HANG_HT);
            return View(pRODUCT_META);
        }

        // GET: HopLong/PRODUCT_META/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_META pRODUCT_META = db.PRODUCT_META.Find(id);
            if (pRODUCT_META == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_META);
        }

        // POST: HopLong/PRODUCT_META/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCT_META pRODUCT_META = db.PRODUCT_META.Find(id);
            db.PRODUCT_META.Remove(pRODUCT_META);
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

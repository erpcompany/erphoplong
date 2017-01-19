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
    public class BORROWING_PRODUCTSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/BORROWING_PRODUCTS
        public ActionResult Index()
        {
            var bORROWING_PRODUCTS = db.BORROWING_PRODUCTS.Include(b => b.PRODUCT);
            return View(bORROWING_PRODUCTS.ToList());
        }

        // GET: HopLong/BORROWING_PRODUCTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BORROWING_PRODUCTS bORROWING_PRODUCTS = db.BORROWING_PRODUCTS.Find(id);
            if (bORROWING_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            return View(bORROWING_PRODUCTS);
        }

        // GET: HopLong/BORROWING_PRODUCTS/Create
        public ActionResult Create()
        {
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP");
            return View();
        }

        // POST: HopLong/BORROWING_PRODUCTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HANG_MUON,MA_HANG_HT,KHO_MUON,NGAY_MUON,SL_MUON,MA_PHIEU_XUAT_KHO,TRANG_THAI,GHI_CHU")] BORROWING_PRODUCTS bORROWING_PRODUCTS)
        {
            if (ModelState.IsValid)
            {
                db.BORROWING_PRODUCTS.Add(bORROWING_PRODUCTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", bORROWING_PRODUCTS.MA_HANG_HT);
            return View(bORROWING_PRODUCTS);
        }

        // GET: HopLong/BORROWING_PRODUCTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BORROWING_PRODUCTS bORROWING_PRODUCTS = db.BORROWING_PRODUCTS.Find(id);
            if (bORROWING_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", bORROWING_PRODUCTS.MA_HANG_HT);
            return View(bORROWING_PRODUCTS);
        }

        // POST: HopLong/BORROWING_PRODUCTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HANG_MUON,MA_HANG_HT,KHO_MUON,NGAY_MUON,SL_MUON,MA_PHIEU_XUAT_KHO,TRANG_THAI,GHI_CHU")] BORROWING_PRODUCTS bORROWING_PRODUCTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bORROWING_PRODUCTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", bORROWING_PRODUCTS.MA_HANG_HT);
            return View(bORROWING_PRODUCTS);
        }

        // GET: HopLong/BORROWING_PRODUCTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BORROWING_PRODUCTS bORROWING_PRODUCTS = db.BORROWING_PRODUCTS.Find(id);
            if (bORROWING_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            return View(bORROWING_PRODUCTS);
        }

        // POST: HopLong/BORROWING_PRODUCTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BORROWING_PRODUCTS bORROWING_PRODUCTS = db.BORROWING_PRODUCTS.Find(id);
            db.BORROWING_PRODUCTS.Remove(bORROWING_PRODUCTS);
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

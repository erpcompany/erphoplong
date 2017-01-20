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
    public class TRANSFER_WAREHOUSE_PRODUCTSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/TRANSFER_WAREHOUSE_PRODUCTS
        public ActionResult Index()
        {
            var tRANSFER_WAREHOUSE_PRODUCTS = db.TRANSFER_WAREHOUSE_PRODUCTS.Include(t => t.PRODUCT).Include(t => t.Warehouse).Include(t => t.Warehouse1);
            return View(tRANSFER_WAREHOUSE_PRODUCTS.ToList());
        }

        // GET: HopLong/TRANSFER_WAREHOUSE_PRODUCTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSFER_WAREHOUSE_PRODUCTS tRANSFER_WAREHOUSE_PRODUCTS = db.TRANSFER_WAREHOUSE_PRODUCTS.Find(id);
            if (tRANSFER_WAREHOUSE_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            return View(tRANSFER_WAREHOUSE_PRODUCTS);
        }

        // GET: HopLong/TRANSFER_WAREHOUSE_PRODUCTS/Create
        public ActionResult Create()
        {
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP");
            ViewBag.KHO_DICH = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO");
            ViewBag.KHO_NGUON = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO");
            return View();
        }

        // POST: HopLong/TRANSFER_WAREHOUSE_PRODUCTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_KY_GUI,MA_HANG_HT,NGAY_KY_GUI,KHO_NGUON,SL_KY_GUI,KHO_DICH,TRANG_THAI,GHI_CHU")] TRANSFER_WAREHOUSE_PRODUCTS tRANSFER_WAREHOUSE_PRODUCTS)
        {
            if (ModelState.IsValid)
            {
                db.TRANSFER_WAREHOUSE_PRODUCTS.Add(tRANSFER_WAREHOUSE_PRODUCTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", tRANSFER_WAREHOUSE_PRODUCTS.MA_HANG_HT);
            ViewBag.KHO_DICH = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", tRANSFER_WAREHOUSE_PRODUCTS.KHO_DICH);
            ViewBag.KHO_NGUON = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", tRANSFER_WAREHOUSE_PRODUCTS.KHO_NGUON);
            return View(tRANSFER_WAREHOUSE_PRODUCTS);
        }

        // GET: HopLong/TRANSFER_WAREHOUSE_PRODUCTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSFER_WAREHOUSE_PRODUCTS tRANSFER_WAREHOUSE_PRODUCTS = db.TRANSFER_WAREHOUSE_PRODUCTS.Find(id);
            if (tRANSFER_WAREHOUSE_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", tRANSFER_WAREHOUSE_PRODUCTS.MA_HANG_HT);
            ViewBag.KHO_DICH = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", tRANSFER_WAREHOUSE_PRODUCTS.KHO_DICH);
            ViewBag.KHO_NGUON = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", tRANSFER_WAREHOUSE_PRODUCTS.KHO_NGUON);
            return View(tRANSFER_WAREHOUSE_PRODUCTS);
        }

        // POST: HopLong/TRANSFER_WAREHOUSE_PRODUCTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_KY_GUI,MA_HANG_HT,NGAY_KY_GUI,KHO_NGUON,SL_KY_GUI,KHO_DICH,TRANG_THAI,GHI_CHU")] TRANSFER_WAREHOUSE_PRODUCTS tRANSFER_WAREHOUSE_PRODUCTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRANSFER_WAREHOUSE_PRODUCTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", tRANSFER_WAREHOUSE_PRODUCTS.MA_HANG_HT);
            ViewBag.KHO_DICH = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", tRANSFER_WAREHOUSE_PRODUCTS.KHO_DICH);
            ViewBag.KHO_NGUON = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", tRANSFER_WAREHOUSE_PRODUCTS.KHO_NGUON);
            return View(tRANSFER_WAREHOUSE_PRODUCTS);
        }

        // GET: HopLong/TRANSFER_WAREHOUSE_PRODUCTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSFER_WAREHOUSE_PRODUCTS tRANSFER_WAREHOUSE_PRODUCTS = db.TRANSFER_WAREHOUSE_PRODUCTS.Find(id);
            if (tRANSFER_WAREHOUSE_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            return View(tRANSFER_WAREHOUSE_PRODUCTS);
        }

        // POST: HopLong/TRANSFER_WAREHOUSE_PRODUCTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRANSFER_WAREHOUSE_PRODUCTS tRANSFER_WAREHOUSE_PRODUCTS = db.TRANSFER_WAREHOUSE_PRODUCTS.Find(id);
            db.TRANSFER_WAREHOUSE_PRODUCTS.Remove(tRANSFER_WAREHOUSE_PRODUCTS);
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

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
    public class HOLD_PRODUCTSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/HOLD_PRODUCTS
        public ActionResult Index()
        {
            var hOLD_PRODUCTS = db.HOLD_PRODUCTS.Include(h => h.PRODUCT).Include(h => h.Warehouse);
            return View(hOLD_PRODUCTS.ToList());
        }

        // GET: HopLong/HOLD_PRODUCTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOLD_PRODUCTS hOLD_PRODUCTS = db.HOLD_PRODUCTS.Find(id);
            if (hOLD_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            return View(hOLD_PRODUCTS);
        }

        // GET: HopLong/HOLD_PRODUCTS/Create
        public ActionResult Create()
        {
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP");
            ViewBag.MA_KHO = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO");
            return View();
        }

        // POST: HopLong/HOLD_PRODUCTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_GIU_HANG,MA_HANG_HT,NGAY_GIU,TONG_SO_GIU,SL_GIU_DA_XUAT,SL_GIU_CHUA_XU_LY,TRANG_THAI,MA_KHO")] HOLD_PRODUCTS hOLD_PRODUCTS)
        {
            if (ModelState.IsValid)
            {
                db.HOLD_PRODUCTS.Add(hOLD_PRODUCTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", hOLD_PRODUCTS.MA_HANG_HT);
            ViewBag.MA_KHO = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", hOLD_PRODUCTS.MA_KHO);
            return View(hOLD_PRODUCTS);
        }

        // GET: HopLong/HOLD_PRODUCTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOLD_PRODUCTS hOLD_PRODUCTS = db.HOLD_PRODUCTS.Find(id);
            if (hOLD_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", hOLD_PRODUCTS.MA_HANG_HT);
            ViewBag.MA_KHO = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", hOLD_PRODUCTS.MA_KHO);
            return View(hOLD_PRODUCTS);
        }

        // POST: HopLong/HOLD_PRODUCTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_GIU_HANG,MA_HANG_HT,NGAY_GIU,TONG_SO_GIU,SL_GIU_DA_XUAT,SL_GIU_CHUA_XU_LY,TRANG_THAI,MA_KHO")] HOLD_PRODUCTS hOLD_PRODUCTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOLD_PRODUCTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", hOLD_PRODUCTS.MA_HANG_HT);
            ViewBag.MA_KHO = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", hOLD_PRODUCTS.MA_KHO);
            return View(hOLD_PRODUCTS);
        }

        // GET: HopLong/HOLD_PRODUCTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOLD_PRODUCTS hOLD_PRODUCTS = db.HOLD_PRODUCTS.Find(id);
            if (hOLD_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            return View(hOLD_PRODUCTS);
        }

        // POST: HopLong/HOLD_PRODUCTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOLD_PRODUCTS hOLD_PRODUCTS = db.HOLD_PRODUCTS.Find(id);
            db.HOLD_PRODUCTS.Remove(hOLD_PRODUCTS);
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

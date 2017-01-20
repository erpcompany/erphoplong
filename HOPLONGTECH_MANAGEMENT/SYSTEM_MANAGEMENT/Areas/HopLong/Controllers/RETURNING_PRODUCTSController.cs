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
    public class RETURNING_PRODUCTSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/RETURNING_PRODUCTS
        public ActionResult Index()
        {
            var rETURNING_PRODUCTS = db.RETURNING_PRODUCTS.Include(r => r.BORROWING_PRODUCTS).Include(r => r.Warehouse);
            return View(rETURNING_PRODUCTS.ToList());
        }

        // GET: HopLong/RETURNING_PRODUCTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RETURNING_PRODUCTS rETURNING_PRODUCTS = db.RETURNING_PRODUCTS.Find(id);
            if (rETURNING_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            return View(rETURNING_PRODUCTS);
        }

        // GET: HopLong/RETURNING_PRODUCTS/Create
        public ActionResult Create()
        {
            ViewBag.ID_HANG_MUON = new SelectList(db.BORROWING_PRODUCTS, "ID_HANG_MUON", "MA_HANG_HT");
            ViewBag.KHO_TRA = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO");
            return View();
        }

        // POST: HopLong/RETURNING_PRODUCTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HANG_TRA,ID_HANG_MUON,NGAY_TRA,SL_TRA,KHO_TRA,GHI_CHU")] RETURNING_PRODUCTS rETURNING_PRODUCTS)
        {
            if (ModelState.IsValid)
            {
                db.RETURNING_PRODUCTS.Add(rETURNING_PRODUCTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_HANG_MUON = new SelectList(db.BORROWING_PRODUCTS, "ID_HANG_MUON", "MA_HANG_HT", rETURNING_PRODUCTS.ID_HANG_MUON);
            ViewBag.KHO_TRA = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", rETURNING_PRODUCTS.KHO_TRA);
            return View(rETURNING_PRODUCTS);
        }

        // GET: HopLong/RETURNING_PRODUCTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RETURNING_PRODUCTS rETURNING_PRODUCTS = db.RETURNING_PRODUCTS.Find(id);
            if (rETURNING_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_HANG_MUON = new SelectList(db.BORROWING_PRODUCTS, "ID_HANG_MUON", "MA_HANG_HT", rETURNING_PRODUCTS.ID_HANG_MUON);
            ViewBag.KHO_TRA = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", rETURNING_PRODUCTS.KHO_TRA);
            return View(rETURNING_PRODUCTS);
        }

        // POST: HopLong/RETURNING_PRODUCTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HANG_TRA,ID_HANG_MUON,NGAY_TRA,SL_TRA,KHO_TRA,GHI_CHU")] RETURNING_PRODUCTS rETURNING_PRODUCTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rETURNING_PRODUCTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_HANG_MUON = new SelectList(db.BORROWING_PRODUCTS, "ID_HANG_MUON", "MA_HANG_HT", rETURNING_PRODUCTS.ID_HANG_MUON);
            ViewBag.KHO_TRA = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", rETURNING_PRODUCTS.KHO_TRA);
            return View(rETURNING_PRODUCTS);
        }

        // GET: HopLong/RETURNING_PRODUCTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RETURNING_PRODUCTS rETURNING_PRODUCTS = db.RETURNING_PRODUCTS.Find(id);
            if (rETURNING_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            return View(rETURNING_PRODUCTS);
        }

        // POST: HopLong/RETURNING_PRODUCTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RETURNING_PRODUCTS rETURNING_PRODUCTS = db.RETURNING_PRODUCTS.Find(id);
            db.RETURNING_PRODUCTS.Remove(rETURNING_PRODUCTS);
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

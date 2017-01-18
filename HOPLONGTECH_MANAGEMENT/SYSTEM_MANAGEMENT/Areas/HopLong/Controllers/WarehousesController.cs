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
    public class WarehousesController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/Warehouses
        public ActionResult Index()
        {
            return View(db.WAREHOUSES.ToList());
        }
        public ActionResult Sanphamkho(String Id)
        {
            var query = db.PRODUCTS.Where(d => d.MA_KHO == Id);
            return View(query.ToList());
        }

        // GET: HopLong/Warehouses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = db.WAREHOUSES.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // GET: HopLong/Warehouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HopLong/Warehouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_KHO,TEN_KHO,MO_TA")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                db.WAREHOUSES.Add(warehouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warehouse);
        }

        // GET: HopLong/Warehouses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = db.WAREHOUSES.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // POST: HopLong/Warehouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_KHO,TEN_KHO,MO_TA")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warehouse);
        }

        // GET: HopLong/Warehouses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = db.WAREHOUSES.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // POST: HopLong/Warehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Warehouse warehouse = db.WAREHOUSES.Find(id);
            db.WAREHOUSES.Remove(warehouse);
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

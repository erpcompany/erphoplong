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
    public class SUPPLIER_ACCOUNTSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/SUPPLIER_ACCOUNTS
        public ActionResult Index()
        {
            var sUPPLIER_ACCOUNTS = db.SUPPLIER_ACCOUNTS.Include(s => s.SUPPLIER);
            return View(sUPPLIER_ACCOUNTS.ToList());
        }

        // GET: HopLong/SUPPLIER_ACCOUNTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIER_ACCOUNTS sUPPLIER_ACCOUNTS = db.SUPPLIER_ACCOUNTS.Find(id);
            if (sUPPLIER_ACCOUNTS == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIER_ACCOUNTS);
        }

        // GET: HopLong/SUPPLIER_ACCOUNTS/Create
        public ActionResult Create()
        {
            ViewBag.MA_NCC = new SelectList(db.SUPPLIERS, "MA_NCC", "TEN_NCC");
            return View();
        }

        // POST: HopLong/SUPPLIER_ACCOUNTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TAI_KHOAN_NCC,MA_NCC,SO_TAI_KHOAN,TEN_NGAN_HANG,CHI_NHANH,TINH_TP")] SUPPLIER_ACCOUNTS sUPPLIER_ACCOUNTS)
        {
            if (ModelState.IsValid)
            {
                db.SUPPLIER_ACCOUNTS.Add(sUPPLIER_ACCOUNTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_NCC = new SelectList(db.SUPPLIERS, "MA_NCC", "TEN_NCC", sUPPLIER_ACCOUNTS.MA_NCC);
            return View(sUPPLIER_ACCOUNTS);
        }

        // GET: HopLong/SUPPLIER_ACCOUNTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIER_ACCOUNTS sUPPLIER_ACCOUNTS = db.SUPPLIER_ACCOUNTS.Find(id);
            if (sUPPLIER_ACCOUNTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_NCC = new SelectList(db.SUPPLIERS, "MA_NCC", "TEN_NCC", sUPPLIER_ACCOUNTS.MA_NCC);
            return View(sUPPLIER_ACCOUNTS);
        }

        // POST: HopLong/SUPPLIER_ACCOUNTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TAI_KHOAN_NCC,MA_NCC,SO_TAI_KHOAN,TEN_NGAN_HANG,CHI_NHANH,TINH_TP")] SUPPLIER_ACCOUNTS sUPPLIER_ACCOUNTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUPPLIER_ACCOUNTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_NCC = new SelectList(db.SUPPLIERS, "MA_NCC", "TEN_NCC", sUPPLIER_ACCOUNTS.MA_NCC);
            return View(sUPPLIER_ACCOUNTS);
        }

        // GET: HopLong/SUPPLIER_ACCOUNTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIER_ACCOUNTS sUPPLIER_ACCOUNTS = db.SUPPLIER_ACCOUNTS.Find(id);
            if (sUPPLIER_ACCOUNTS == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIER_ACCOUNTS);
        }

        // POST: HopLong/SUPPLIER_ACCOUNTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUPPLIER_ACCOUNTS sUPPLIER_ACCOUNTS = db.SUPPLIER_ACCOUNTS.Find(id);
            db.SUPPLIER_ACCOUNTS.Remove(sUPPLIER_ACCOUNTS);
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

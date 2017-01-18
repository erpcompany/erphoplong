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
    public class CUSTOMER_ACCOUNTSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/CUSTOMER_ACCOUNTS
        public ActionResult Index()
        {
            var cUSTOMER_ACCOUNTS = db.CUSTOMER_ACCOUNTS.Include(c => c.CUSTOMER);
            return View(cUSTOMER_ACCOUNTS.ToList());
        }

        // GET: HopLong/CUSTOMER_ACCOUNTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_ACCOUNTS cUSTOMER_ACCOUNTS = db.CUSTOMER_ACCOUNTS.Find(id);
            if (cUSTOMER_ACCOUNTS == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_ACCOUNTS);
        }

        // GET: HopLong/CUSTOMER_ACCOUNTS/Create
        public ActionResult Create()
        {
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG");
            return View();
        }

        // POST: HopLong/CUSTOMER_ACCOUNTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TAI_KHOAN_KH,MA_KHACH_HANG,SO_TAI_KHOAN,TEN_NGAN_HANG,CHI_NHANH,TINH_TP")] CUSTOMER_ACCOUNTS cUSTOMER_ACCOUNTS)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMER_ACCOUNTS.Add(cUSTOMER_ACCOUNTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", cUSTOMER_ACCOUNTS.MA_KHACH_HANG);
            return View(cUSTOMER_ACCOUNTS);
        }

        // GET: HopLong/CUSTOMER_ACCOUNTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_ACCOUNTS cUSTOMER_ACCOUNTS = db.CUSTOMER_ACCOUNTS.Find(id);
            if (cUSTOMER_ACCOUNTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", cUSTOMER_ACCOUNTS.MA_KHACH_HANG);
            return View(cUSTOMER_ACCOUNTS);
        }

        // POST: HopLong/CUSTOMER_ACCOUNTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TAI_KHOAN_KH,MA_KHACH_HANG,SO_TAI_KHOAN,TEN_NGAN_HANG,CHI_NHANH,TINH_TP")] CUSTOMER_ACCOUNTS cUSTOMER_ACCOUNTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER_ACCOUNTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", cUSTOMER_ACCOUNTS.MA_KHACH_HANG);
            return View(cUSTOMER_ACCOUNTS);
        }

        // GET: HopLong/CUSTOMER_ACCOUNTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_ACCOUNTS cUSTOMER_ACCOUNTS = db.CUSTOMER_ACCOUNTS.Find(id);
            if (cUSTOMER_ACCOUNTS == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_ACCOUNTS);
        }

        // POST: HopLong/CUSTOMER_ACCOUNTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMER_ACCOUNTS cUSTOMER_ACCOUNTS = db.CUSTOMER_ACCOUNTS.Find(id);
            db.CUSTOMER_ACCOUNTS.Remove(cUSTOMER_ACCOUNTS);
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

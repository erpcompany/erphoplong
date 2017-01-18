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
    public class CUSTOMERsController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/CUSTOMERs
        public ActionResult Index()
        {
            var cUSTOMERS = db.CUSTOMERS.Include(c => c.CUSTOMER_GROUPS).Include(c => c.USER);
            return View(cUSTOMERS.ToList());
        }

        // GET: HopLong/CUSTOMERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERS.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // GET: HopLong/CUSTOMERs/Create
        public ActionResult Create()
        {
            ViewBag.MA_NHOM_KHACH = new SelectList(db.CUSTOMER_GROUPS, "MA_NHOM_KHACH", "TEN_NHOM_KHACH");
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME");
            return View();
        }

        // POST: HopLong/CUSTOMERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_KHACH_HANG,TEN_KHACH_HANG,DIA_CHI_CONG_TY,DIA_CHI_XUAT_HOA_DON,MA_NHOM_KHACH,MST,DIEN_THOAI,FAX,EMAIL,WEBSITE,USER_ID,MO_TA")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMERS.Add(cUSTOMER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_NHOM_KHACH = new SelectList(db.CUSTOMER_GROUPS, "MA_NHOM_KHACH", "TEN_NHOM_KHACH", cUSTOMER.MA_NHOM_KHACH);
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", cUSTOMER.USER_ID);
            return View(cUSTOMER);
        }

        // GET: HopLong/CUSTOMERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERS.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_NHOM_KHACH = new SelectList(db.CUSTOMER_GROUPS, "MA_NHOM_KHACH", "TEN_NHOM_KHACH", cUSTOMER.MA_NHOM_KHACH);
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", cUSTOMER.USER_ID);
            return View(cUSTOMER);
        }

        // POST: HopLong/CUSTOMERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_KHACH_HANG,TEN_KHACH_HANG,DIA_CHI_CONG_TY,DIA_CHI_XUAT_HOA_DON,MA_NHOM_KHACH,MST,DIEN_THOAI,FAX,EMAIL,WEBSITE,USER_ID,MO_TA")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_NHOM_KHACH = new SelectList(db.CUSTOMER_GROUPS, "MA_NHOM_KHACH", "TEN_NHOM_KHACH", cUSTOMER.MA_NHOM_KHACH);
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", cUSTOMER.USER_ID);
            return View(cUSTOMER);
        }

        // GET: HopLong/CUSTOMERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERS.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: HopLong/CUSTOMERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CUSTOMER cUSTOMER = db.CUSTOMERS.Find(id);
            db.CUSTOMERS.Remove(cUSTOMER);
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

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
    public class SUPPLIERsController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/SUPPLIERs
        public ActionResult Index(String Id)
        {
            var sUPPLIERS = db.SUPPLIERS.Where(d=>d.MA_NHOM_HANG==Id);
            return View(sUPPLIERS.ToList());
        }

        // GET: HopLong/SUPPLIERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIER sUPPLIER = db.SUPPLIERS.Find(id);
            if (sUPPLIER == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIER);
        }

        // GET: HopLong/SUPPLIERs/Create
        public ActionResult Create()
        {
            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG");
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME");
            return View();
        }

        // POST: HopLong/SUPPLIERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_NCC,TEN_NCC,DIA_CHI,SDT,EMAIL,FAX,MST,MA_NHOM_HANG,WEBSITE,USER_ID,MO_TA")] SUPPLIER sUPPLIER)
        {
            if (ModelState.IsValid)
            {
                db.SUPPLIERS.Add(sUPPLIER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG", sUPPLIER.MA_NHOM_HANG);
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", sUPPLIER.USER_ID);
            return View(sUPPLIER);
        }

        // GET: HopLong/SUPPLIERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIER sUPPLIER = db.SUPPLIERS.Find(id);
            if (sUPPLIER == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG", sUPPLIER.MA_NHOM_HANG);
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", sUPPLIER.USER_ID);
            return View(sUPPLIER);
        }

        // POST: HopLong/SUPPLIERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_NCC,TEN_NCC,DIA_CHI,SDT,EMAIL,FAX,MST,MA_NHOM_HANG,WEBSITE,USER_ID,MO_TA")] SUPPLIER sUPPLIER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUPPLIER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG", sUPPLIER.MA_NHOM_HANG);
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", sUPPLIER.USER_ID);
            return View(sUPPLIER);
        }

        // GET: HopLong/SUPPLIERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIER sUPPLIER = db.SUPPLIERS.Find(id);
            if (sUPPLIER == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIER);
        }

        // POST: HopLong/SUPPLIERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SUPPLIER sUPPLIER = db.SUPPLIERS.Find(id);
            db.SUPPLIERS.Remove(sUPPLIER);
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

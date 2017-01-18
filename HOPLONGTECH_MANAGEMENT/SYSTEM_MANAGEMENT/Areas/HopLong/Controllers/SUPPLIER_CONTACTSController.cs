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
    public class SUPPLIER_CONTACTSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/SUPPLIER_CONTACTS
        public ActionResult Index()
        {
            var sUPPLIER_CONTACTS = db.SUPPLIER_CONTACTS.Include(s => s.SUPPLIER);
            return View(sUPPLIER_CONTACTS.ToList());
        }

        // GET: HopLong/SUPPLIER_CONTACTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIER_CONTACTS sUPPLIER_CONTACTS = db.SUPPLIER_CONTACTS.Find(id);
            if (sUPPLIER_CONTACTS == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIER_CONTACTS);
        }

        // GET: HopLong/SUPPLIER_CONTACTS/Create
        public ActionResult Create()
        {
            ViewBag.MA_NCC = new SelectList(db.SUPPLIERS, "MA_NCC", "TEN_NCC");
            return View();
        }

        // POST: HopLong/SUPPLIER_CONTACTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LIEN_HE_NCC,MA_NCC,NGUOI_LIEN_HE,NGAY_SINH,GIOI_TINH,CHUC_VU,SO_DIEN_THOAI,EMAIL,FACEBOOK,SKYPE,GHI_CHU")] SUPPLIER_CONTACTS sUPPLIER_CONTACTS)
        {
            if (ModelState.IsValid)
            {
                db.SUPPLIER_CONTACTS.Add(sUPPLIER_CONTACTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_NCC = new SelectList(db.SUPPLIERS, "MA_NCC", "TEN_NCC", sUPPLIER_CONTACTS.MA_NCC);
            return View(sUPPLIER_CONTACTS);
        }

        // GET: HopLong/SUPPLIER_CONTACTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIER_CONTACTS sUPPLIER_CONTACTS = db.SUPPLIER_CONTACTS.Find(id);
            if (sUPPLIER_CONTACTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_NCC = new SelectList(db.SUPPLIERS, "MA_NCC", "TEN_NCC", sUPPLIER_CONTACTS.MA_NCC);
            return View(sUPPLIER_CONTACTS);
        }

        // POST: HopLong/SUPPLIER_CONTACTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LIEN_HE_NCC,MA_NCC,NGUOI_LIEN_HE,NGAY_SINH,GIOI_TINH,CHUC_VU,SO_DIEN_THOAI,EMAIL,FACEBOOK,SKYPE,GHI_CHU")] SUPPLIER_CONTACTS sUPPLIER_CONTACTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUPPLIER_CONTACTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_NCC = new SelectList(db.SUPPLIERS, "MA_NCC", "TEN_NCC", sUPPLIER_CONTACTS.MA_NCC);
            return View(sUPPLIER_CONTACTS);
        }

        // GET: HopLong/SUPPLIER_CONTACTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIER_CONTACTS sUPPLIER_CONTACTS = db.SUPPLIER_CONTACTS.Find(id);
            if (sUPPLIER_CONTACTS == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIER_CONTACTS);
        }

        // POST: HopLong/SUPPLIER_CONTACTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUPPLIER_CONTACTS sUPPLIER_CONTACTS = db.SUPPLIER_CONTACTS.Find(id);
            db.SUPPLIER_CONTACTS.Remove(sUPPLIER_CONTACTS);
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

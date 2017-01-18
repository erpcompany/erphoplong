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
    public class CUSTOMER_CONTACTSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/CUSTOMER_CONTACTS
        public ActionResult Index()
        {
            var cUSTOMER_CONTACTS = db.CUSTOMER_CONTACTS.Include(c => c.CUSTOMER);
            return View(cUSTOMER_CONTACTS.ToList());
        }

        // GET: HopLong/CUSTOMER_CONTACTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_CONTACTS cUSTOMER_CONTACTS = db.CUSTOMER_CONTACTS.Find(id);
            if (cUSTOMER_CONTACTS == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_CONTACTS);
        }

        // GET: HopLong/CUSTOMER_CONTACTS/Create
        public ActionResult Create()
        {
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG");
            return View();
        }

        // POST: HopLong/CUSTOMER_CONTACTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LIEN_HE_KH,MA_KHACH_HANG,NGUOI_LIEN_HE,NGAY_SINH,GIOI_TINH,CHUC_VU,SO_DIEN_THOAI,EMAIL,FACEBOOK,SKYPE,GHI_CHU")] CUSTOMER_CONTACTS cUSTOMER_CONTACTS)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMER_CONTACTS.Add(cUSTOMER_CONTACTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", cUSTOMER_CONTACTS.MA_KHACH_HANG);
            return View(cUSTOMER_CONTACTS);
        }

        // GET: HopLong/CUSTOMER_CONTACTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_CONTACTS cUSTOMER_CONTACTS = db.CUSTOMER_CONTACTS.Find(id);
            if (cUSTOMER_CONTACTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", cUSTOMER_CONTACTS.MA_KHACH_HANG);
            return View(cUSTOMER_CONTACTS);
        }

        // POST: HopLong/CUSTOMER_CONTACTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LIEN_HE_KH,MA_KHACH_HANG,NGUOI_LIEN_HE,NGAY_SINH,GIOI_TINH,CHUC_VU,SO_DIEN_THOAI,EMAIL,FACEBOOK,SKYPE,GHI_CHU")] CUSTOMER_CONTACTS cUSTOMER_CONTACTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER_CONTACTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", cUSTOMER_CONTACTS.MA_KHACH_HANG);
            return View(cUSTOMER_CONTACTS);
        }

        // GET: HopLong/CUSTOMER_CONTACTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_CONTACTS cUSTOMER_CONTACTS = db.CUSTOMER_CONTACTS.Find(id);
            if (cUSTOMER_CONTACTS == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_CONTACTS);
        }

        // POST: HopLong/CUSTOMER_CONTACTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMER_CONTACTS cUSTOMER_CONTACTS = db.CUSTOMER_CONTACTS.Find(id);
            db.CUSTOMER_CONTACTS.Remove(cUSTOMER_CONTACTS);
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

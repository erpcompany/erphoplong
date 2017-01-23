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
    public class PAYMENT_TERMSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/PAYMENT_TERMS
        public ActionResult Index()
        {
            return View(db.PAYMENT_TERMS.ToList());
        }

        // GET: HopLong/PAYMENT_TERMS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT_TERMS pAYMENT_TERMS = db.PAYMENT_TERMS.Find(id);
            if (pAYMENT_TERMS == null)
            {
                return HttpNotFound();
            }
            return View(pAYMENT_TERMS);
        }

        // GET: HopLong/PAYMENT_TERMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HopLong/PAYMENT_TERMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_DIEU_KHOAN,TEN_DIEU_KHOAN,NOI_DUNG_DIEU_KHOAN,GHI_CHU")] PAYMENT_TERMS pAYMENT_TERMS)
        {
            if (ModelState.IsValid)
            {
                db.PAYMENT_TERMS.Add(pAYMENT_TERMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAYMENT_TERMS);
        }

        // GET: HopLong/PAYMENT_TERMS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT_TERMS pAYMENT_TERMS = db.PAYMENT_TERMS.Find(id);
            if (pAYMENT_TERMS == null)
            {
                return HttpNotFound();
            }
            return View(pAYMENT_TERMS);
        }

        // POST: HopLong/PAYMENT_TERMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_DIEU_KHOAN,TEN_DIEU_KHOAN,NOI_DUNG_DIEU_KHOAN,GHI_CHU")] PAYMENT_TERMS pAYMENT_TERMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAYMENT_TERMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAYMENT_TERMS);
        }

        // GET: HopLong/PAYMENT_TERMS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT_TERMS pAYMENT_TERMS = db.PAYMENT_TERMS.Find(id);
            if (pAYMENT_TERMS == null)
            {
                return HttpNotFound();
            }
            return View(pAYMENT_TERMS);
        }

        // POST: HopLong/PAYMENT_TERMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PAYMENT_TERMS pAYMENT_TERMS = db.PAYMENT_TERMS.Find(id);
            db.PAYMENT_TERMS.Remove(pAYMENT_TERMS);
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

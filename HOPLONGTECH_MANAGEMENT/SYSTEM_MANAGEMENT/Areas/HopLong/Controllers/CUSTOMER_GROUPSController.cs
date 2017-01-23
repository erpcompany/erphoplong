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
    public class CUSTOMER_GROUPSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/CUSTOMER_GROUPS
        public ActionResult Index()
        {
            return View(db.CUSTOMER_GROUPS.ToList());
        }

        // GET: HopLong/CUSTOMER_GROUPS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_GROUPS cUSTOMER_GROUPS = db.CUSTOMER_GROUPS.Find(id);
            if (cUSTOMER_GROUPS == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_GROUPS);
        }

        // GET: HopLong/CUSTOMER_GROUPS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HopLong/CUSTOMER_GROUPS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_NHOM_KHACH,TEN_NHOM_KHACH,MO_TA")] CUSTOMER_GROUPS cUSTOMER_GROUPS)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMER_GROUPS.Add(cUSTOMER_GROUPS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUSTOMER_GROUPS);
        }

        // GET: HopLong/CUSTOMER_GROUPS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_GROUPS cUSTOMER_GROUPS = db.CUSTOMER_GROUPS.Find(id);
            if (cUSTOMER_GROUPS == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_GROUPS);
        }

        // POST: HopLong/CUSTOMER_GROUPS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_NHOM_KHACH,TEN_NHOM_KHACH,MO_TA")] CUSTOMER_GROUPS cUSTOMER_GROUPS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER_GROUPS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUSTOMER_GROUPS);
        }

        // GET: HopLong/CUSTOMER_GROUPS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_GROUPS cUSTOMER_GROUPS = db.CUSTOMER_GROUPS.Find(id);
            if (cUSTOMER_GROUPS == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_GROUPS);
        }

        // POST: HopLong/CUSTOMER_GROUPS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CUSTOMER_GROUPS cUSTOMER_GROUPS = db.CUSTOMER_GROUPS.Find(id);
            db.CUSTOMER_GROUPS.Remove(cUSTOMER_GROUPS);
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

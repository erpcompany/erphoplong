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
    public class PRODUCT_CATEGORIESController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/PRODUCT_CATEGORIES
        public ActionResult Index()
        {
            var PRODUCT_CATEGORIES = db.PRODUCT_CATEGORIES.Include(d => d.PRODUCT_CATEGORY_DETAILS);
            return View(PRODUCT_CATEGORIES.ToList());
        }

        public ActionResult list_product_category_details(string id)
        {
          
             var product_category_details = (from u in db.PRODUCT_CATEGORY_DETAILS
                                             where u.MA_NHOM_HANG == id
                                             select u);
            if (product_category_details == null)
            {
                return HttpNotFound();
            }

            return View(product_category_details.ToList());
        }

        // GET: HopLong/PRODUCT_CATEGORIES/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_CATEGORIES pRODUCT_CATEGORIES = db.PRODUCT_CATEGORIES.Find(id);
            if (pRODUCT_CATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_CATEGORIES);
        }

        // GET: HopLong/PRODUCT_CATEGORIES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HopLong/PRODUCT_CATEGORIES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_NHOM_HANG,TEN_NHOM_HANG,MO_TA")] PRODUCT_CATEGORIES pRODUCT_CATEGORIES)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCT_CATEGORIES.Add(pRODUCT_CATEGORIES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRODUCT_CATEGORIES);
        }

        // GET: HopLong/PRODUCT_CATEGORIES/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_CATEGORIES pRODUCT_CATEGORIES = db.PRODUCT_CATEGORIES.Find(id);
            if (pRODUCT_CATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_CATEGORIES);
        }

        // POST: HopLong/PRODUCT_CATEGORIES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_NHOM_HANG,TEN_NHOM_HANG,MO_TA")] PRODUCT_CATEGORIES pRODUCT_CATEGORIES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT_CATEGORIES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRODUCT_CATEGORIES);
        }

        // GET: HopLong/PRODUCT_CATEGORIES/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_CATEGORIES pRODUCT_CATEGORIES = db.PRODUCT_CATEGORIES.Find(id);
            if (pRODUCT_CATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_CATEGORIES);
        }

        // POST: HopLong/PRODUCT_CATEGORIES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCT_CATEGORIES pRODUCT_CATEGORIES = db.PRODUCT_CATEGORIES.Find(id);
            db.PRODUCT_CATEGORIES.Remove(pRODUCT_CATEGORIES);
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

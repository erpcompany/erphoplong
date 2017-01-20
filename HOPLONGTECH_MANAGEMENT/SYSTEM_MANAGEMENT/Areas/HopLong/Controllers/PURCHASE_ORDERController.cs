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
    public class PURCHASE_ORDERController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/PURCHASE_ORDER
        public ActionResult Index()
        {
            var pURCHASE_ORDER = db.PURCHASE_ORDER.Include(p => p.PRODUCT_CATEGORIES).Include(p => p.PRODUCT).Include(p => p.USER);
            return View(pURCHASE_ORDER.ToList());
        }

        // GET: HopLong/PURCHASE_ORDER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PURCHASE_ORDER pURCHASE_ORDER = db.PURCHASE_ORDER.Find(id);
            if (pURCHASE_ORDER == null)
            {
                return HttpNotFound();
            }
            return View(pURCHASE_ORDER);
        }

        // GET: HopLong/PURCHASE_ORDER/Create
        public ActionResult Create()
        {
            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG");
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP");
            ViewBag.KINH_DOANH_BAN = new SelectList(db.USERS, "USER_ID", "USERNAME");
            return View();
        }

        // POST: HopLong/PURCHASE_ORDER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NGAY_ORDER,THOI_GIAN_YEU_CAU_CUA_KINH_DOANH,MA_HANG_HT,TINH_TRANG,GIA_BAN,GIA_NHAP,CHENH_LECH,MA_NHOM_HANG,SL_NHAP,SL_THUC_NHAN,NGAY_HANG_VE,KINH_DOANH_BAN,GHI_CHU")] PURCHASE_ORDER pURCHASE_ORDER)
        {
            if (ModelState.IsValid)
            {
                db.PURCHASE_ORDER.Add(pURCHASE_ORDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG", pURCHASE_ORDER.MA_NHOM_HANG);
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", pURCHASE_ORDER.MA_HANG_HT);
            ViewBag.KINH_DOANH_BAN = new SelectList(db.USERS, "USER_ID", "USERNAME", pURCHASE_ORDER.KINH_DOANH_BAN);
            return View(pURCHASE_ORDER);
        }

        // GET: HopLong/PURCHASE_ORDER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PURCHASE_ORDER pURCHASE_ORDER = db.PURCHASE_ORDER.Find(id);
            if (pURCHASE_ORDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG", pURCHASE_ORDER.MA_NHOM_HANG);
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", pURCHASE_ORDER.MA_HANG_HT);
            ViewBag.KINH_DOANH_BAN = new SelectList(db.USERS, "USER_ID", "USERNAME", pURCHASE_ORDER.KINH_DOANH_BAN);
            return View(pURCHASE_ORDER);
        }

        // POST: HopLong/PURCHASE_ORDER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NGAY_ORDER,THOI_GIAN_YEU_CAU_CUA_KINH_DOANH,MA_HANG_HT,TINH_TRANG,GIA_BAN,GIA_NHAP,CHENH_LECH,MA_NHOM_HANG,SL_NHAP,SL_THUC_NHAN,NGAY_HANG_VE,KINH_DOANH_BAN,GHI_CHU")] PURCHASE_ORDER pURCHASE_ORDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pURCHASE_ORDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORIES, "MA_NHOM_HANG", "TEN_NHOM_HANG", pURCHASE_ORDER.MA_NHOM_HANG);
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCTS, "MA_HANG_HT", "MA_HANG_NHAP", pURCHASE_ORDER.MA_HANG_HT);
            ViewBag.KINH_DOANH_BAN = new SelectList(db.USERS, "USER_ID", "USERNAME", pURCHASE_ORDER.KINH_DOANH_BAN);
            return View(pURCHASE_ORDER);
        }

        // GET: HopLong/PURCHASE_ORDER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PURCHASE_ORDER pURCHASE_ORDER = db.PURCHASE_ORDER.Find(id);
            if (pURCHASE_ORDER == null)
            {
                return HttpNotFound();
            }
            return View(pURCHASE_ORDER);
        }

        // POST: HopLong/PURCHASE_ORDER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PURCHASE_ORDER pURCHASE_ORDER = db.PURCHASE_ORDER.Find(id);
            db.PURCHASE_ORDER.Remove(pURCHASE_ORDER);
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

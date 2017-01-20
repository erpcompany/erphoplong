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
    public class HOLD_PRODUCT_DETAILSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/HOLD_PRODUCT_DETAILS
        public ActionResult Index()
        {
            var hOLD_PRODUCT_DETAILS = db.HOLD_PRODUCT_DETAILS.Include(h => h.CUSTOMER).Include(h => h.HOLD_PRODUCTS).Include(h => h.USER);
            return View(hOLD_PRODUCT_DETAILS.ToList());
        }

        // GET: HopLong/HOLD_PRODUCT_DETAILS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOLD_PRODUCT_DETAILS hOLD_PRODUCT_DETAILS = db.HOLD_PRODUCT_DETAILS.Find(id);
            if (hOLD_PRODUCT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(hOLD_PRODUCT_DETAILS);
        }

        // GET: HopLong/HOLD_PRODUCT_DETAILS/Create
        public ActionResult Create()
        {
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG");
            ViewBag.ID_GIU_HANG = new SelectList(db.HOLD_PRODUCTS, "ID_GIU_HANG", "MA_HANG_HT");
            ViewBag.NHAN_VIEN_GIU = new SelectList(db.USERS, "USER_ID", "USERNAME");
            return View();
        }

        // POST: HopLong/HOLD_PRODUCT_DETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_GIU_HANG,NHAN_VIEN_GIU,MA_KHACH_HANG,SL_GIU,LOAI_GIU,TRANG_THAI,MA_PHIEU_XUAT_KHO,MA_KHACH_XUAT_KHO,SL_XUAT_KHO,GHI_CHU")] HOLD_PRODUCT_DETAILS hOLD_PRODUCT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.HOLD_PRODUCT_DETAILS.Add(hOLD_PRODUCT_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", hOLD_PRODUCT_DETAILS.MA_KHACH_HANG);
            ViewBag.ID_GIU_HANG = new SelectList(db.HOLD_PRODUCTS, "ID_GIU_HANG", "MA_HANG_HT", hOLD_PRODUCT_DETAILS.ID_GIU_HANG);
            ViewBag.NHAN_VIEN_GIU = new SelectList(db.USERS, "USER_ID", "USERNAME", hOLD_PRODUCT_DETAILS.NHAN_VIEN_GIU);
            return View(hOLD_PRODUCT_DETAILS);
        }

        // GET: HopLong/HOLD_PRODUCT_DETAILS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOLD_PRODUCT_DETAILS hOLD_PRODUCT_DETAILS = db.HOLD_PRODUCT_DETAILS.Find(id);
            if (hOLD_PRODUCT_DETAILS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", hOLD_PRODUCT_DETAILS.MA_KHACH_HANG);
            ViewBag.ID_GIU_HANG = new SelectList(db.HOLD_PRODUCTS, "ID_GIU_HANG", "MA_HANG_HT", hOLD_PRODUCT_DETAILS.ID_GIU_HANG);
            ViewBag.NHAN_VIEN_GIU = new SelectList(db.USERS, "USER_ID", "USERNAME", hOLD_PRODUCT_DETAILS.NHAN_VIEN_GIU);
            return View(hOLD_PRODUCT_DETAILS);
        }

        // POST: HopLong/HOLD_PRODUCT_DETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_GIU_HANG,NHAN_VIEN_GIU,MA_KHACH_HANG,SL_GIU,LOAI_GIU,TRANG_THAI,MA_PHIEU_XUAT_KHO,MA_KHACH_XUAT_KHO,SL_XUAT_KHO,GHI_CHU")] HOLD_PRODUCT_DETAILS hOLD_PRODUCT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOLD_PRODUCT_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", hOLD_PRODUCT_DETAILS.MA_KHACH_HANG);
            ViewBag.ID_GIU_HANG = new SelectList(db.HOLD_PRODUCTS, "ID_GIU_HANG", "MA_HANG_HT", hOLD_PRODUCT_DETAILS.ID_GIU_HANG);
            ViewBag.NHAN_VIEN_GIU = new SelectList(db.USERS, "USER_ID", "USERNAME", hOLD_PRODUCT_DETAILS.NHAN_VIEN_GIU);
            return View(hOLD_PRODUCT_DETAILS);
        }

        // GET: HopLong/HOLD_PRODUCT_DETAILS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOLD_PRODUCT_DETAILS hOLD_PRODUCT_DETAILS = db.HOLD_PRODUCT_DETAILS.Find(id);
            if (hOLD_PRODUCT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(hOLD_PRODUCT_DETAILS);
        }

        // POST: HopLong/HOLD_PRODUCT_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOLD_PRODUCT_DETAILS hOLD_PRODUCT_DETAILS = db.HOLD_PRODUCT_DETAILS.Find(id);
            db.HOLD_PRODUCT_DETAILS.Remove(hOLD_PRODUCT_DETAILS);
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

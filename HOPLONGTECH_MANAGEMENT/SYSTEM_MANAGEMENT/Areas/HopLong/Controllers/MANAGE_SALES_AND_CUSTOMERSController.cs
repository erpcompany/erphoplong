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
    public class MANAGE_SALES_AND_CUSTOMERSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/MANAGE_SALES_AND_CUSTOMERS
        public ActionResult Index()
        {
            var mANAGE_SALES_AND_CUSTOMERS = db.MANAGE_SALES_AND_CUSTOMERS.Include(m => m.CUSTOMER).Include(m => m.USER);
            return View(mANAGE_SALES_AND_CUSTOMERS.ToList());
        }

        // GET: HopLong/MANAGE_SALES_AND_CUSTOMERS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MANAGE_SALES_AND_CUSTOMERS mANAGE_SALES_AND_CUSTOMERS = db.MANAGE_SALES_AND_CUSTOMERS.Find(id);
            if (mANAGE_SALES_AND_CUSTOMERS == null)
            {
                return HttpNotFound();
            }
            return View(mANAGE_SALES_AND_CUSTOMERS);
        }

        // GET: HopLong/MANAGE_SALES_AND_CUSTOMERS/Create
        public ActionResult Create()
        {
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG");
            ViewBag.NHAN_VIEN_PHU_TRACH = new SelectList(db.USERS, "USER_ID", "USERNAME");
            return View();
        }

        // POST: HopLong/MANAGE_SALES_AND_CUSTOMERS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_QUAN_LY,MA_KHACH_HANG,NHAN_VIEN_PHU_TRACH,NGAY_BAT_DAU_PHU_TRACH,NGAY_NGUNG_PHU_TRACH,LY_DO_NGUNG_PHU_TRACH,GHI_CHU")] MANAGE_SALES_AND_CUSTOMERS mANAGE_SALES_AND_CUSTOMERS)
        {
            if (ModelState.IsValid)
            {
                db.MANAGE_SALES_AND_CUSTOMERS.Add(mANAGE_SALES_AND_CUSTOMERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", mANAGE_SALES_AND_CUSTOMERS.MA_KHACH_HANG);
            ViewBag.NHAN_VIEN_PHU_TRACH = new SelectList(db.USERS, "USER_ID", "USERNAME", mANAGE_SALES_AND_CUSTOMERS.NHAN_VIEN_PHU_TRACH);
            return View(mANAGE_SALES_AND_CUSTOMERS);
        }

        // GET: HopLong/MANAGE_SALES_AND_CUSTOMERS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MANAGE_SALES_AND_CUSTOMERS mANAGE_SALES_AND_CUSTOMERS = db.MANAGE_SALES_AND_CUSTOMERS.Find(id);
            if (mANAGE_SALES_AND_CUSTOMERS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", mANAGE_SALES_AND_CUSTOMERS.MA_KHACH_HANG);
            ViewBag.NHAN_VIEN_PHU_TRACH = new SelectList(db.USERS, "USER_ID", "USERNAME", mANAGE_SALES_AND_CUSTOMERS.NHAN_VIEN_PHU_TRACH);
            return View(mANAGE_SALES_AND_CUSTOMERS);
        }

        // POST: HopLong/MANAGE_SALES_AND_CUSTOMERS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_QUAN_LY,MA_KHACH_HANG,NHAN_VIEN_PHU_TRACH,NGAY_BAT_DAU_PHU_TRACH,NGAY_NGUNG_PHU_TRACH,LY_DO_NGUNG_PHU_TRACH,GHI_CHU")] MANAGE_SALES_AND_CUSTOMERS mANAGE_SALES_AND_CUSTOMERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mANAGE_SALES_AND_CUSTOMERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_KHACH_HANG = new SelectList(db.CUSTOMERS, "MA_KHACH_HANG", "TEN_KHACH_HANG", mANAGE_SALES_AND_CUSTOMERS.MA_KHACH_HANG);
            ViewBag.NHAN_VIEN_PHU_TRACH = new SelectList(db.USERS, "USER_ID", "USERNAME", mANAGE_SALES_AND_CUSTOMERS.NHAN_VIEN_PHU_TRACH);
            return View(mANAGE_SALES_AND_CUSTOMERS);
        }

        // GET: HopLong/MANAGE_SALES_AND_CUSTOMERS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MANAGE_SALES_AND_CUSTOMERS mANAGE_SALES_AND_CUSTOMERS = db.MANAGE_SALES_AND_CUSTOMERS.Find(id);
            if (mANAGE_SALES_AND_CUSTOMERS == null)
            {
                return HttpNotFound();
            }
            return View(mANAGE_SALES_AND_CUSTOMERS);
        }

        // POST: HopLong/MANAGE_SALES_AND_CUSTOMERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MANAGE_SALES_AND_CUSTOMERS mANAGE_SALES_AND_CUSTOMERS = db.MANAGE_SALES_AND_CUSTOMERS.Find(id);
            db.MANAGE_SALES_AND_CUSTOMERS.Remove(mANAGE_SALES_AND_CUSTOMERS);
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

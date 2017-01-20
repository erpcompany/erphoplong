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

namespace SYSTEM_MANAGEMENT.Controllers
{
    [AuthorizeBussiness]
    public class BANG_LUONGController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: BANG_LUONG
        public ActionResult Index(int? id)
        {
            var bANG_LUONG = db.BANG_LUONG.Where(x => x.USER_ID == id);
            return View(bANG_LUONG.ToList());
        }

        // GET: BANG_LUONG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANG_LUONG bANG_LUONG = db.BANG_LUONG.Find(id);
            if (bANG_LUONG == null)
            {
                return HttpNotFound();
            }
            return View(bANG_LUONG);
        }

        // GET: BANG_LUONG/Create
        public ActionResult Create()
        {
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME");
            return View();
        }

        // POST: BANG_LUONG/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LUONG_ID,USER_ID,LUONG_CO_BAN,LUONG_BAO_HIEM,PHU_CAP_AN_TRUA,PHU_CAP_DI_LAI_DIEN_THOAI,PHU_CAP_THUONG_DOANH_SO,PHU_CAP_TRACH_NHIEM,CONG_CO_BAN,CONG_CO_BAN_NGAY,CONG_CO_BAN_GIO,BAO_HIEM_CONG_TY,BAO_HIEM_NHAN_VIEN,LUONG_THUC_TE_CONG_LAM_THUC,LUONG_THUC_TE_SO_TIEN,LUONG_LAM_THEM_CONG_NGAY_THUONG,LUONG_LAM_THEM_TIEN_CONG_NGAY_THUONG,LUONG_LAM_THEM_CONG_NGAY_NGHI,LUONG_LAM_THEM_TIEN_CONG_NGAY_NGHI,LUONG_LAM_THEM_CONG_NGAY_LE,LUONG_LAM_THEM_TIEN_CONG_NGAY_LE,TONG_TIEN_CONG,TAM_UNG,GIO_DI_TRE,PHAT_DI_TRE,CONG_DOAN,LUONG_LAO_CONG,THUC_LINH,THANG_LINH_LUONG")] BANG_LUONG bANG_LUONG)
        {
            if (ModelState.IsValid)
            {
                db.BANG_LUONG.Add(bANG_LUONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", bANG_LUONG.USER_ID);
            return View(bANG_LUONG);
        }

        // GET: BANG_LUONG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANG_LUONG bANG_LUONG = db.BANG_LUONG.Find(id);
            if (bANG_LUONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", bANG_LUONG.USER_ID);
            return View(bANG_LUONG);
        }

        // POST: BANG_LUONG/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LUONG_ID,USER_ID,LUONG_CO_BAN,LUONG_BAO_HIEM,PHU_CAP_AN_TRUA,PHU_CAP_DI_LAI_DIEN_THOAI,PHU_CAP_THUONG_DOANH_SO,PHU_CAP_TRACH_NHIEM,CONG_CO_BAN,CONG_CO_BAN_NGAY,CONG_CO_BAN_GIO,BAO_HIEM_CONG_TY,BAO_HIEM_NHAN_VIEN,LUONG_THUC_TE_CONG_LAM_THUC,LUONG_THUC_TE_SO_TIEN,LUONG_LAM_THEM_CONG_NGAY_THUONG,LUONG_LAM_THEM_TIEN_CONG_NGAY_THUONG,LUONG_LAM_THEM_CONG_NGAY_NGHI,LUONG_LAM_THEM_TIEN_CONG_NGAY_NGHI,LUONG_LAM_THEM_CONG_NGAY_LE,LUONG_LAM_THEM_TIEN_CONG_NGAY_LE,TONG_TIEN_CONG,TAM_UNG,GIO_DI_TRE,PHAT_DI_TRE,CONG_DOAN,LUONG_LAO_CONG,THUC_LINH,THANG_LINH_LUONG")] BANG_LUONG bANG_LUONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANG_LUONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", bANG_LUONG.USER_ID);
            return View(bANG_LUONG);
        }

        // GET: BANG_LUONG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANG_LUONG bANG_LUONG = db.BANG_LUONG.Find(id);
            if (bANG_LUONG == null)
            {
                return HttpNotFound();
            }
            return View(bANG_LUONG);
        }

        // POST: BANG_LUONG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BANG_LUONG bANG_LUONG = db.BANG_LUONG.Find(id);
            db.BANG_LUONG.Remove(bANG_LUONG);
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

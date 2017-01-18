using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using SYSTEM_MANAGEMENT.Models;
using SYSTEM_MANAGEMENT.Models.BussinessModel;

namespace SYSTEM_MANAGEMENT.Controllers
{
    [AuthorizeBussiness]
    public class BANG_CHAM_CONGController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: BANG_CHAM_CONG
        public ActionResult Index(int? id)
        {
            var bANG_CHAM_CONG = db.BANG_CHAM_CONG.Where(x=>x.USER_ID ==id);
            return View(bANG_CHAM_CONG.ToList());
        }

        // GET: BANG_CHAM_CONG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANG_CHAM_CONG bANG_CHAM_CONG = db.BANG_CHAM_CONG.Find(id);
            if (bANG_CHAM_CONG == null)
            {
                return HttpNotFound();
            }
            return View(bANG_CHAM_CONG);
        }

        // GET: BANG_CHAM_CONG/Create
        public ActionResult Create()
        {
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME");
            return View();
        }

        // POST: BANG_CHAM_CONG/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CHAM_CONG_ID,USER_ID,NGAY_CHUAN,GIO_DI_MUON,GIO_VE_SOM,TANG_CA_NGAY_THUONG,TANG_CA_NGAY_LE,SO_LAN_QUEN_CHAM,SO_NGAY_NGHI,CONG_THUC_TE,UNG_LUONG,GHI_CHU,THANG_CHAM_CONG")] BANG_CHAM_CONG bANG_CHAM_CONG)
        {
            if (ModelState.IsValid)
            {
                db.BANG_CHAM_CONG.Add(bANG_CHAM_CONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", bANG_CHAM_CONG.USER_ID);
            return View(bANG_CHAM_CONG);
        }

        // GET: BANG_CHAM_CONG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANG_CHAM_CONG bANG_CHAM_CONG = db.BANG_CHAM_CONG.Find(id);
            if (bANG_CHAM_CONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", bANG_CHAM_CONG.USER_ID);
            return View(bANG_CHAM_CONG);
        }

        // POST: BANG_CHAM_CONG/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CHAM_CONG_ID,USER_ID,NGAY_CHUAN,GIO_DI_MUON,GIO_VE_SOM,TANG_CA_NGAY_THUONG,TANG_CA_NGAY_LE,SO_LAN_QUEN_CHAM,SO_NGAY_NGHI,CONG_THUC_TE,UNG_LUONG,GHI_CHU,THANG_CHAM_CONG")] BANG_CHAM_CONG bANG_CHAM_CONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANG_CHAM_CONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", bANG_CHAM_CONG.USER_ID);
            return View(bANG_CHAM_CONG);
        }

        // GET: BANG_CHAM_CONG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANG_CHAM_CONG bANG_CHAM_CONG = db.BANG_CHAM_CONG.Find(id);
            if (bANG_CHAM_CONG == null)
            {
                return HttpNotFound();
            }
            return View(bANG_CHAM_CONG);
        }

        // POST: BANG_CHAM_CONG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BANG_CHAM_CONG bANG_CHAM_CONG = db.BANG_CHAM_CONG.Find(id);
            db.BANG_CHAM_CONG.Remove(bANG_CHAM_CONG);
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

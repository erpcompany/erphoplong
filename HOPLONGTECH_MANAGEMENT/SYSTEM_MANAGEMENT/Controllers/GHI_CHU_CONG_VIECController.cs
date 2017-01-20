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
    public class GHI_CHU_CONG_VIECController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();
        // GET: GHI_CHU_CONG_VIEC
        public ActionResult Index(int? id)
        {
           
             var gHI_CHU_CONG_VIEC = db.GHI_CHU_CONG_VIEC.Where(x => x.USER_ID == id);
            
            return View(gHI_CHU_CONG_VIEC.ToList());
        }
        public ActionResult Danh_Sach_Ghi_CHu()
        {

            var gHI_CHU_CONG_VIEC = db.GHI_CHU_CONG_VIEC;

            return View(gHI_CHU_CONG_VIEC.ToList());
        }

        // GET: GHI_CHU_CONG_VIEC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GHI_CHU_CONG_VIEC gHI_CHU_CONG_VIEC = db.GHI_CHU_CONG_VIEC.Find(id);
            if (gHI_CHU_CONG_VIEC == null)
            {
                return HttpNotFound();
            }
            return View(gHI_CHU_CONG_VIEC);
        }

        // GET: GHI_CHU_CONG_VIEC/Create
        public ActionResult Create()
        {
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME");
            return View();
        }

        // POST: GHI_CHU_CONG_VIEC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NOTED_ID,USER_ID,DATE_NOTED,NOTED_NAME,NOTED_INFO,IS_DONE,DATE_DONE")] GHI_CHU_CONG_VIEC gHI_CHU_CONG_VIEC)
        {
            if (ModelState.IsValid)
            {
                db.GHI_CHU_CONG_VIEC.Add(gHI_CHU_CONG_VIEC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", gHI_CHU_CONG_VIEC.USER_ID);
            return View(gHI_CHU_CONG_VIEC);
        }


        public void MarkDone(int NOTED_ID)
        {
            var ghichu = db.GHI_CHU_CONG_VIEC.Where(x => x.NOTED_ID == NOTED_ID).FirstOrDefault();
            if(ghichu.IS_DONE == 0)
            {
                ghichu.IS_DONE = 1;
            }
            db.SaveChanges();

        }
        // GET: GHI_CHU_CONG_VIEC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GHI_CHU_CONG_VIEC gHI_CHU_CONG_VIEC = db.GHI_CHU_CONG_VIEC.Find(id);
            if (gHI_CHU_CONG_VIEC == null)
            {
                return HttpNotFound();
            }
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", gHI_CHU_CONG_VIEC.USER_ID);
            return View(gHI_CHU_CONG_VIEC);
        }

        // POST: GHI_CHU_CONG_VIEC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NOTED_ID,USER_ID,DATE_NOTED,NOTED_NAME,NOTED_INFO,IS_DONE,DATE_DONE")] GHI_CHU_CONG_VIEC gHI_CHU_CONG_VIEC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gHI_CHU_CONG_VIEC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index/"+@Session["USER_ID"]);
            }
            ViewBag.USER_ID = new SelectList(db.USERS, "USER_ID", "USERNAME", gHI_CHU_CONG_VIEC.USER_ID);
            return View(gHI_CHU_CONG_VIEC);
        }

        // GET: GHI_CHU_CONG_VIEC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GHI_CHU_CONG_VIEC gHI_CHU_CONG_VIEC = db.GHI_CHU_CONG_VIEC.Find(id);
            if (gHI_CHU_CONG_VIEC == null)
            {
                return HttpNotFound();
            }
            return View(gHI_CHU_CONG_VIEC);
        }

        // POST: GHI_CHU_CONG_VIEC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GHI_CHU_CONG_VIEC gHI_CHU_CONG_VIEC = db.GHI_CHU_CONG_VIEC.Find(id);
            db.GHI_CHU_CONG_VIEC.Remove(gHI_CHU_CONG_VIEC);
            db.SaveChanges();
            return RedirectToAction("Index/" + @Session["USER_ID"]);
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

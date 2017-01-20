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
    public class PRODUCTsController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: HopLong/PRODUCTs
        public ActionResult Index()
        {
            var pRODUCTS = db.PRODUCTS.Include(p => p.PRODUCT_CATEGORY_DETAILS).Include(p => p.PRODUCT_META).Include(p => p.Warehouse);
            return View(pRODUCTS.ToList());
        }

        // GET: HopLong/PRODUCTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: HopLong/PRODUCTs/Create
        public ActionResult Create()
        {
            ViewBag.MA_CHI_TIET_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORY_DETAILS, "MA_CHI_TIET_NHOM_HANG", "MA_NHOM_HANG");
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCT_META, "MA_HANG_HT", "THE_TICH_BOX");
            ViewBag.MA_KHO = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO");
            return View();
        }

        // POST: HopLong/PRODUCTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_HANG_HT,MA_HANG_NHAP,TEN_HANG,MA_CHI_TIET_NHOM_HANG,SERI,DON_VI_TINH,NGUON_GOC,MODEL_DAC_BIET,THOI_HAN_BAO_HANG,MA_KHO,DIEN_GIAI_KHI_MUA,DIEN_GIAI_KHI_BAN,DAC_TINH,SL_TON_KHO,SL_DANG_GIU,SL_CO_THE_DUNG,SL_THUC_TE_CO_THE_DUNG,DON_GIA_MUA_CO_DINH,DON_GIA_MUA_GAN_NHAT,HINH_ANH,GHI_CHU")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTS.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_CHI_TIET_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORY_DETAILS, "MA_CHI_TIET_NHOM_HANG", "MA_NHOM_HANG", pRODUCT.MA_CHI_TIET_NHOM_HANG);
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCT_META, "MA_HANG_HT", "THE_TICH_BOX", pRODUCT.MA_HANG_HT);
            ViewBag.MA_KHO = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", pRODUCT.MA_KHO);
            return View(pRODUCT);
        }

        // GET: HopLong/PRODUCTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_CHI_TIET_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORY_DETAILS, "MA_CHI_TIET_NHOM_HANG", "MA_NHOM_HANG", pRODUCT.MA_CHI_TIET_NHOM_HANG);
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCT_META, "MA_HANG_HT", "THE_TICH_BOX", pRODUCT.MA_HANG_HT);
            ViewBag.MA_KHO = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", pRODUCT.MA_KHO);
            return View(pRODUCT);
        }

        // POST: HopLong/PRODUCTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_HANG_HT,MA_HANG_NHAP,TEN_HANG,MA_CHI_TIET_NHOM_HANG,SERI,DON_VI_TINH,NGUON_GOC,MODEL_DAC_BIET,THOI_HAN_BAO_HANG,MA_KHO,DIEN_GIAI_KHI_MUA,DIEN_GIAI_KHI_BAN,DAC_TINH,SL_TON_KHO,SL_DANG_GIU,SL_CO_THE_DUNG,SL_THUC_TE_CO_THE_DUNG,DON_GIA_MUA_CO_DINH,DON_GIA_MUA_GAN_NHAT,HINH_ANH,GHI_CHU")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_CHI_TIET_NHOM_HANG = new SelectList(db.PRODUCT_CATEGORY_DETAILS, "MA_CHI_TIET_NHOM_HANG", "MA_NHOM_HANG", pRODUCT.MA_CHI_TIET_NHOM_HANG);
            ViewBag.MA_HANG_HT = new SelectList(db.PRODUCT_META, "MA_HANG_HT", "THE_TICH_BOX", pRODUCT.MA_HANG_HT);
            ViewBag.MA_KHO = new SelectList(db.WAREHOUSES, "MA_KHO", "TEN_KHO", pRODUCT.MA_KHO);
            return View(pRODUCT);
        }

        // GET: HopLong/PRODUCTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: HopLong/PRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            db.PRODUCTS.Remove(pRODUCT);
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

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
    public class LIST_PERMISSIONSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();

        // GET: LIST_PERMISSIONS
        public ActionResult Index(String ID)
        {
            var lIST_PERMISSIONS = db.LIST_PERMISSIONS.Where(x => x.CONTROLLER_ID == ID );
            return View(lIST_PERMISSIONS.ToList());
        }

        // GET: LIST_PERMISSIONS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIST_PERMISSIONS lIST_PERMISSIONS = db.LIST_PERMISSIONS.Find(id);
            if (lIST_PERMISSIONS == null)
            {
                return HttpNotFound();
            }
            return View(lIST_PERMISSIONS);
        }

        // GET: LIST_PERMISSIONS/Create
        public ActionResult Create()
        {
            ViewBag.CONTROLLER_ID = new SelectList(db.LIST_CONTROLLERS, "CONTROLLER_ID", "CONTROLLER_NAME");
            return View();
        }

        // POST: LIST_PERMISSIONS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PERMISSION_ID,PERMISSION_NAME,DESCRIPTION,CONTROLLER_ID")] LIST_PERMISSIONS lIST_PERMISSIONS)
        {
            if (ModelState.IsValid)
            {
                db.LIST_PERMISSIONS.Add(lIST_PERMISSIONS);
                db.SaveChanges();
                return RedirectToAction("Index", "LIST_CONTROLLERS");
            }

            ViewBag.CONTROLLER_ID = new SelectList(db.LIST_CONTROLLERS, "CONTROLLER_ID", "CONTROLLER_NAME", lIST_PERMISSIONS.CONTROLLER_ID);
            return View(lIST_PERMISSIONS);
        }

        // GET: LIST_PERMISSIONS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIST_PERMISSIONS lIST_PERMISSIONS = db.LIST_PERMISSIONS.Find(id);
            if (lIST_PERMISSIONS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONTROLLER_ID = new SelectList(db.LIST_CONTROLLERS, "CONTROLLER_ID", "CONTROLLER_NAME", lIST_PERMISSIONS.CONTROLLER_ID);
            return View(lIST_PERMISSIONS);
        }

        // POST: LIST_PERMISSIONS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PERMISSION_ID,PERMISSION_NAME,DESCRIPTION,CONTROLLER_ID")] LIST_PERMISSIONS lIST_PERMISSIONS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIST_PERMISSIONS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","LIST_CONTROLLERS");
            }
            ViewBag.CONTROLLER_ID = new SelectList(db.LIST_CONTROLLERS, "CONTROLLER_ID", "CONTROLLER_NAME", lIST_PERMISSIONS.CONTROLLER_ID);
            return View(lIST_PERMISSIONS);
        }

        // GET: LIST_PERMISSIONS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIST_PERMISSIONS lIST_PERMISSIONS = db.LIST_PERMISSIONS.Find(id);
            if (lIST_PERMISSIONS == null)
            {
                return HttpNotFound();
            }
            return View(lIST_PERMISSIONS);
        }

        // POST: LIST_PERMISSIONS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIST_PERMISSIONS lIST_PERMISSIONS = db.LIST_PERMISSIONS.Find(id);
            db.LIST_PERMISSIONS.Remove(lIST_PERMISSIONS);
            db.SaveChanges();
            return RedirectToAction("Index", "LIST_CONTROLLERS");
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

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
    public class LIST_CONTROLLERSController : Controller
    {
        private SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();


        public ActionResult Update_Controller_Info()
        {
            ReflectionController rc = new ReflectionController();
            List<Type> listControllerType = rc.GetControllers("SYSTEM_MANAGEMENT.Controllers");
            List<String> listControllerOld = db.LIST_CONTROLLERS.Select(c => c.CONTROLLER_ID).ToList();
            List<String> listPermissionOld = db.LIST_PERMISSIONS.Select(p => p.PERMISSION_NAME).ToList();
            foreach (var c in listControllerType)
            {
                if (!listControllerOld.Contains(c.Name))
                {
                    LIST_CONTROLLERS c_info = new LIST_CONTROLLERS()
                    {
                        CONTROLLER_ID = c.Name,
                        CONTROLLER_NAME = "Chưa có mô tả"
                    };
                    db.LIST_CONTROLLERS.Add(c_info);
                }
                List<String> listPermission = rc.GetActions(c);
                foreach (var p in listPermission)
                {
                    if (!listPermissionOld.Contains(c.Name + "-" + p))
                    {
                        LIST_PERMISSIONS permission = new LIST_PERMISSIONS()
                        {
                            PERMISSION_NAME = c.Name + "-" + p,
                            DESCRIPTION = "Chưa có mô tả nào",
                            CONTROLLER_ID = c.Name
                        };
                        db.LIST_PERMISSIONS.Add(permission);
                    }
                }
            }
            db.SaveChanges();
            TempData["err"] = "<div class='alert alert-info' role='alert'><span class='glyphicon glyphicon-exclamation-sign' aria-hidden='true'></span><span class='sr-only'></span>Cập nhật thành công </div> ";
            return RedirectToAction("Index");

        }


        // GET: LIST_CONTROLLERS
        public ActionResult Index()
        {
            return View(db.LIST_CONTROLLERS.ToList());
        }

        // GET: LIST_CONTROLLERS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIST_CONTROLLERS lIST_CONTROLLERS = db.LIST_CONTROLLERS.Find(id);
            if (lIST_CONTROLLERS == null)
            {
                return HttpNotFound();
            }
            return View(lIST_CONTROLLERS);
        }

        // GET: LIST_CONTROLLERS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LIST_CONTROLLERS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CONTROLLER_ID,CONTROLLER_NAME")] LIST_CONTROLLERS lIST_CONTROLLERS)
        {
            if (ModelState.IsValid)
            {
                db.LIST_CONTROLLERS.Add(lIST_CONTROLLERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lIST_CONTROLLERS);
        }

        // GET: LIST_CONTROLLERS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIST_CONTROLLERS lIST_CONTROLLERS = db.LIST_CONTROLLERS.Find(id);
            if (lIST_CONTROLLERS == null)
            {
                return HttpNotFound();
            }
            return View(lIST_CONTROLLERS);
        }

        // POST: LIST_CONTROLLERS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CONTROLLER_ID,CONTROLLER_NAME")] LIST_CONTROLLERS lIST_CONTROLLERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIST_CONTROLLERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lIST_CONTROLLERS);
        }

        // GET: LIST_CONTROLLERS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIST_CONTROLLERS lIST_CONTROLLERS = db.LIST_CONTROLLERS.Find(id);
            if (lIST_CONTROLLERS == null)
            {
                return HttpNotFound();
            }
            return View(lIST_CONTROLLERS);
        }

        // POST: LIST_CONTROLLERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LIST_CONTROLLERS lIST_CONTROLLERS = db.LIST_CONTROLLERS.Find(id);
            db.LIST_CONTROLLERS.Remove(lIST_CONTROLLERS);
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

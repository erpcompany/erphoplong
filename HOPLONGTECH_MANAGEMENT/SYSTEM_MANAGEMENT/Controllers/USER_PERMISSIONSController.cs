using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SYSTEM_MANAGEMENT.Models;
using SYSTEM_MANAGEMENT.Models.BussinessModel;

namespace SYSTEM_MANAGEMENT.Controllers
{
    [AuthorizeBussiness]
    public class USER_PERMISSIONSController : Controller
    {
        SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();
        // GET: USER_PERMISSIONS
        public ActionResult Index(int? id)
        {
            //Lấy ra danh sách các quyền trong hệ thống

            //lấy danh sách các controller trong hệ thống
            var listControl = db.LIST_CONTROLLERS.AsEnumerable();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in listControl)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.CONTROLLER_NAME,
                    Value = item.CONTROLLER_ID
                });
            }
            ViewBag.items = items;
            //lấy danh sách các quyền đã được cấp
            var listFunction = from g in db.USER_PERMISSION
                               join p in db.LIST_PERMISSIONS on g.PERMISSION_ID equals p.PERMISSION_ID
                               where g.USER_ID == id //(int)Session["USER_ID"]
                               select new SelectListItem() { Value = p.PERMISSION_ID.ToString(), Text = p.DESCRIPTION };
            ViewBag.listFunction = listFunction;
            //lưu id của người dùng đang được cấp quyền ra session
            Session["USER_PERMISSIONS"] = id;  //Session["USER_ID"];
            //Lấy người dùng
            //var USER_PERMISSIONS = db.USERS.Find(Session["USER_ID"]);
            var USER_PERMISSIONS = db.USERS.Find(id);
            //Lưu tên người dùng ra biến
            ViewBag.userpermission = USER_PERMISSIONS.USERNAME + "(" + USER_PERMISSIONS.FULLNAME + ")";
            return View();
        }

        //Lấy danh sách quyền đang được cấp cho người dùng
        public JsonResult getPermissions(string id, int userTemp)
        {
            //Lấy tất cả các permission của user và của business
            var listgranted = (from G in db.USER_PERMISSION
                               join P in db.LIST_PERMISSIONS on G.PERMISSION_ID equals P.PERMISSION_ID
                               where G.USER_ID == userTemp && P.CONTROLLER_ID == id
                               select new PermissionAction { PERMISSION_ID = P.PERMISSION_ID, PERMISSION_NAME = P.PERMISSION_NAME, DESCRIPTION = P.DESCRIPTION, IS_GRANTED = true }).ToList();
            //Lấy tất cả các permission của controller hiện tại
            var listpermission = from p in db.LIST_PERMISSIONS
                                 where p.CONTROLLER_ID == id
                                 select new PermissionAction { PERMISSION_ID = p.PERMISSION_ID, PERMISSION_NAME = p.PERMISSION_NAME, DESCRIPTION = p.DESCRIPTION, IS_GRANTED = false };
            //Lấy các id của permission đã được gán ở trên cho người dùng
            var listpermissionid = listgranted.Select(p => p.PERMISSION_ID);
            //kiểm tra permission id nào của controller mà chưa có trong listgranted thì đưa vào(is_granted = false)
            foreach (var item in listpermission)
            {
                if(!listpermissionid.Contains(item.PERMISSION_ID))
                {
                    listgranted.Add(item);
                }
                
            }
            return Json(listgranted.OrderBy(x => x.DESCRIPTION), JsonRequestBehavior.AllowGet);
        }

        //cập nhật quyền người dùng
        public string updatePermission(int id, int usertemp)
        {
            string msg = "";
            var grant = db.USER_PERMISSION.Find(id, usertemp);
            if(grant == null)
            {
                USER_PERMISSION g = new USER_PERMISSION() { PERMISSION_ID = id, USER_ID = usertemp, DESCRIPTION = "" };
                db.USER_PERMISSION.Add(g);
                msg = "<div class='alert alert-success'> Cấp quyền thành công </div>";
            }
            else
            {
                db.USER_PERMISSION.Remove(grant);
                msg = "<div class='alert alert-danger'> Hủy quyền thành công </div>";
            }
            db.SaveChanges();
            return msg;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SYSTEM_MANAGEMENT.Models.BussinessModel
{
    public class AuthorizeBussiness: ActionFilterAttribute
    {
        SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session["USER_ID"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
                return;

                

            }
            int userId = int.Parse(HttpContext.Current.Session["USER_ID"].ToString());
            //lấy tên action
            string actionName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "Controller-" + filterContext.ActionDescriptor.ActionName;
            //lấy thông tin user
            var admin = db.USERS.Where(a => a.USER_ID == userId && a.IS_ADMIN.Value != 0).FirstOrDefault();
            //nếu là admin thì mặc nhiên được vào, không cần kiểm tra gì cả
            if(admin != null)
            {
                return;
            }

            //nếu không phải thì sẽ kiểm tra tên các permission được gán cho người dùng
            var listpermission = from p in db.LIST_PERMISSIONS
                                 join g in db.USER_PERMISSION on p.PERMISSION_ID equals g.PERMISSION_ID
                                 where g.USER_ID == userId
                                 select p.PERMISSION_NAME;
            //kiểm tra các permission có chứa tên action mà người dùng click hay không?
            // nếu không thì nhảy tới trang thông báo
            if(!listpermission.Contains(actionName))
            {
                filterContext.Result = new RedirectResult("/Home/NotificationAuthorize");
                return;
            }
        }
    }
}
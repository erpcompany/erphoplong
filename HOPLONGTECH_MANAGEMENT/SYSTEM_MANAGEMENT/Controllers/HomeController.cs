using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SYSTEM_MANAGEMENT.Models;
using SYSTEM_MANAGEMENT.Models.BussinessModel;

namespace SYSTEM_MANAGEMENT.Controllers
{
    
    public class HomeController : Controller
    {
        SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();
        public ActionResult Index()
        {
            return RedirectToAction("Index","GHI_CHU_CONG_VIEC", new { id = Session["USER_ID"], is_admin = Session["IS_ADMIN"] });
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String username, String password)
        {
            var user = db.USERS.SingleOrDefault(x => x.USERNAME == username && x.PASSWORD == password && x.ALLOWED == 1);
            if(user !=null)
            {
                Session["USER_ID"] = user.USER_ID;
                Session["USERNAME"] = user.USERNAME;
                Session["FULLNAME"] = user.FULLNAME;
                Session["IS_AMIN"] = user.IS_ADMIN;
                Session["AVATAR"] = user.AVATAR;
                return RedirectToAction("Index");
            }
            ViewBag.error = "Wrong username or password";
            return View();
        }
        public ActionResult Logout()
        {
            Session["USER_ID"] = null;
            Session["USERNAME"] = null;
            Session["FULLNAME"] = null;
            Session["IS_AMIN"] = null;
            Session["AVATAR"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult NotificationAuthorize()
        {
            return View();
        }

        public EmptyResult Alive()
        {
            return new EmptyResult();
        }
    }
}
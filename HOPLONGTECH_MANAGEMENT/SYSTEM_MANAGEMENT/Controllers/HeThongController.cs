using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SYSTEM_MANAGEMENT.Models.BussinessModel;

namespace SYSTEM_MANAGEMENT.Controllers
{
    [AuthorizeBussiness]
    public class HeThongController : Controller
    {
        // GET: HeThong
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System.Web.Mvc;

namespace SYSTEM_MANAGEMENT.Areas.HopLong
{
    public class HopLongAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HopLong";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HopLong_default",
                "HopLong/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
using System.Web.Mvc;

namespace AnThanh.Areas.ModuleBaseData
{
    public class ModuleBaseDataAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModuleBaseData";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModuleBaseData_default",
                "ModuleBaseData/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
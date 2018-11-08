using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnThanh.Areas.ModuleBaseData.Controllers
{
    public class ServiceController : Controller
    {
        // GET: ModuleBaseData/Service
        [HttpGet]
        public ActionResult ServiceDisplay()
        {
            return View("~/Areas/ModuleBaseData/Views/Service/ServiceDisplay.cshtml");
        }

    }
}
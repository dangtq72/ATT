using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnThanh.Areas.PO.Controllers
{
    public class POController : Controller
    {
        // GET: PO/PO
        public ActionResult PODisplay()
        {
            return View();
        }
    }
}
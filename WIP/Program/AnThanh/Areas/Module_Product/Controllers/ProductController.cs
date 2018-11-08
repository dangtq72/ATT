using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NaviCommon;

namespace AnThanh.Areas.Module_Product.Controllers
{
    public class ProductController : Controller
    {
        // GET: Module_Product/Product
        public ActionResult Product_Getpage()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return View();
        }
    }
}
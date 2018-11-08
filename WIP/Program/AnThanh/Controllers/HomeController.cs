
using BusinessFacadeLayer;
using ObjInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnThanh.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return View();
            }
        }
        public ActionResult GotoFormLogin()
        {
            return PartialView("~/Views/Shared/_PartialView_Login.cshtml");
        }
        [HttpPost]
        public ActionResult CheckUser(string user_name, string password)
        {
            try
            {

                string _pass = NaviCommon.CommonFuc.Encrypt(user_name.ToUpper() + "!@#$%" + password);
                UserBL _obj = new UserBL();
                var Obj_info = _obj.CheckLogin(user_name, _pass);
                SessionData.SetDataSession("Account", Obj_info);
                return Json(new { success = Obj_info.User_Id });

            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return Json(new { success = "-1" });
            }
        }
    }
}
using BusinessFacadeLayer.UserAndRole;
using NaviCommon;
using ObjInfo.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnThanh.Areas.UserAndRole.Controllers
{
    public class AuGroupController : Controller
    {
        // GET: UserAndRole/AuGroup
        public ActionResult AuGroupDisplay()
        {
            List<Au_GroupInfo> list = new List<Au_GroupInfo>();
            try
            {
                Au_GroupBL _bl = new Au_GroupBL();


                decimal _total_record = 0;
                list = _bl.Search("ALL", ref _total_record);


                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<Au_GroupInfo>((int)_total_record, 1, "bản ghi");
                ViewBag.Paging = htmlPaging;
                ViewBag.List = list;
                ViewBag.SumRecord = _total_record;

            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return View();
        }
        [HttpPost]
        public ActionResult Search(string p_keysearch, int p_CurrentPage)
        {
            try
            {
                decimal _total_record = 0;
                string p_to = "";
                string p_from = CommonFuc.Get_From_To_Page(p_CurrentPage, ref p_to);
                if (p_keysearch == "" || p_keysearch == null)
                {
                    p_keysearch = "ALL";
                }
                Au_GroupBL _bl = new Au_GroupBL();
                List<Au_GroupInfo> _lst = _bl.Search(p_keysearch, ref _total_record, p_from, p_to);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<Au_GroupInfo>((int)_total_record, p_CurrentPage, "bản ghi");


                ViewBag.Paging = htmlPaging;
                ViewBag.List = _lst;
                ViewBag.SumRecord = _total_record;
                return PartialView("~/Areas/UserAndRole/Views/AuGroup/_Partial_List.cshtml");
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return PartialView("~/Areas/UserAndRole/Views/AuGroup/_Partial_List.cshtml");
            }
        }

        public ActionResult ViewRegister()
        {
            return PartialView("~/Areas/UserAndRole/Views/AuGroup/_Partial_Insert.cshtml");
        }
        [HttpPost]
        public ActionResult Register(Au_GroupInfo au_groupinfo)
        {
            try
            {
                Au_GroupBL _bl = new Au_GroupBL();
                au_groupinfo.Created_By = "";
                au_groupinfo.Created_Date = DateTime.Now;
                decimal ck = _bl.Insert(au_groupinfo);
                return Json(new { success = ck });
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return Json(new { success = "-1" });
            }
        }
        [HttpGet]
        public ActionResult EditView(decimal id)
        {
            Au_GroupInfo _obj = new Au_GroupInfo();
            try
            {
                Au_GroupBL _bl = new Au_GroupBL();
                _obj = _bl.GetbyId(id);
            }
            catch (Exception ex)
            {
                _obj = new Au_GroupInfo();
                NaviCommon.Common.log.Error(ex.ToString());

            }
            ViewBag.Supplier = _obj;
            return PartialView("~/Areas/UserAndRole/Views/AuGroup/_Partial_Edit.cshtml");
        }

    }
}
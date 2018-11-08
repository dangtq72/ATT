using BusinessFacadeLayer.ModuleBaseDataBL;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnThanh.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public ActionResult SuppliersDisplay()
        {
            List<SupplierInfo> list = new List<SupplierInfo>();
            try
            {
                SupplierBL _bl = new SupplierBL();
           
            
                decimal _total_record = 0;
                list = _bl.Search("ALL",ref _total_record);


                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<SupplierInfo>((int)_total_record, 1, "nhà cung cấp");
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
                SupplierBL _bl = new SupplierBL();
                List<SupplierInfo> _lst = _bl.Search(p_keysearch, ref _total_record, p_from, p_to);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<SupplierInfo>((int)_total_record, p_CurrentPage, "Thông tin chứng khoán");

                ViewBag.Paging = htmlPaging;
                ViewBag.Obj = _lst;
                ViewBag.SumRecord = _total_record;
                return PartialView("_Partial_List");
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return PartialView("_Partial_List");
            }
        }
    }
}
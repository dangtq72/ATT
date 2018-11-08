using BusinessFacadeLayer.ModuleBaseDataBL;
using ExcelDataReader;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AnThanh.Areas.ModuleBaseData.Controllers
{
    public class LocationController : Controller
    {
        // GET: ModuleBaseData/Location
        public ActionResult LocationDisplay()
        {
            List<LocationInfo> list = new List<LocationInfo>();
            try
            {
                LocationBL _bl = new LocationBL();
                decimal _total_record = 0;
                list = _bl.Location_Search("ALL", ref _total_record);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<LocationInfo>((int)_total_record, 1, "tỉnh/ huyện");
                ViewBag.Paging = htmlPaging;
                ViewBag.List = list;
                ViewBag.SumRecord = _total_record;
            }
            catch(Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return View("~/Areas/ModuleBaseData/Views/Location/LocationDisplay.cshtml");
        }
        [HttpPost]
        public ActionResult Location_Search(string p_keysearch, int p_CurrentPage)
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
                LocationBL _bl = new LocationBL();
                List<LocationInfo> _lst = _bl.Location_Search(p_keysearch, ref _total_record, p_from, p_to);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<LocationInfo>((int)_total_record, p_CurrentPage, "tỉnh/ thành");
                ViewBag.Paging = htmlPaging;
                ViewBag.List = _lst;
                ViewBag.SumRecord = _total_record;
                return PartialView("~/Areas/ModuleBaseData/Views/Location/_Partial_ListLocation.cshtml");
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return PartialView("~/Areas/ModuleBaseData/Views/Location/_Partial_ListLocation.cshtml");
            }
        }
        [HttpPost]
        public ActionResult GotoViewImport()
        {
            return View("~/Areas/ModuleBaseData/Views/Location/_Partial_ImportFile.cshtml");
        }
        public Decimal Import_file_excel(HttpPostedFileBase fileImport)
        {
            try
            {
                DataSet _ds = new DataSet();
                if (fileImport != null && fileImport.ContentLength > 0)
                {
                    if (!fileImport.FileName.EndsWith(".xls") && !fileImport.FileName.EndsWith(".xlsx"))
                    {
                        return -3;
                    }
                    else
                    {
                        Stream stream = fileImport.InputStream;
                        IExcelDataReader reader = null;

                        if (fileImport.FileName.EndsWith(".xls"))
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else if (fileImport.FileName.EndsWith(".xlsx"))
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }

                        _ds = reader.AsDataSet();
                        reader.Close();
                    }
                }
                if (_ds != null)
                {
                    _ds.Tables[0].Rows[0].Delete();//xóa dòng title
                    _ds.AcceptChanges();
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in _ds.Tables[0].Rows)
                        {
                            LocationInfo obj_info = new LocationInfo();
                            obj_info.Parent_Name = dr[0] == null ? "" : dr[0].ToString();
                            obj_info.Parent_Id = dr[1] == null ? 0 : decimal.Parse(dr[1].ToString());
                            obj_info.Name = dr[2] == null ? "" : dr[2].ToString();
                            obj_info.Code = dr[3] == null ? "" : dr[3].ToString();
                            LocationBL obj_bl = new LocationBL();
                            obj_bl.Location_Insert(obj_info);
                        }
                    }
                    else
                    {
                        return -4;//không có dữ liệu
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }
    }

}
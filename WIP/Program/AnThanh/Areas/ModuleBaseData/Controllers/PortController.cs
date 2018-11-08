using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessFacadeLayer.ModuleBaseDataBL;
using System.Data;
using ObjInfo.ModuleBaseData;
using NaviCommon;
using System.IO;
using ExcelDataReader;

namespace AnThanh.Areas.ModuleBaseData.Controllers
{
    public class PortController : Controller
    {
        // GET: ModuleBaseData/Port
        public ActionResult Port_Getpage()
        {
            List<PortInfo> list = new List<PortInfo>();
            try
            {
                int p_total_record = 0;
                list = PortBL.Port_Getpage("", 0, Common.constRecordOnPage, "", "", ref p_total_record);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<PortInfo>((int)p_total_record, 1, "Cảng");
                ViewBag.Paging = htmlPaging;
                ViewBag.SumRecord = p_total_record;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Port_Search(string _portText, int _recordpage, int _currentpage)
        {
            try
            {
                int p_total_record = 0;
                _recordpage = _recordpage == 0 ? Common.constRecordOnPage : _recordpage;
                int _start = _recordpage * (_currentpage - 1) + 1;
                int _end = _recordpage * _currentpage;
                List<PortInfo> _lst = new List<PortInfo>();
                _lst = PortBL.Port_Getpage(_portText, _start, _end, "", "", ref p_total_record);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<PortInfo>((int)p_total_record, 1, "Cảng");
                ViewBag.Paging = htmlPaging;
                ViewBag.SumRecord = p_total_record;
                return PartialView("_Port_List", _lst);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return PartialView("_Port_List");
            }
        }
        [HttpGet]
        public ActionResult Port_View_Insert()
        {
            return PartialView("_Port_Insert");
        }
        [HttpPost]
        public ActionResult Port_Insert(PortInfo _obj)
        {
            decimal p_success = -1;
            try
            {
                p_success = PortBL.Port_Insert(_obj);

            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return Json(new { success = p_success });
        }
        [HttpGet]
        public ActionResult Port_View_Update(decimal _portId)
        {
            var _obj = new PortInfo();
            try
            {
                _obj = PortBL.Port_GetByID(_portId);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return PartialView("_Port_Update", _obj);
        }
        [HttpPost]
        public ActionResult Port_Update(PortInfo _obj)
        {
            decimal p_success = -1;
            try
            {
                p_success = PortBL.Port_Update(_obj);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return Json(new { success = p_success });
        }
        [HttpPost]
        public ActionResult Port_Deleted(decimal _portId)
        {
            decimal p_success = -1;
            try
            {
                p_success = PortBL.Port_Delete(_portId);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return Json(new { success = p_success });
        }
        [HttpPost]
        public ActionResult GotoViewImport()
        {
            return View("~/Areas/ModuleBaseData/Views/Port/_Port_ImportFile.cshtml");
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
                            PortInfo _obj = new PortInfo();
                            _obj.Port_Code = dr[0] == null ? "" : dr[0].ToString();
                            _obj.Port_Name = dr[1] == null ? "" : dr[1].ToString();
                            _obj.Notes = dr[3] == null ? "" : dr[3].ToString();
                            string Type = dr[4] == null ? "" : dr[4].ToString();
                            if (Type != "")
                            {
                                _obj.Type = Convert.ToDecimal(Type);
                            }
                            if (_obj.Port_Code != "")
                            {
                                PortBL.Port_Insert(_obj);
                            }
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
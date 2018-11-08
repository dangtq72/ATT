
using AnThanh.Commons;
using BusinessFacadeLayer.ModuleBaseDataBL;
using ExcelDataReader;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnThanh.Areas.ModuleBaseData.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Suppliers
        public ActionResult SupplierDisplay()
        {
            if (SessionData.CurrentUser == null)
                return Redirect("~/home/index");
            List<SupplierInfo> list = new List<SupplierInfo>();
            try
            {
                SupplierBL _bl = new SupplierBL();


                decimal _total_record = 0;
                list = _bl.Search("ALL", ref _total_record);


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
                if (p_keysearch == "" || p_keysearch == null)
                {
                    p_keysearch = "ALL";
                }
                SupplierBL _bl = new SupplierBL();
                List<SupplierInfo> _lst = _bl.Search(p_keysearch, ref _total_record, p_from, p_to);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<SupplierInfo>((int)_total_record, p_CurrentPage, "nhà cung cấp");


                ViewBag.Paging = htmlPaging;
                ViewBag.List = _lst;
                ViewBag.SumRecord = _total_record;

                return PartialView("~/Areas/ModuleBaseData/Views/Supplier/_Partial_ListSupplier.cshtml");
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return PartialView("~/Areas/ModuleBaseData/Views/Supplier/_Partial_ListSupplier.cshtml");
            }
        }
        public ActionResult ViewRegister()
        {
            return PartialView("~/Areas/ModuleBaseData/Views/Supplier/_Partial_Insert_Supplier.cshtml");
        }

        [HttpPost]
        public ActionResult Register(SupplierInfo supplierinfo)
        {
            try
            {
                SupplierBL _bl = new SupplierBL();
                supplierinfo.Created_by = "";
                supplierinfo.Created_date = DateTime.Now;
                decimal ck = _bl.Insert(supplierinfo);
                return Json(new { success = ck });
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return Json(new { success = "-1" });
            }
        }
        [HttpGet]
        public ActionResult ViewDetail(decimal id)
        {
            SupplierInfo _obj = new SupplierInfo();
            try
            {
                SupplierBL _bl = new SupplierBL();
                _obj = _bl.GetbyId(id);
            }
            catch (Exception ex)
            {
                _obj = new SupplierInfo();
                NaviCommon.Common.log.Error(ex.ToString());
            }
            ViewBag.Supplier = _obj;
            return PartialView("~/Areas/ModuleBaseData/Views/Supplier/_Partial_View_Supplier.cshtml");
        }
        [HttpGet]
        public ActionResult EditView(decimal id)
        {
            SupplierInfo _obj = new SupplierInfo();
            try
            {
                SupplierBL _bl = new SupplierBL();
                _obj = _bl.GetbyId(id);
            }
            catch (Exception ex)
            {
                _obj = new SupplierInfo();
                NaviCommon.Common.log.Error(ex.ToString());

            }
            ViewBag.Supplier = _obj;
            return PartialView("~/Areas/ModuleBaseData/Views/Supplier/_Partial_Edit_Supplier.cshtml");
        }

        [HttpPost]
        public ActionResult Edit(SupplierInfo supplierinfo)
        {
            try
            {
                SupplierBL _bl = new SupplierBL();

                SupplierInfo _obj = new SupplierInfo();
                _obj = _bl.GetbyId(supplierinfo.Id);

                supplierinfo.Number_Contract = _obj.Number_Contract;
                supplierinfo.Created_date = _obj.Created_date;
                supplierinfo.Created_by = _obj.Created_by;


                decimal ck = _bl.Update(supplierinfo);
                return Json(new { success = ck });
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return Json(new { success = "-1" });
            }
        }
        [HttpPost]
        public ActionResult Delete(decimal id)
        {
            try
            {
                SupplierBL _bl = new SupplierBL();

                decimal ck = _bl.Delete(id);
                return Json(new { success = ck });
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return Json(new { success = "-1" });
            }
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
                            SupplierInfo obj_info = new SupplierInfo();
                            obj_info.Name = dr[0] == null ? "" : dr[0].ToString();
                            obj_info.Code = dr[1] == null ? "" : dr[1].ToString();
                            obj_info.Phone = dr[2] == null ? "" : dr[2].ToString();
                            obj_info.Fax = dr[3] == null ? "" : dr[3].ToString();
                            obj_info.Email = dr[4] == null ? "" : dr[4].ToString();
                            obj_info.Notes = dr[5] == null ? "" : dr[5].ToString();
                            obj_info.Created_date = DateTime.Now;
                            obj_info.Created_by = "";
                            SupplierBL _bl = new SupplierBL();
                            _bl.Insert(obj_info);
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
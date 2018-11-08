using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NaviCommon;

using ObjInfo.ModuleBaseData;
using BusinessFacadeLayer.ModuleBaseDataBL;
using System.IO;
using System.Data;
using ExcelDataReader;

namespace AnThanh.Areas.Product.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Product_Getpage()
        {
            List<Product_Info> list = new List<Product_Info>();
            try
            {
                int p_total_record = 0;
                list = ProductBL.Product_Getpage("", 0, Common.constRecordOnPage, "", "", ref p_total_record);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<Product_Info>((int)p_total_record, 1, "Sản phẩm");
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
        public ActionResult Product_Search(string _productText, int _recordpage, int _currentpage)
        {
            try
            {
                int p_total_record = 0;
                _recordpage = _recordpage == 0 ? Common.constRecordOnPage : _recordpage;
                int _start = _recordpage * (_currentpage - 1) + 1;
                int _end = _recordpage * _currentpage;
                List<Product_Info> _lst = new List<Product_Info>();
                _lst = ProductBL.Product_Getpage(_productText, _start, _end, "", "", ref p_total_record);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<Product_Info>((int)p_total_record, 1, "Sản phẩm");
                ViewBag.Paging = htmlPaging;
                ViewBag.SumRecord = p_total_record;
                return PartialView("_Partial_List_Product", _lst);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return PartialView("_Partial_List_Product");
            }
        }
        [HttpGet]
        public ActionResult Product_View_Insert()
        {
            return PartialView("_Product_Insert");
        }
        [HttpPost]
        public ActionResult Product_Insert(Product_Info _obj)
        {
            decimal p_success = -1;
            try
            {
                p_success = ProductBL.Product_Insert(_obj);

            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return Json(new { success = p_success });
        }
        [HttpGet]
        public ActionResult Product_View_Update(decimal _productId)
        {
            var _obj = new Product_Info();
            try
            {
                _obj = ProductBL.Product_GetByID(_productId);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return PartialView("_Product_Update", _obj);
        }
        [HttpPost]
        public ActionResult Product_Update(Product_Info _obj)
        {
            decimal p_success = -1;
            try
            {
                p_success = ProductBL.Product_Update(_obj);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return Json(new { success = p_success });
        }
        [HttpPost]
        public ActionResult Product_Deleted(decimal _productId)
        {
            decimal p_success = -1;
            try
            {
                p_success = ProductBL.Product_Delete(_productId);
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
            return View("~/Areas/Product/Views/Product/_Product_ImportFile.cshtml");
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
                            Product_Info _obj = new Product_Info();
                            _obj.Product_Code = dr[0] == null ? "" : dr[0].ToString();
                            _obj.Product_Name = dr[1] == null ? "" : dr[1].ToString();
                            _obj.Bravo_Code = dr[2] == null ? "" : dr[2].ToString();
                            _obj.Note = dr[3] == null ? "" : dr[3].ToString();
                            string Product_Group_ID = dr[4] == null ? "" : dr[4].ToString();
                            if(Product_Group_ID != "")
                            {
                                _obj.Product_Group_Id = Convert.ToDecimal(Product_Group_ID);
                            }
                            if(_obj.Product_Code != "" && _obj.Bravo_Code != "")
                            {
                                ProductBL.Product_Insert(_obj);
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
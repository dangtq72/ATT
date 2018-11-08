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
    public class CustomerController : Controller
    {
        // GET: ModuleBaseData/Customer
        [HttpGet]
        public ActionResult CustomerDisplay()
        {
            List<CustomerInfo> list = new List<CustomerInfo>();
            try
            {
                CustomerBL _bl = new CustomerBL();
                decimal _total_record = 0;
                list = _bl.Customer_Search("ALL", ref _total_record);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<CustomerInfo>((int)_total_record, 1, "khách hàng");
                ViewBag.Paging = htmlPaging;
                ViewBag.List = list;
                ViewBag.SumRecord = _total_record;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return View("~/Areas/ModuleBaseData/Views/Customer/CustomerDisplay.cshtml");
        }
        [HttpPost]
        public ActionResult Customer_Search(string p_keysearch, int p_CurrentPage)
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
                CustomerBL _bl = new CustomerBL();
                List<CustomerInfo> _lst = _bl.Customer_Search(p_keysearch, ref _total_record, p_from, p_to);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<CustomerInfo>((int)_total_record, p_CurrentPage, "khách hàng");
                ViewBag.Paging = htmlPaging;
                ViewBag.List = _lst;
                ViewBag.SumRecord = _total_record;

                return PartialView("~/Areas/ModuleBaseData/Views/Customer/_Partial_ListCustomer.cshtml");
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return PartialView("~/Areas/ModuleBaseData/Views/Customer/_Partial_ListCustomer.cshtml");
            }
        }
        [HttpPost]
        public ActionResult CustomerRegister()
        {
            return View("~/Areas/ModuleBaseData/Views/Customer/_PartialCustomer_Insert.cshtml");
        }
        [HttpPost]
        public ActionResult GotoViewImport()
        {
            return View("~/Areas/ModuleBaseData/Views/Customer/_Partial_ImportFile.cshtml");
        }
        [HttpPost]
        public Decimal CustomerInsert(CustomerInfo Obj_Info)
        {
            decimal p_return = -1;
            CustomerBL Obj_BL = new CustomerBL();
            try
            {
                Obj_Info.Created_date = DateTime.Now;
                p_return = Obj_BL.Customer_Insert(Obj_Info);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return p_return;
        }
        [HttpGet]
        public ActionResult GotoViewUpdate(decimal Id)
        {
            try
            {
                CustomerBL Obj_BL = new CustomerBL();
                CustomerInfo obj_info = new CustomerInfo();
                obj_info = Obj_BL.Customer_GetById(Id);
                return PartialView("~/Areas/ModuleBaseData/Views/Customer/_PartialCustomer_Update.cshtml", obj_info);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return PartialView("~/Areas/ModuleBaseData/Views/Customer/_PartialCustomer_Update.cshtml");
            }
        }
        [HttpPost]
        public Decimal CustomerUpdate(CustomerInfo Obj_Info)
        {
            decimal p_return = -1;
            CustomerBL Obj_BL = new CustomerBL();
            try
            {
                Obj_Info.modify_date = DateTime.Now;
                p_return = Obj_BL.Customer_Update(Obj_Info);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return p_return;
        }
        [HttpPost]
        public Decimal Customer_Delete(decimal customer_id)
        {
            decimal p_return = -1;
            CustomerBL Obj_BL = new CustomerBL();
            try
            {
                p_return = Obj_BL.Delete(customer_id);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return p_return;
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
                            CustomerInfo obj_info = new CustomerInfo();
                            obj_info.Customer_Code = dr[0] == null ? "" : dr[0].ToString();
                            obj_info.Customer_Name = dr[1] == null ? "" : dr[1].ToString();
                            obj_info.Phone = dr[2] == null ? "" : dr[2].ToString();
                            obj_info.Fax = dr[3] == null ? "" : dr[3].ToString();
                            obj_info.Email = dr[4] == null ? "" : dr[4].ToString();
                            obj_info.Notes = dr[5] == null ? "" : dr[5].ToString();
                            CustomerBL obj_bl = new CustomerBL();
                            obj_bl.Customer_Insert(obj_info);
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
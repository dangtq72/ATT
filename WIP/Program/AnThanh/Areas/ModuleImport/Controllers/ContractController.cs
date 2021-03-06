﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObjInfo.Import;
using BusinessFacadeLayer.Import;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using BusinessFacadeLayer.ModuleBaseDataBL;

namespace AnThanh.Areas.ModuleImport.Controllers
{
    public class ContractController : Controller
    {
        [HttpGet]
        public ActionResult Contract_Display()
        {
            var contractBl = new ContractBL();
            List<Contract> lstContract = new List<Contract>();

            try
            {
                decimal totalRecord = 0;
                lstContract = contractBl.Search(1, ref totalRecord);
                string htmlPaging = CommonFuc.Get_HtmlPaging<Contract>((int)totalRecord, 1, "hợp đồng");
                ViewBag.Paging = htmlPaging;
                ViewBag.ListContract = lstContract;
                ViewBag.SumRecord = totalRecord;

            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return View("~/Areas/ModuleImport/Views/Contract/Contract_Display.cshtml");
        }

        [HttpPost]
        public ActionResult Contract_Search(int currentPage, string keySearch)
        {
            var contractBl = new ContractBL();
            List<Contract> lstContract = new List<Contract>();

            try
            {
                decimal totalRecord = 0;
                lstContract = contractBl.Search(currentPage, ref totalRecord, keySearch);
                string htmlPaging = CommonFuc.Get_HtmlPaging<Contract>((int)totalRecord, currentPage, "hợp đồng");
                ViewBag.Paging = htmlPaging;
                ViewBag.ListContract = lstContract;
                ViewBag.SumRecord = totalRecord;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return PartialView("~/Areas/ModuleImport/Views/Contract/_Partial_Contract_List.cshtml");
        }

        [HttpGet]
        public ActionResult Contract_Insert()
        {
            var supplyBl = new SupplierBL();
            List<SupplierInfo> lstSuppliers = new List<SupplierInfo>();
            try
            {
                lstSuppliers = supplyBl.GetAll();
                ViewBag.ListSuppliers = lstSuppliers;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return View("~/Areas/ModuleImport/Views/Contract/Contract_Insert.cshtml");
        }

        [HttpPost]
        public ActionResult Contract_Insert(Contract contract, List<Shipment> lstShipment, List<ContractDetail> contractDetails)
        {
            var contractBl = new ContractBL();
            decimal _success = -1;

            try
            {
                _success = contractBl.Insert_ContainShipment(contract, lstShipment, contractDetails);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return Json(new {success = _success });
        }

        [HttpGet]
        public ActionResult Contract_Update(decimal contractId)
        {
            var contractBl = new ContractBL();
            Contract contract = new Contract();
            try
            {
                contract = contractBl.GetById(contractId);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return View("~/Areas/ModuleImport/Views/Contract/Contract_Update.cshtml");
        }

        [HttpPost]
        public ActionResult Contract_Update(Contract contract, List<Shipment> lstShipment, List<ContractDetail> contractDetails)
        {
            var contractBl = new ContractBL();
            decimal _success = -1;

            try
            {
                _success = contractBl.Update_ContainShipment(contract, lstShipment, contractDetails);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return Json(new { success = _success });
        }

        [HttpGet]
        public ActionResult ContractDetail_GetViewToInsert(int indexDetail)
        {
            var productBl = new ProductBL();
            List<Product_Info> lstProduct = new List<Product_Info>();
            try
            {
                lstProduct = ProductBL.Product_GetAll();
                ViewBag.ListProduct = lstProduct;
                ViewBag.IndexDetail = indexDetail;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return PartialView("~/Areas/ModuleImport/Views/Contract/_Partial_ContractDetail_Add.cshtml");
        }

        [HttpGet]
        public ActionResult Shipment_GetViewToInsert(int contractType ,int indexDetail = 0, int indexShipment = 0)
        {
            var portBl = new PortBL();
            List<PortInfo> lstPort = new List<PortInfo>();
            try
            {
                lstPort = PortBL.Port_GetAll();
                ViewBag.ListPort = lstPort;
                ViewBag.ContractType = contractType;
                ViewBag.IndexDetail = indexDetail;
                ViewBag.IndexShipment = indexShipment;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return PartialView("~/Areas/ModuleImport/Views/Contract/_Partial_Shipment_Insert.cshtml");
        }

        [HttpPost]
        public ActionResult Shipment_Insert(Shipment shipment)
        {
            return Json(new { shipment });
        }

        [HttpGet]
        public ActionResult Shipment_GetViewToUpdate()
        {
            return PartialView("~/Areas/ModuleImport/Views/Contract/_Partial_Shipment_Insert.cshtml");
        }

        [HttpPost]
        public ActionResult Shipment_Update(Shipment shipment)
        {
            return Json(new { shipment });
        }
    }
}
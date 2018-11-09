using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObjInfo.Import;
using BusinessFacadeLayer.Import;
using NaviCommon;

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
            return View("~/Areas/ModuleImport/Views/Contract/Contract_Insert.cshtml");
        }

        [HttpPost]
        public ActionResult Contract_Insert(Contract contract, List<Shipment> lstShipment)
        {
            var contractBl = new ContractBL();
            decimal _success = -1;

            try
            {
                _success = contractBl.Insert_ContainShipment(contract, lstShipment);
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
            contract = contractBl.GetById(contractId);
            return View("~/Areas/ModuleImport/Views/Contract/Contract_Update.cshtml");
        }

        [HttpPost]
        public ActionResult Contract_Update(Contract contract, List<Shipment> lstShipment)
        {
            var contractBl = new ContractBL();
            decimal _success = -1;

            try
            {
                _success = contractBl.Update_ContainShipment(contract, lstShipment);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return Json(new { success = _success });
        }

        [HttpGet]
        public ActionResult Shipment_GetViewToInsert()
        {
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
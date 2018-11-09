
namespace BusinessFacadeLayer.Import
{
    using System;
    using DataAccessLayer.Import;
    using ObjInfo.Import;
    using NaviCommon;
    using System.Collections.Generic;

    public class ShipmentBL
    {
        public List<Shipment> Search(int currentPage, ref decimal totalRecord, string keySearch = "")
        {
            List<Shipment> lstShipment = new List<Shipment>();
            var shipmentDa = new ShipmentDA();
            string _shipmentCode = ""; string _contractCode = ""; string _productCode = "";
            string _billing_number = ""; string _requestObject = ""; string _importObject = ""; string _status = "";
            try
            {
                var arrKeySearch = keySearch.Split('|');
                if (arrKeySearch.Length >= 7)
                {
                    _shipmentCode = arrKeySearch[0];
                    _contractCode = arrKeySearch[1];
                    _productCode = arrKeySearch[2];
                    _billing_number = arrKeySearch[3];
                    _requestObject = arrKeySearch[4];
                    _importObject = arrKeySearch[5];
                    _status = arrKeySearch[6];
                }
                string p_to = Common.RecordOnpage.ToString();
                string p_from = CommonFuc.Get_From_To_Page(currentPage, ref p_to);

                var ds = shipmentDa.Search(_shipmentCode, _contractCode, _productCode, _billing_number, _requestObject, _importObject, _status, p_from, p_to, ref totalRecord);
                lstShipment = CBO<Shipment>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return lstShipment;
        }

        public List<Shipment> GetByContractId(decimal contractId)
        {
            List<Shipment> lstShipment = new List<Shipment>();
            var shipmentDa = new ShipmentDA();
            try
            {
                var ds = shipmentDa.GetByContractId(contractId);
                lstShipment = CBO<Shipment>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return lstShipment;
        }

        public Shipment GetById(decimal id)
        {
            Shipment shipment = new Shipment();
            var shipmentDa = new ShipmentDA();
            try
            {
                var ds = shipmentDa.GetByContractId(id);
                shipment = CBO<Shipment>.FillObject_From_DataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return shipment;
        }
    }
}

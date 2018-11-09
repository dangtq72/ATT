using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Import;
using ObjInfo.Import;
using NaviCommon;

namespace BusinessFacadeLayer.Import
{
    public class ContractBL
    {
        public List<Contract> Search(int currentPage, ref decimal totalRecord, string keySearch = "")
        {
            List<Contract> lstContract = new List<Contract>();
            var contractDa = new ContractDA();
            try
            {
                string p_contract_code = "";
                string p_contract_date = "";
                string p_import_object = "";
                string p_status = "";
                var arrKeySearch = keySearch.Split('|');
                if (arrKeySearch.Length >= 4)
                {
                    p_contract_code = arrKeySearch[0];
                    p_contract_date = arrKeySearch[1];
                    p_import_object = arrKeySearch[2];
                    p_status = arrKeySearch[3];
                }
                string p_to = Common.RecordOnpage.ToString();
                string p_from = CommonFuc.Get_From_To_Page(currentPage, ref p_to);

                var ds = contractDa.Search(p_contract_code, p_contract_date, p_import_object, p_status, p_from, p_to, ref totalRecord);
                lstContract = CBO<Contract>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                lstContract = new List<Contract>();
            }
            return lstContract;
        }

        public Contract GetById(decimal contractId)
        {
            Contract contract = new Contract();
            var contractDa = new ContractDA();
            try
            {
                var ds = contractDa.GetById(contractId);
                contract = CBO<Contract>.FillObject_From_DataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                contract = new Contract();
            }
            return contract;
        }

        public Contract GetByCode(string code)
        {
            Contract contract = new Contract();
            var contractDa = new ContractDA();
            try
            {
                var ds = contractDa.GetByCode(code);
                contract = CBO<Contract>.FillObject_From_DataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                contract = new Contract();
            }
            return contract;
        }

        public Contract GetByName(string name)
        {
            Contract contract = new Contract();
            var contractDa = new ContractDA();
            try
            {
                var ds = contractDa.GetByName(name);
                contract = CBO<Contract>.FillObject_From_DataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                contract = new Contract();
            }
            return contract;
        }

        public decimal Insert_ContainShipment(Contract contract, List<Shipment> shipments)
        {
            decimal _result = -1;
            var contractDa = new ContractDA();
            try
            {
                //_result = contractDa.InsertContract_ContainShipments(contract, shipments.ToArray());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                _result = -1;
            }
            return _result;
        }

        public decimal Update_ContainShipment(Contract contract, List<Shipment> shipments)
        {
            decimal _result = -1;
            var contractDa = new ContractDA();
            try
            {
                Shipment[] arrShipmentAdd = shipments.Where(s => s.Id == 0).ToArray();
                Shipment[] arrShipmentEdit = shipments.Where(s => s.Id > 0).ToArray();
                _result = contractDa.UpdateContract_ContainShipments(contract, arrShipmentAdd, arrShipmentEdit);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                _result = -1;
            }
            return _result;
        }
    }
}

using DataAccess;
using NaviCommon;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjInfo.Import;

namespace DataAccessLayer.Import
{
    public class ContractDA
    {
        public DataSet Search(string contractCode, string contractDate, string importObject, string status, string startAt, string endAt, ref decimal totalRecord)     
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_total_record", OracleDbType.Decimal, ParameterDirection.Output);
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_contract.proc_contract_search",
                    new OracleParameter("p_contract_code", OracleDbType.Varchar2, contractCode, ParameterDirection.Input),
                    new OracleParameter("p_contract_date", OracleDbType.Varchar2, contractDate, ParameterDirection.Input),
                    new OracleParameter("p_import_object", OracleDbType.Varchar2, importObject, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Varchar2, status, ParameterDirection.Input),
                    new OracleParameter("p_start_at", OracleDbType.Varchar2, startAt, ParameterDirection.Input),
                    new OracleParameter("p_end_at", OracleDbType.Varchar2, endAt, ParameterDirection.Input),
                    paramReturn,
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));

                totalRecord = Convert.ToDecimal(paramReturn.Value.ToString());
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        // Theo id
        public DataSet GetById(decimal contractId)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_contract.proc_contract_getbyid",
                    new OracleParameter("p_contract_id", OracleDbType.Decimal, contractId, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        // Theo mã hợp đồng
        public DataSet GetByCode(string contractCode)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_contract.proc_contract_getbycode",
                    new OracleParameter("p_contract_code", OracleDbType.Varchar2, contractCode, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        // Theo số hợp đồng
        public DataSet GetByName(string contractName)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_contract.proc_contract_getbyname",
                    new OracleParameter("p_contract_name", OracleDbType.Varchar2, contractName, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public decimal InsertContract (Contract contract, OracleTransaction trans)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "pkg_contract.proc_contract_insert",
                    new OracleParameter("p_contract_code", OracleDbType.Varchar2, contract.Contract_Code, ParameterDirection.Input),
                    new OracleParameter("p_contract_name", OracleDbType.Varchar2, contract.Contract_Name, ParameterDirection.Input),
                    new OracleParameter("p_contract_date", OracleDbType.Date, contract.Contract_Date, ParameterDirection.Input),
                    new OracleParameter("p_request_by", OracleDbType.Varchar2, contract.Request_By, ParameterDirection.Input),
                    new OracleParameter("p_import_object", OracleDbType.Decimal, contract.Import_Object, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Decimal, contract.Status, ParameterDirection.Input),
                    new OracleParameter("p_payment_type", OracleDbType.Varchar2, contract.Payment_Type, ParameterDirection.Input),
                    new OracleParameter("p_payment_status", OracleDbType.Decimal, contract.Payment_Status, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2, contract.Notes, ParameterDirection.Input),
                    new OracleParameter("p_created_by", OracleDbType.Varchar2, contract.Created_By, ParameterDirection.Input),
                    new OracleParameter("p_created_date", OracleDbType.Date, DateTime.Now, ParameterDirection.Input),
                    new OracleParameter("p_deleted", OracleDbType.Decimal, 0, ParameterDirection.Input),
                    new OracleParameter("p_contract_type", OracleDbType.Decimal, contract.Contract_Type, ParameterDirection.Input),
                    new OracleParameter("p_sign_contract_date", OracleDbType.Date,  contract.Sign_Contract_Date, ParameterDirection.Input),
                    new OracleParameter("p_price_type", OracleDbType.Decimal, contract.Price_Type, ParameterDirection.Input),
                    new OracleParameter("p_supplier_code", OracleDbType.Varchar2, contract.Supplier_Code, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal UpdateContract(Contract contract, OracleTransaction trans)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "pkg_todo.proc_contract_update",
                    new OracleParameter("p_id", OracleDbType.Decimal, contract.Id, ParameterDirection.Input),
                    new OracleParameter("p_contract_code", OracleDbType.Varchar2, contract.Contract_Code, ParameterDirection.Input),
                    new OracleParameter("p_contract_name", OracleDbType.Varchar2, contract.Contract_Name, ParameterDirection.Input),
                    new OracleParameter("p_contract_date", OracleDbType.Date, contract.Contract_Date, ParameterDirection.Input),
                    new OracleParameter("p_request_by", OracleDbType.Varchar2, contract.Request_By, ParameterDirection.Input),
                    new OracleParameter("p_import_object", OracleDbType.Decimal, contract.Import_Object, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Decimal, contract.Status, ParameterDirection.Input),
                    new OracleParameter("p_payment_type", OracleDbType.Varchar2, contract.Payment_Type, ParameterDirection.Input),
                    new OracleParameter("p_payment_status", OracleDbType.Decimal, contract.Payment_Status, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2, contract.Notes, ParameterDirection.Input),
                    new OracleParameter("p_modified_by", OracleDbType.Varchar2, contract.Modified_By, ParameterDirection.Input),
                    new OracleParameter("p_modified_date", OracleDbType.Date, DateTime.Now, ParameterDirection.Input),
                    new OracleParameter("p_deleted", OracleDbType.Decimal, 0, ParameterDirection.Input),
                    new OracleParameter("p_contract_type", OracleDbType.Decimal, contract.Contract_Type, ParameterDirection.Input),
                    new OracleParameter("p_sign_contract_date", OracleDbType.Date, contract.Sign_Contract_Date, ParameterDirection.Input),
                    new OracleParameter("p_price_type", OracleDbType.Decimal, contract.Price_Type, ParameterDirection.Input),
                    new OracleParameter("p_supplier_code", OracleDbType.Varchar2, contract.Supplier_Code, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        
        public decimal InsertContract_ContainShipments(Contract contract, Shipment[] shipments, ContractDetail[] contractDetails)
        {
            decimal _result = -1;
            var shipmentDa = new ShipmentDA();
            var contractDetailDa = new ContractDetailDA();
            try
            {
                using (var conn = new OracleConnection(Common.gConnectString))
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        _result = InsertContract(contract, trans);
                        if(_result >= 0 && shipments.Length > 0)
                        {
                            _result = shipmentDa.InsertShipments(shipments, trans);
                        }
                        if(_result >= 0 && contractDetails.Length > 0)
                        {
                            _result = contractDetailDa.InsertContractDetail(contractDetails, trans);
                        }
                        if(_result < 0)
                        {
                            trans.Rollback();
                        }
                        else
                        {
                            trans.Commit();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                _result = -1;
            }
            return _result;
        }

        public decimal UpdateContract_ContainShipments(Contract contract, Shipment[] shipments, ContractDetail[] contractDetails)
        {
            decimal _result = -1;
            var shipmentDa = new ShipmentDA();
            var contractDetailDa = new ContractDetailDA();
            try
            {
                var shipmentsAdd = shipments.Where(s => s.Id == 0).ToArray();
                var shipmentsEdit = shipments.Where(s => s.Id > 0).ToArray();
                var detailsAdd = contractDetails.Where(cd => cd.Contract_Detail_Id == 0).ToArray();
                var detailsEdit = contractDetails.Where(cd => cd.Contract_Detail_Id > 0).ToArray();
                using (var conn = new OracleConnection(Common.gConnectString))
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        _result = UpdateContract(contract, trans);

                        if (_result >= 0 && shipmentsAdd.Length > 0)
                        {
                            _result = shipmentDa.InsertShipments(shipmentsAdd, trans);
                        }
                        if (_result >= 0 && shipmentsEdit.Length > 0)
                        {
                            _result = shipmentDa.UpdateShipments(shipmentsEdit, trans);
                        }
                        if (_result >= 0 && detailsAdd.Length > 0)
                        {
                            _result = contractDetailDa.InsertContractDetail(detailsAdd, trans);
                        }
                        if (_result >= 0 && detailsEdit.Length > 0)
                        {
                            _result = contractDetailDa.UpdateContractDetail(detailsEdit, trans);
                        }
                        if (_result < 0)
                        {
                            trans.Rollback();
                        }
                        else
                        {
                            trans.Commit();
                        }
                    }
                    conn.Close();
                }
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

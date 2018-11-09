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
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        
        public decimal InsertShipments(Shipment[] shipments, OracleTransaction trans)
        {
            decimal _result = -1;
            try
            {
                var conn = new OracleConnection(Common.gConnectString);
                var cmd = new OracleCommand("pkg_shipment.proc_shipment_insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = trans;
                cmd.Parameters.Add("p_shipment_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_product_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_contract_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_status", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_billing_number", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_amount", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_total_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cont_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cont_numbers", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_count_volume", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_currency", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_currency_rate", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cost_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cost_price_usd", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_sale_price_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_sale_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_sale_price_usd", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_other_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_is_co_free_tax", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_lsd", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("p_etd", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("p_eta", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("p_port_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_port_out", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_port_in", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_distance", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_pack_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_request_object", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_import_object", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_intent_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_result", OracleDbType.Decimal, ParameterDirection.Output);

                foreach(var shipment in shipments)
                {
                    cmd.Parameters["p_shipment_code"].Value = shipment.Shipment_Code;
                    cmd.Parameters["p_product_code"].Value = shipment.Product_Code;
                    cmd.Parameters["p_contract_code"].Value = shipment.Contract_Code;
                    cmd.Parameters["p_status"].Value = shipment.Shipment_Code;
                    cmd.Parameters["p_billing_number"].Value = shipment.Status;
                    cmd.Parameters["p_amount"].Value = shipment.Amount;
                    cmd.Parameters["p_price"].Value = shipment.Price;
                    cmd.Parameters["p_total_price"].Value = shipment.Total_Price;
                    cmd.Parameters["p_cont_type"].Value = shipment.Cont_Type;
                    cmd.Parameters["p_cont_numbers"].Value = shipment.Cont_Numbers;
                    cmd.Parameters["p_cout_volume"].Value = shipment.Cont_Volume;
                    cmd.Parameters["p_currency"].Value = shipment.Currency;
                    cmd.Parameters["p_currency_rate"].Value = shipment.Currency_Rate;
                    cmd.Parameters["p_cost_price"].Value = shipment.Cost_Price;
                    cmd.Parameters["p_cost_price_usd"].Value = shipment.Cost_Price_Usd;
                    cmd.Parameters["p_sale_price_type"].Value = shipment.Sale_Price_Type;
                    cmd.Parameters["p_sale_price"].Value = shipment.Sale_Price;
                    cmd.Parameters["p_sale_price_usd"].Value = shipment.Sale_Price_Usd;
                    cmd.Parameters["p_other_price"].Value = shipment.Other_Price;
                    cmd.Parameters["p_is_co_free_tax"].Value = shipment.Is_CO_Free_Tax;
                    cmd.Parameters["p_lsd"].Value = shipment.LSD;
                    cmd.Parameters["p_etd"].Value = shipment.ETD;
                    cmd.Parameters["p_eta"].Value = shipment.ETA;
                    cmd.Parameters["p_port_code"].Value = shipment.Port_Code;
                    cmd.Parameters["p_port_out"].Value = shipment.Port_Out;
                    cmd.Parameters["p_port_in"].Value = shipment.Port_In;
                    cmd.Parameters["p_distance"].Value = shipment.Distance;
                    cmd.Parameters["p_pack_type"].Value = shipment.Pack_Type;
                    cmd.Parameters["p_request_object"].Value = shipment.Request_Object;
                    cmd.Parameters["p_import_object"].Value = shipment.Import_Object;
                    cmd.Parameters["p_intent_type"].Value = shipment.Intent_Type;
                    cmd.ExecuteNonQuery();
                    _result = Convert.ToInt32(cmd.Parameters["p_result"].Value);
                    if(_result < 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                _result = -1;
            }
            return _result;
        }

        public decimal UpdateShipments(Shipment[] shipments, OracleTransaction trans)
        {
            decimal _result = -1;
            try
            {
                var conn = new OracleConnection(Common.gConnectString);
                var cmd = new OracleCommand("pkg_shipment.proc_shipment_update", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = trans;
                cmd.Parameters.Add("p_id", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_shipment_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_product_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_contract_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_status", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_billing_number", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_amount", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_total_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cont_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cont_numbers", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cont_volume", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_currency", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_currency_rate", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cost_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cost_price_usd", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_sale_price_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_sale_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_sale_price_usd", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_other_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_is_co_free_tax", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_lsd", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("p_etd", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("p_eta", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("p_port_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_port_out", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_port_in", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_distance", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_pack_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_request_object", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_import_object", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_intent_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_result", OracleDbType.Decimal, ParameterDirection.Output);

                foreach (var shipment in shipments)
                {
                    cmd.Parameters["p_shipment_code"].Value = shipment.Shipment_Code;
                    cmd.Parameters["p_product_code"].Value = shipment.Product_Code;
                    cmd.Parameters["p_contract_code"].Value = shipment.Contract_Code;
                    cmd.Parameters["p_status"].Value = shipment.Shipment_Code;
                    cmd.Parameters["p_billing_number"].Value = shipment.Status;
                    cmd.Parameters["p_amount"].Value = shipment.Amount;
                    cmd.Parameters["p_price"].Value = shipment.Price;
                    cmd.Parameters["p_total_price"].Value = shipment.Total_Price;
                    cmd.Parameters["p_cont_type"].Value = shipment.Cont_Type;
                    cmd.Parameters["p_cont_numbers"].Value = shipment.Cont_Numbers;
                    cmd.Parameters["p_cont_volume"].Value = shipment.Cont_Volume;
                    cmd.Parameters["p_currency"].Value = shipment.Currency;
                    cmd.Parameters["p_currency_rate"].Value = shipment.Currency_Rate;
                    cmd.Parameters["p_cost_price"].Value = shipment.Cost_Price;
                    cmd.Parameters["p_cost_price_usd"].Value = shipment.Cost_Price_Usd;
                    cmd.Parameters["p_sale_price_type"].Value = shipment.Sale_Price_Type;
                    cmd.Parameters["p_sale_price"].Value = shipment.Sale_Price;
                    cmd.Parameters["p_sale_price_usd"].Value = shipment.Sale_Price_Usd;
                    cmd.Parameters["p_other_price"].Value = shipment.Other_Price;
                    cmd.Parameters["p_is_co_free_tax"].Value = shipment.Is_CO_Free_Tax;
                    cmd.Parameters["p_lsd"].Value = shipment.LSD;
                    cmd.Parameters["p_etd"].Value = shipment.ETD;
                    cmd.Parameters["p_eta"].Value = shipment.ETA;
                    cmd.Parameters["p_port_code"].Value = shipment.Port_Code;
                    cmd.Parameters["p_port_out"].Value = shipment.Port_Out;
                    cmd.Parameters["p_port_in"].Value = shipment.Port_In;
                    cmd.Parameters["p_distance"].Value = shipment.Distance;
                    cmd.Parameters["p_pack_type"].Value = shipment.Pack_Type;
                    cmd.Parameters["p_request_object"].Value = shipment.Request_Object;
                    cmd.Parameters["p_import_object"].Value = shipment.Import_Object;
                    cmd.Parameters["p_intent_type"].Value = shipment.Intent_Type;
                    cmd.ExecuteNonQuery();
                    _result = Convert.ToInt32(cmd.Parameters["p_result"].Value);
                    if (_result < 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                _result = -1;
            }
            return _result;
        }

        public decimal InsertContract_ContainShipments(Contract contract, Shipment[] shipments)
        {
            decimal _result = -1;
            try
            {
                using (var conn = new OracleConnection(Common.gConnectString))
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        _result = InsertContract(contract, trans);
                        if(_result >= 0)
                        {
                            _result = InsertShipments(shipments, trans);
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

        public decimal UpdateContract_ContainShipments(Contract contract, Shipment[] shipmentsAdd, Shipment[] shipmentsEdit)
        {
            decimal _result = -1;
            try
            {
                using (var conn = new OracleConnection(Common.gConnectString))
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        _result = UpdateContract(contract, trans);

                        if (_result >= 0 && shipmentsAdd.Length > 0)
                        {
                            _result = InsertShipments(shipmentsAdd, trans);
                        }
                        if (_result >= 0 && shipmentsEdit.Length > 0)
                        {
                            _result = UpdateShipments(shipmentsEdit, trans);
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

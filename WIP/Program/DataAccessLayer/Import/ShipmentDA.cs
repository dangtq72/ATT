
namespace DataAccessLayer.Import
{
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

    public class ShipmentDA
    {
        public DataSet Search(string shipmentCode, string contractCode, string productCode, string billingNumber, string status, string requestObject, 
            string importObject, string startAt, string endAt, ref decimal totalRecord)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_total_record", OracleDbType.Decimal, ParameterDirection.Output);
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_shipment.proc_shipment_search",
                    new OracleParameter("p_shipment_code", OracleDbType.Varchar2, shipmentCode, ParameterDirection.Input),
                    new OracleParameter("p_contract_code", OracleDbType.Varchar2, contractCode, ParameterDirection.Input),
                    new OracleParameter("p_product_code", OracleDbType.Varchar2, productCode, ParameterDirection.Input),
                    new OracleParameter("p_billing_number", OracleDbType.Varchar2, billingNumber, ParameterDirection.Input),
                    new OracleParameter("p_request_object", OracleDbType.Varchar2, requestObject, ParameterDirection.Input),
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

        public DataSet GetByContractId(decimal contractId)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_shipment.proc_shipment_getbycontract",
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

        public DataSet GetById(decimal id)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_shipment.proc_shipment_getbyid",
                    new OracleParameter("p_id", OracleDbType.Decimal, id, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
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
                cmd.Parameters.Add("p_cont_numbers", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cont_volume", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_currency_rate", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cost_price", OracleDbType.Decimal, ParameterDirection.Input);
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
                cmd.Parameters.Add("p_cont_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_currency", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_booking_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_request_change_order", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_eta_expected", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("p_form_sale_type", OracleDbType.Varchar2, ParameterDirection.Input);
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
                    cmd.Parameters["p_booking_type"].Value = shipment.Booking_Type;
                    cmd.Parameters["p_request_change_order"].Value = shipment.Request_Change_Order;
                    cmd.Parameters["p_eta_expected"].Value = shipment.ETA_Expected;
                    cmd.Parameters["p_form_sale_type"].Value = shipment.Form_Sale_Type;
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
                cmd.Parameters.Add("p_cont_numbers", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cont_volume", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_currency_rate", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_cost_price", OracleDbType.Decimal, ParameterDirection.Input);
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
                cmd.Parameters.Add("p_cont_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_currency", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_booking_type", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_request_change_order", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_eta_expected", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("p_form_sale_type", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_result", OracleDbType.Decimal, ParameterDirection.Output);

                foreach (var shipment in shipments)
                {
                    cmd.Parameters["p_id"].Value = shipment.Id;
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
                    cmd.Parameters["p_booking_type"].Value = shipment.Booking_Type;
                    cmd.Parameters["p_request_change_order"].Value = shipment.Request_Change_Order;
                    cmd.Parameters["p_eta_expected"].Value = shipment.ETA_Expected;
                    cmd.Parameters["p_form_sale_type"].Value = shipment.Form_Sale_Type;
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
    }
}

using DataAccess;
using NaviCommon;
using ObjInfo.ModuleOrders;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ModuleOrder
{
    public class OrdersDA
    {
        public DataSet GetAll_Order()
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_order.proc_Order_getall",
                   new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public DataSet GetOrderByID(decimal order_id)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_order.proc_Order_getbyID",
                   new OracleParameter("p_id", OracleDbType.Decimal, order_id, ParameterDirection.Input),
                   new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public decimal InsertOrder(OrderInfo Obj_Info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_order.proc_order_insert",
                    new OracleParameter("p_order_type", OracleDbType.Decimal, Obj_Info.Order_Type, ParameterDirection.Input),
                    new OracleParameter("p_shipment_code", OracleDbType.Varchar2, Obj_Info.Shipment_Code, ParameterDirection.Input),
                    new OracleParameter("p_customer_code", OracleDbType.Varchar2, Obj_Info.Customer_Code, ParameterDirection.Input),
                    new OracleParameter("p_address", OracleDbType.Varchar2, Obj_Info.Address, ParameterDirection.Input),
                    new OracleParameter("p_order_date", OracleDbType.Date, Obj_Info.Order_Date, ParameterDirection.Input),
                    new OracleParameter("p_deliver_from_date", OracleDbType.Date, Obj_Info.Delivery_From_Date, ParameterDirection.Input),
                    new OracleParameter("p_deliver_to_date", OracleDbType.Date, Obj_Info.Delivery_To_Date, ParameterDirection.Input),
                    new OracleParameter("p_sale_man", OracleDbType.Varchar2, Obj_Info.Sale_Man, ParameterDirection.Input),
                    new OracleParameter("p_amount", OracleDbType.Decimal, Obj_Info.Amount, ParameterDirection.Input),
                    new OracleParameter("p_price", OracleDbType.Decimal, Obj_Info.Price, ParameterDirection.Input),
                    new OracleParameter("p_total_price", OracleDbType.Decimal, Obj_Info.Total_Price, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Decimal, Obj_Info.Status, ParameterDirection.Input),
                    new OracleParameter("p_is_delivery_in_port", OracleDbType.Decimal, Obj_Info.Is_Delivery_In_Port, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2, Obj_Info.Notes, ParameterDirection.Input),
                    new OracleParameter("p_createdby", OracleDbType.Varchar2, Obj_Info.CreatedBy, ParameterDirection.Input),
                    new OracleParameter("p_createddate", OracleDbType.Date, DateTime.Now, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal UpdateOrder(OrderInfo Obj_Info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_order.proc_order_update",
                    new OracleParameter("p_id", OracleDbType.Decimal, Obj_Info.ID, ParameterDirection.Input),
                    new OracleParameter("p_order_code", OracleDbType.Varchar2, Obj_Info.Order_Code, ParameterDirection.Input),
                    new OracleParameter("p_order_type", OracleDbType.Decimal, Obj_Info.Order_Type, ParameterDirection.Input),
                    new OracleParameter("p_shipment_code", OracleDbType.Varchar2, Obj_Info.Shipment_Code, ParameterDirection.Input),
                    new OracleParameter("p_customer_code", OracleDbType.Varchar2, Obj_Info.Customer_Code, ParameterDirection.Input),
                    new OracleParameter("p_address", OracleDbType.Varchar2, Obj_Info.Address, ParameterDirection.Input),
                    new OracleParameter("p_order_date", OracleDbType.Date, Obj_Info.Order_Date, ParameterDirection.Input),
                    new OracleParameter("p_deliver_from_date", OracleDbType.Date, Obj_Info.Delivery_From_Date, ParameterDirection.Input),
                    new OracleParameter("p_deliver_to_date", OracleDbType.Date, Obj_Info.Delivery_To_Date, ParameterDirection.Input),
                    new OracleParameter("p_sale_man", OracleDbType.Varchar2, Obj_Info.Sale_Man, ParameterDirection.Input),
                    new OracleParameter("p_amount", OracleDbType.Decimal, Obj_Info.Amount, ParameterDirection.Input),
                    new OracleParameter("p_price", OracleDbType.Decimal, Obj_Info.Price, ParameterDirection.Input),
                    new OracleParameter("p_total_price", OracleDbType.Decimal, Obj_Info.Total_Price, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Decimal, Obj_Info.Status, ParameterDirection.Input),
                    new OracleParameter("p_is_delivery_in_port", OracleDbType.Decimal, Obj_Info.Is_Delivery_In_Port, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2, Obj_Info.Notes, ParameterDirection.Input),
                    new OracleParameter("p_modifyby", OracleDbType.Varchar2, Obj_Info.ModifyBy, ParameterDirection.Input),
                    new OracleParameter("p_modifydate", OracleDbType.Date, Obj_Info.ModifyDate, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal DeleteOrder(decimal order_id)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_order.proc_delete_order",
                    new OracleParameter("p_id", OracleDbType.Decimal, order_id, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public DataSet Order_Search(string p_keySearch,string p_from , string p_to, ref decimal p_total_record)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_total_record", OracleDbType.Decimal, ParameterDirection.Output);
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_order.proc_order_search",
                    new OracleParameter("p_key_search", OracleDbType.Varchar2, p_keySearch, ParameterDirection.Input),
                    new OracleParameter("p_start_at", OracleDbType.Varchar2, p_from, ParameterDirection.Input),
                    new OracleParameter("p_end_at", OracleDbType.Varchar2, p_to, ParameterDirection.Input),
                    paramReturn,
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                p_total_record = Convert.ToDecimal(paramReturn.Value.ToString());
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}

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
    public class DeliveryDA
    {
        public DataSet GetAll_Delivery()
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_delivery.proc_delivery_getall",
                   new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public DataSet GetDeliveryByOrder(string order_code)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_delivery.proc_delivery_getbyOrder",
                   new OracleParameter("p_order_code", OracleDbType.Varchar2, order_code, ParameterDirection.Input),
                   new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public DataSet GetDeliveryByID(decimal delivery_id)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_delivery.proc_delivery_getbyId",
                   new OracleParameter("p_id", OracleDbType.Decimal, delivery_id, ParameterDirection.Input),
                   new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public decimal InsertDelivery(DeliveryInfo Obj_Info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_delivery.proc_delivery_insert",
                    new OracleParameter("p_delivery_type", OracleDbType.Decimal, Obj_Info.Delivery_Type, ParameterDirection.Input),
                    new OracleParameter("p_order_code", OracleDbType.Varchar2, Obj_Info.Order_Code, ParameterDirection.Input),
                    new OracleParameter("p_lst_cont", OracleDbType.Varchar2, Obj_Info.LST_CONT, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Decimal, Obj_Info.Status, ParameterDirection.Input),
                    new OracleParameter("p_delivery_date", OracleDbType.Date, Obj_Info.Delivery_Date, ParameterDirection.Input),
                    new OracleParameter("p_processor", OracleDbType.Varchar2, Obj_Info.Processor, ParameterDirection.Input),
                    new OracleParameter("p_createdby", OracleDbType.Varchar2, Obj_Info.Createdby, ParameterDirection.Input),
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
        public decimal UpdateDelivery(DeliveryInfo Obj_Info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_delivery.proc_delivery_update",
                    new OracleParameter("p_id", OracleDbType.Decimal, Obj_Info.ID, ParameterDirection.Input),
                    new OracleParameter("p_delivery_type", OracleDbType.Decimal, Obj_Info.Delivery_Type, ParameterDirection.Input),
                    new OracleParameter("p_order_code", OracleDbType.Varchar2, Obj_Info.Order_Code, ParameterDirection.Input),
                    new OracleParameter("p_lst_cont", OracleDbType.Varchar2, Obj_Info.LST_CONT, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Decimal, Obj_Info.Status, ParameterDirection.Input),
                    new OracleParameter("p_delivery_date", OracleDbType.Date, Obj_Info.Delivery_Date, ParameterDirection.Input),
                    new OracleParameter("p_modifyby", OracleDbType.Varchar2, Obj_Info.ModifyBy, ParameterDirection.Input),
                    new OracleParameter("p_modifydate", OracleDbType.Date, DateTime.Now, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal DeleteDelivery(decimal delivery_id)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_delivery.proc_delete_delivery",
                    new OracleParameter("p_id", OracleDbType.Decimal, delivery_id, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}

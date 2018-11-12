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
    public class Delivery_DetailDA
    {
        public DataSet GetDetailByDelivery(decimal delivery_id)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_delivery_detail.proc_getdelivery_detail",
                   new OracleParameter("p_delivery_id", OracleDbType.Decimal, delivery_id, ParameterDirection.Input),
                   new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public decimal InsertDeliveryDetail(Delivery_Detail_Info Obj_Info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_delivery_detail.proc_deli_detail_insert",
                    new OracleParameter("p_delivery_id", OracleDbType.Decimal, Obj_Info.Delivery_DetailID, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Decimal, Obj_Info.Status, ParameterDirection.Input),
                    new OracleParameter("p_url", OracleDbType.Varchar2, Obj_Info.Url, ParameterDirection.Input),
                    new OracleParameter("p_createdby", OracleDbType.Varchar2, Obj_Info.CreatedBy, ParameterDirection.Input),
                    new OracleParameter("p_createddate", OracleDbType.Date, Obj_Info.CreatedDate, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal UpdateDeliveryDetail(Delivery_Detail_Info Obj_Info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_delivery_detail.proc_deli_detail_update",
                    new OracleParameter("p_id", OracleDbType.Decimal, Obj_Info.ID, ParameterDirection.Input),
                    new OracleParameter("p_delivery_id", OracleDbType.Decimal, Obj_Info.Delivery_DetailID, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Decimal, Obj_Info.Status, ParameterDirection.Input),
                    new OracleParameter("p_url", OracleDbType.Varchar2, Obj_Info.Url, ParameterDirection.Input),
                    new OracleParameter("p_createdby", OracleDbType.Decimal, Obj_Info.CreatedBy, ParameterDirection.Input),
                    new OracleParameter("p_createddate", OracleDbType.Date, Obj_Info.CreatedDate, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal DeleteDelivery_Detail(decimal p_id)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_delivery_detail.proc_delete_delivery_detail",
                    new OracleParameter("p_id", OracleDbType.Decimal, p_id, ParameterDirection.Input),
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

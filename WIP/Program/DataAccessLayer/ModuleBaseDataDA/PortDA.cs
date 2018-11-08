using DataAccess;
using NaviCommon;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using ObjInfo.ModuleBaseData;

namespace DataAccessLayer.ModuleBaseDataDA
{
    public class PortDA
    {
        public static DataSet Port_Getall()
        {
            try
            {
                var p_return = OracleHelper.ExecuteDataset(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_port.pro_port_getAll",
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return p_return;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public static DataSet Port_GetbyId(decimal _portID)
        {
            try
            {
                var mDs = OracleHelper.ExecuteDataset(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_port.pro_port_getByID",
                    new OracleParameter("p_port_id", OracleDbType.Decimal, _portID, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return mDs;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public static DataSet Port_GetPage(string _port_text, int _start, int _end, string _orderBy, string _orderType, ref int _totalRecord)
        {
            try
            {
                var p_ReturnTotal = new OracleParameter("p_total_record", OracleDbType.Int32, ParameterDirection.Output) { Size = 9 };
                var p_Cursor = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                var Ds = OracleHelper.ExecuteDataset(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_product.p_port_getPage",
                    new OracleParameter("p_port_text", OracleDbType.Varchar2, _port_text, ParameterDirection.Input),
                    new OracleParameter("p_start", OracleDbType.Int32, _start, ParameterDirection.Input),
                    new OracleParameter("p_end", OracleDbType.Int32, _end, ParameterDirection.Input),
                    new OracleParameter("p_order_by", OracleDbType.Varchar2, _orderBy, ParameterDirection.Input),
                    new OracleParameter("p_order_type", OracleDbType.Varchar2, _orderType, ParameterDirection.Input),
                    p_ReturnTotal,
                    p_Cursor);
                _totalRecord = Convert.ToInt32(p_ReturnTotal.Value.ToString());
                return Ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public static int Port_Delete(decimal _portID)
        {
            try
            {
                var mReturn = new OracleParameter("p_return", OracleDbType.Int32, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_port.pro_port_delete",
                    new OracleParameter("p_port_id", OracleDbType.Decimal, _portID, ParameterDirection.Input),
                    mReturn);
                return Convert.ToInt32(mReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public static decimal Port_Insert(PortInfo _obj)
        {
            try
            {
                var pReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_port.pro_port_insert",
                    new OracleParameter("p_portCode", OracleDbType.Varchar2, _obj.Port_Code, ParameterDirection.Input),
                    new OracleParameter("p_portName", OracleDbType.Varchar2, _obj.Port_Name, ParameterDirection.Input),
                    new OracleParameter("p_type", OracleDbType.Varchar2, _obj.Type, ParameterDirection.Input),
                    new OracleParameter("p_note", OracleDbType.Varchar2, _obj.Notes, ParameterDirection.Input),
                    pReturn);
                return Convert.ToDecimal(pReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public static int Port_Update(PortInfo _obj)
        {
            try
            {
                var pReturn = new OracleParameter("p_return", OracleDbType.Int32, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_port.pro_port_update",
                    new OracleParameter("p_Id", OracleDbType.Decimal, _obj.Id, ParameterDirection.Input),
                    new OracleParameter("p_Port_Code", OracleDbType.Varchar2, _obj.Port_Code, ParameterDirection.Input),
                    new OracleParameter("p_Port_Name", OracleDbType.Varchar2, _obj.Port_Name, ParameterDirection.Input),
                    new OracleParameter("p_Type", OracleDbType.Varchar2, _obj.Type, ParameterDirection.Input),
                    new OracleParameter("p_note", OracleDbType.Varchar2, _obj.Notes, ParameterDirection.Input),
                    pReturn);
                return Convert.ToInt32(pReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}

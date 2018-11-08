using DataAccess;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using Oracle.DataAccess.Client;
using System;
using System.Data;
namespace DataAccessLayer.ModuleBaseDataDA
{
    public class LocationDA
    {
        public DataSet Location_GetAll()
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_location.proc_getall",
                new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public DataSet Location_Search(string p_key, string p_from, string p_to, ref decimal p_total_record)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_total_record", OracleDbType.Decimal, ParameterDirection.Output);
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_location.proc_search",
                    new OracleParameter("p_key", OracleDbType.Varchar2, p_key, ParameterDirection.Input),
                    new OracleParameter("p_from", OracleDbType.Varchar2, p_from, ParameterDirection.Input),
                    new OracleParameter("p_to", OracleDbType.Varchar2, p_to, ParameterDirection.Input),
                     paramReturn,
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                p_total_record = Convert.ToDecimal(paramReturn.Value.ToString());
                return _ds;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public decimal Insert(LocationInfo Obj_info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_location.Proc_Insert",
                    new OracleParameter("p_code", OracleDbType.Varchar2, Obj_info.Code, ParameterDirection.Input),
                    new OracleParameter("p_name", OracleDbType.Varchar2, Obj_info.Name, ParameterDirection.Input),
                    new OracleParameter("p_level_type", OracleDbType.Decimal, Obj_info.Level_type, ParameterDirection.Input),
                    new OracleParameter("p_parent_id", OracleDbType.Decimal, Obj_info.Parent_Id, ParameterDirection.Input),
                    new OracleParameter("p_parent_name", OracleDbType.Varchar2, Obj_info.Parent_Name, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2, Obj_info.Notes, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}

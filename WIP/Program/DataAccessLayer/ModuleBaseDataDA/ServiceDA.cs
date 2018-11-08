using DataAccess;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using Oracle.DataAccess.Client;
using System;
using System.Data;

namespace DataAccessLayer.ModuleBaseDataDA
{
    public class ServiceDA
    {
        public DataSet Service_GetAll()
        {
            try
            {
                var paramReturn = new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                return OracleHelper.ExecuteDataset(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "PKG_SERVICE.PROC_SERVICE_GETALL",
                    paramReturn);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public DataSet Service_Search(string p_keysearch,string p_from, string p_to, ref decimal p_total_record)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("P_TOTAL_RECORD", OracleDbType.Decimal, ParameterDirection.Output);
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "PKG_SERVICE.PROC_SEARCH_SERVICE",
                    new OracleParameter("P_KEY_SEARCH", OracleDbType.Varchar2, p_keysearch, ParameterDirection.Input),
                    new OracleParameter("p_from", OracleDbType.Varchar2, p_from, ParameterDirection.Input),
                    new OracleParameter("p_to", OracleDbType.Varchar2, p_to, ParameterDirection.Input),
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
        public decimal Service_Insert (ServiceInfo Obj_Info)
        {
            try
            {
                var paramReturn = new OracleParameter("P_RETURN", OracleDbType.Int32, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "PKG_SERVICE.PROC_INSERT_SERVICE",
                    new OracleParameter("P_SERVICE_ID", OracleDbType.Decimal, Obj_Info.Service_Id, ParameterDirection.Input),
                    new OracleParameter("P_SERVICE_NAME", OracleDbType.Varchar2, Obj_Info.Service_Name, ParameterDirection.Input),
                    new OracleParameter("P_DESCRIPTION", OracleDbType.Varchar2, Obj_Info.Description, ParameterDirection.Input),
                    new OracleParameter("P_TYPE", OracleDbType.Decimal, Obj_Info.Type, ParameterDirection.Input),
                    new OracleParameter("P_AVARTAR", OracleDbType.Varchar2, Obj_Info.Avartar, ParameterDirection.Input),
                    new OracleParameter("P_ADDONORDER", OracleDbType.Decimal, Obj_Info.AddOnOrder, ParameterDirection.Input),
                    new OracleParameter("P_PRICE", OracleDbType.Decimal, Obj_Info.Price, ParameterDirection.Input),
                    new OracleParameter("P_COURSE_ID", OracleDbType.Decimal, Obj_Info.Course_Id, ParameterDirection.Input),
                    new OracleParameter("P_CREATEDBY", OracleDbType.Varchar2, Obj_Info.CreatedBy, ParameterDirection.Input),
                    new OracleParameter("P_CREATEDDATE", OracleDbType.Date, Obj_Info.CreatedDate, ParameterDirection.Input),
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

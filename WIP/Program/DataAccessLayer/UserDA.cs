using DataAccess;
using NaviCommon;
using ObjInfo;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class UserDA
    {
        public DataSet User_GetAll()
        {
            try
            {
                var paramReturn = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                return OracleHelper.ExecuteDataset(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_user.proc_user_getall",
                    paramReturn);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public DataSet User_GetById(decimal id)
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_user.proc_getbyid",
                    new OracleParameter("p_id", OracleDbType.Decimal, id, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public DataSet User_Search(string p_key, string p_from, string p_to, ref decimal p_total_record)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_total_record", OracleDbType.Decimal, ParameterDirection.Output);
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_user.proc_search_user",
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
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public decimal User_Insert(UserInfo Obj_info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_user.Proc_Insert",
                    new OracleParameter("p_user_name", OracleDbType.Varchar2, Obj_info.User_Name, ParameterDirection.Input),
                    new OracleParameter("p_password", OracleDbType.Varchar2, Obj_info.Password, ParameterDirection.Input),
                    new OracleParameter("p_user_type", OracleDbType.Decimal, Obj_info.User_Type, ParameterDirection.Input),
                    new OracleParameter("p_group_id", OracleDbType.Decimal, Obj_info.Group_Id, ParameterDirection.Input),
                    new OracleParameter("p_created_by", OracleDbType.Varchar2, Obj_info.Created_By, ParameterDirection.Input),
                    new OracleParameter("p_created_date", OracleDbType.Date, Obj_info.Created_Date, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal User_Update(UserInfo Obj_info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_user.Proc_Update",
                    new OracleParameter("p_user_id", OracleDbType.Decimal, Obj_info.User_Id, ParameterDirection.Input),
                    new OracleParameter("p_user_name", OracleDbType.Varchar2, Obj_info.User_Name, ParameterDirection.Input),
                    new OracleParameter("p_password", OracleDbType.Varchar2, Obj_info.Password, ParameterDirection.Input),
                    new OracleParameter("p_user_type", OracleDbType.Decimal, Obj_info.User_Type, ParameterDirection.Input),
                    new OracleParameter("p_group_id", OracleDbType.Decimal, Obj_info.Group_Id, ParameterDirection.Input),
                    new OracleParameter("p_created_by", OracleDbType.Varchar2, Obj_info.Created_By, ParameterDirection.Input),
                    new OracleParameter("p_created_date", OracleDbType.Date, Obj_info.Created_Date, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal User_Delete(decimal p_id)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_user.proc_deleted",
                  new OracleParameter("p_id", OracleDbType.Decimal, p_id, ParameterDirection.Input),
                  paramReturn);

                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public DataSet CHECK_lOGIN(string user_name, string password)
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_user.proc_checkLogin",
                    new OracleParameter("p_user_name", OracleDbType.Varchar2, user_name, ParameterDirection.Input),
                    new OracleParameter("p_password", OracleDbType.Varchar2, password, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}

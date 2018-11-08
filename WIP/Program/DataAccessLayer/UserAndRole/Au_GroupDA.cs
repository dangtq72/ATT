using DataAccess;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using ObjInfo.UserAndRole;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UserAndRole
{
    public class Au_GroupDA
    {
        public DataSet GetAll()
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_au_group.proc_getall",
                new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet GetById(decimal id)
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_au_group.proc_getbyid",
                    new OracleParameter("p_group_id", OracleDbType.Decimal, id, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Search(string p_key, string p_from, string p_to, ref decimal p_total_record)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_total_record", OracleDbType.Decimal, ParameterDirection.Output);
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_au_group.proc_search",
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

        public decimal Delete(decimal p_id)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_au_group.proc_deleted",
                  new OracleParameter("p_group_id", OracleDbType.Decimal, p_id, ParameterDirection.Input),
                  paramReturn);

                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Insert(Au_GroupInfo au_group)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_au_group.Proc_Insert",
                    new OracleParameter("p_group_name", OracleDbType.Varchar2, au_group.Group_Name, ParameterDirection.Input),
                    new OracleParameter("p_description", OracleDbType.Varchar2, au_group.Description, ParameterDirection.Input),
                    new OracleParameter("p_user_type", OracleDbType.Decimal, au_group.User_Type, ParameterDirection.Input),
                    new OracleParameter("p_created_by", OracleDbType.Varchar2, au_group.Created_By, ParameterDirection.Input),
                    new OracleParameter("p_created_date", OracleDbType.Date, au_group.Created_Date, ParameterDirection.Input),
                    new OracleParameter("p_modify_by", OracleDbType.Varchar2, au_group.Modify_By, ParameterDirection.Input),
                    new OracleParameter("p_modify_date", OracleDbType.Date, au_group.Modify_Date, ParameterDirection.Input),
                    new OracleParameter("p_deleted", OracleDbType.Decimal, au_group.Deleted, ParameterDirection.Input),
                   
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Update(Au_GroupInfo au_group)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_au_group.proc_update",
                    new OracleParameter("p_group_id", OracleDbType.Decimal, au_group.Group_Id, ParameterDirection.Input),
                    new OracleParameter("p_group_name", OracleDbType.Varchar2, au_group.Group_Name, ParameterDirection.Input),
                    new OracleParameter("p_description", OracleDbType.Varchar2, au_group.Description, ParameterDirection.Input),
                    new OracleParameter("p_user_type", OracleDbType.Decimal, au_group.User_Type, ParameterDirection.Input),
                    new OracleParameter("p_created_by", OracleDbType.Varchar2, au_group.Created_By, ParameterDirection.Input),
                    new OracleParameter("p_created_date", OracleDbType.Decimal, au_group.Created_Date, ParameterDirection.Input),
                    new OracleParameter("p_modify_by", OracleDbType.Varchar2, au_group.Modify_By, ParameterDirection.Input),
                    new OracleParameter("p_modify_date", OracleDbType.Decimal, au_group.Modify_Date, ParameterDirection.Input),
                    new OracleParameter("p_deleted", OracleDbType.Decimal, au_group.Deleted, ParameterDirection.Input),
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

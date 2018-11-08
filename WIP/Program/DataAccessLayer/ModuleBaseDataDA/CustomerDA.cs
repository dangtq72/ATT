using DataAccess;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ModuleBaseDataDA
{
    public class CustomerDA
    {
        public DataSet Customer_GetAll()
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_customer.proc_getall",
                new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public DataSet Customer_GetById(decimal id)
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_customer.proc_getbyid",
                    new OracleParameter("p_id", OracleDbType.Decimal, id, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public DataSet Customer_Search(string p_key, string p_from, string p_to, ref decimal p_total_record)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_total_record", OracleDbType.Decimal, ParameterDirection.Output);
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_customer.proc_search",
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

        public decimal Insert(CustomerInfo Obj_info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_customer.Proc_Insert",
                    new OracleParameter("p_customer_code", OracleDbType.Varchar2, Obj_info.Customer_Code, ParameterDirection.Input),
                    new OracleParameter("p_customer_name", OracleDbType.Varchar2, Obj_info.Customer_Name, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2, Obj_info.Notes, ParameterDirection.Input),
                    new OracleParameter("p_phone", OracleDbType.Varchar2, Obj_info.Phone, ParameterDirection.Input),
                    new OracleParameter("p_fax", OracleDbType.Varchar2, Obj_info.Fax, ParameterDirection.Input),
                    new OracleParameter("p_email", OracleDbType.Varchar2, Obj_info.Email, ParameterDirection.Input),
                    new OracleParameter("p_created_by", OracleDbType.Varchar2, Obj_info.Created_by, ParameterDirection.Input),
                    new OracleParameter("p_created_date", OracleDbType.Date, Obj_info.Created_date, ParameterDirection.Input),
                    new OracleParameter("p_modify_by", OracleDbType.Varchar2, Obj_info.modify_by, ParameterDirection.Input),
                    new OracleParameter("p_modify_date", OracleDbType.Date, Obj_info.modify_date, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal Update(CustomerInfo Obj_info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_customer.Proc_Update",
                    new OracleParameter("p_ID", OracleDbType.Varchar2, Obj_info.ID, ParameterDirection.Input),
                    new OracleParameter("p_customer_code", OracleDbType.Varchar2, Obj_info.Customer_Code, ParameterDirection.Input),
                    new OracleParameter("p_customer_name", OracleDbType.Varchar2, Obj_info.Customer_Name, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2, Obj_info.Notes, ParameterDirection.Input),
                    new OracleParameter("p_phone", OracleDbType.Varchar2, Obj_info.Phone, ParameterDirection.Input),
                    new OracleParameter("p_fax", OracleDbType.Varchar2, Obj_info.Fax, ParameterDirection.Input),
                    new OracleParameter("p_email", OracleDbType.Varchar2, Obj_info.Email, ParameterDirection.Input),
                    new OracleParameter("p_modify_by", OracleDbType.Varchar2, Obj_info.modify_by, ParameterDirection.Input),
                    new OracleParameter("p_modify_date", OracleDbType.Date, Obj_info.modify_date, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal Delete(decimal p_id)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_customer.proc_deleted",
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
    }
}

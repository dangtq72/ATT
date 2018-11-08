using DataAccess;
using NaviCommon;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using ObjInfo.ToDo;

namespace DataAccessLayer.Todo
{
    public class ToDoDA
    {
        public DataSet GetAll()
        {
            try
            {
                var paramReturn = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                return OracleHelper.ExecuteDataset(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_todo.proc_todo_getall",
                    paramReturn);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }


        public DataSet Search(string name, string status, string type, string startAt, string endAt, ref decimal totalRecord)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_total_record", OracleDbType.Decimal, ParameterDirection.Output);
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_todo.proc_todo_search",
                    new OracleParameter("p_name", OracleDbType.Varchar2, name, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Varchar2, status, ParameterDirection.Input),
                    new OracleParameter("p_type", OracleDbType.Varchar2, type, ParameterDirection.Input),
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

        public DataSet GetByCode(decimal code, int type)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_todo.proc_todo_getbycode",
                    new OracleParameter("p_code", OracleDbType.Decimal, code, ParameterDirection.Input),
                    new OracleParameter("p_type", OracleDbType.Decimal, type, ParameterDirection.Input));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public decimal Insert(ToDoInfo todo)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_todo.proc_todo_insert",
                    new OracleParameter("p_type", OracleDbType.Decimal, todo.Type, ParameterDirection.Input),
                    new OracleParameter("p_code", OracleDbType.Decimal, todo.Code, ParameterDirection.Input),
                    new OracleParameter("p_content", OracleDbType.Varchar2, todo.Content, ParameterDirection.Input),
                    new OracleParameter("p_request_by", OracleDbType.Varchar2, todo.Request_By, ParameterDirection.Input),
                    new OracleParameter("p_request_date", OracleDbType.Date, DateTime.Now, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Decimal, todo.Status, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Update(ToDoInfo todo)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_todo.proc_todo_insert",
                    new OracleParameter("p_type", OracleDbType.Decimal, todo.Type, ParameterDirection.Input),
                    new OracleParameter("p_code", OracleDbType.Decimal, todo.Code, ParameterDirection.Input),
                    new OracleParameter("p_processor_by", OracleDbType.Varchar2, todo.Processor_By, ParameterDirection.Input),
                    new OracleParameter("p_processor_date", OracleDbType.Date, DateTime.Now, ParameterDirection.Input),
                    new OracleParameter("p_status", OracleDbType.Decimal, todo.Status, ParameterDirection.Input),
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

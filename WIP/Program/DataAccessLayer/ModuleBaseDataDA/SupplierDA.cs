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
    public class SupplierDA
    {
        public DataSet GetAll()
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_supplier.proc_getall",
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
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_supplier.proc_getbyid",
                    new OracleParameter("p_id", OracleDbType.Decimal, id, ParameterDirection.Input),
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
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_supplier.proc_search",
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
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_supplier.proc_deleted",
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

        public decimal Insert(SupplierInfo supplier)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_supplier.Proc_Insert",
                    new OracleParameter("p_code", OracleDbType.Varchar2, supplier.Code, ParameterDirection.Input),
                    new OracleParameter("p_name", OracleDbType.Varchar2, supplier.Name, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2, supplier.Notes, ParameterDirection.Input),
                    new OracleParameter("p_phone", OracleDbType.Varchar2, supplier.Phone, ParameterDirection.Input),
                    new OracleParameter("p_fax", OracleDbType.Varchar2, supplier.Fax, ParameterDirection.Input),
                    new OracleParameter("p_email", OracleDbType.Varchar2, supplier.Email, ParameterDirection.Input),
                    new OracleParameter("p_website", OracleDbType.Varchar2, supplier.Website, ParameterDirection.Input),
                    new OracleParameter("p_nation", OracleDbType.Int16, supplier.Nation, ParameterDirection.Input),
                    new OracleParameter("p_number_contract", OracleDbType.Int16, supplier.Number_Contract, ParameterDirection.Input),
                    new OracleParameter("p_created_by", OracleDbType.Varchar2, supplier.Created_by, ParameterDirection.Input),
                    new OracleParameter("p_created_date", OracleDbType.Date, supplier.Created_date, ParameterDirection.Input),
                   
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Update(SupplierInfo supplier)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_supplier.proc_update",
                     new OracleParameter("p_id", OracleDbType.Decimal, supplier.Id, ParameterDirection.Input),
                    new OracleParameter("p_code", OracleDbType.Varchar2, supplier.Code, ParameterDirection.Input),
                    new OracleParameter("p_name", OracleDbType.Varchar2, supplier.Name, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2, supplier.Notes, ParameterDirection.Input),
                    new OracleParameter("p_phone", OracleDbType.Varchar2, supplier.Phone, ParameterDirection.Input),
                    new OracleParameter("p_fax", OracleDbType.Varchar2, supplier.Fax, ParameterDirection.Input),
                    new OracleParameter("p_email", OracleDbType.Varchar2, supplier.Email, ParameterDirection.Input),
                    new OracleParameter("p_website", OracleDbType.Varchar2, supplier.Website, ParameterDirection.Input),
                    new OracleParameter("p_nation", OracleDbType.Decimal, supplier.Nation, ParameterDirection.Input),
                    new OracleParameter("p_number_contract", OracleDbType.Decimal, supplier.Number_Contract, ParameterDirection.Input),
                    new OracleParameter("p_created_by", OracleDbType.Varchar2, supplier.Created_by, ParameterDirection.Input),
                    new OracleParameter("p_created_date", OracleDbType.Date, supplier.Created_date, ParameterDirection.Input),
                     new OracleParameter("p_deleted", OracleDbType.Decimal, supplier.Delete, ParameterDirection.Input),
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

using DataAccess;
using NaviCommon;
using ObjInfo.Import;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Import
{
    public class Contrac_LogisticDA
    {
        public decimal InsertContract_Logistic(Contrac_logistic Obj_Info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_contract_logistic.proc_logistic_insert",
                    new OracleParameter("p_contract_code", OracleDbType.Varchar2, Obj_Info.Contract_code, ParameterDirection.Input),
                    new OracleParameter("p_product_code", OracleDbType.Varchar2, Obj_Info.Product_code, ParameterDirection.Input),
                    new OracleParameter("p_atz_recv_cert_date", OracleDbType.Date, Obj_Info.Atz_Recv_Cert_Date, ParameterDirection.Input),
                    new OracleParameter("p_decla_open_date", OracleDbType.Date, Obj_Info.Decla_Open_Date, ParameterDirection.Input),
                    new OracleParameter("p_decla_number", OracleDbType.Varchar2, Obj_Info.Decla_Number, ParameterDirection.Input),
                    new OracleParameter("p_clearance_expec_date", OracleDbType.Date, Obj_Info.Clearance_Expec_Date, ParameterDirection.Input),
                    new OracleParameter("p_clearance_date", OracleDbType.Date, Obj_Info.Clearance_Date, ParameterDirection.Input),
                    new OracleParameter("p_exp_storage_cont_date", OracleDbType.Date, Obj_Info.Exp_Storage_Cont_Date, ParameterDirection.Input),
                    new OracleParameter("p_exp_storage_bark_date", OracleDbType.Date, Obj_Info.Exp_Storage_Bark_Date, ParameterDirection.Input),
                    new OracleParameter("p_exp_storage_space_date", OracleDbType.Date, Obj_Info.Exp_Storage_Space_Date, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2,Obj_Info.Notes, ParameterDirection.Input),
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
        public decimal UpdateContract_Logistic(Contrac_logistic Obj_Info)
        {
            try
            {
                OracleParameter paramReturn = new OracleParameter("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "pkg_contract_logistic.proc_logistic_update",
                    new OracleParameter("p_id", OracleDbType.Decimal, Obj_Info.ID, ParameterDirection.Input),
                    new OracleParameter("p_contract_code", OracleDbType.Varchar2, Obj_Info.Contract_code, ParameterDirection.Input),
                    new OracleParameter("p_product_code", OracleDbType.Varchar2, Obj_Info.Product_code, ParameterDirection.Input),
                    new OracleParameter("p_atz_recv_cert_date", OracleDbType.Date, Obj_Info.Atz_Recv_Cert_Date, ParameterDirection.Input),
                    new OracleParameter("p_decla_open_date", OracleDbType.Date, Obj_Info.Decla_Open_Date, ParameterDirection.Input),
                    new OracleParameter("p_decla_number", OracleDbType.Varchar2, Obj_Info.Decla_Number, ParameterDirection.Input),
                    new OracleParameter("p_clearance_expec_date", OracleDbType.Date, Obj_Info.Clearance_Expec_Date, ParameterDirection.Input),
                    new OracleParameter("p_clearance_date", OracleDbType.Date, Obj_Info.Clearance_Date, ParameterDirection.Input),
                    new OracleParameter("p_exp_storage_cont_date", OracleDbType.Date, Obj_Info.Exp_Storage_Cont_Date, ParameterDirection.Input),
                    new OracleParameter("p_exp_storage_bark_date", OracleDbType.Date, Obj_Info.Exp_Storage_Bark_Date, ParameterDirection.Input),
                    new OracleParameter("p_exp_storage_space_date", OracleDbType.Date, Obj_Info.Exp_Storage_Space_Date, ParameterDirection.Input),
                    new OracleParameter("p_notes", OracleDbType.Varchar2, Obj_Info.Notes, ParameterDirection.Input),
                    new OracleParameter("p_modifiedby", OracleDbType.Varchar2, Obj_Info.ModifiedBy, ParameterDirection.Input),
                    new OracleParameter("p_modifieddate", OracleDbType.Date, DateTime.Now, ParameterDirection.Input),
                    paramReturn);
                return Convert.ToDecimal(paramReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }

        }
        // Theo số Contract
        public DataSet GetByContrac(string contractName)
        {
            try
            {
                DataSet _ds = OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_contract_logistic.proc_logistic_getbycontract",
                    new OracleParameter("p_contract_code", OracleDbType.Varchar2, contractName, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return _ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}

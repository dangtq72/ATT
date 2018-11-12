using DataAccess;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using ObjInfo.PO;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.PO
{
    class Po_HeaderDA
    {
       
        public DataSet Po_header_GetAll()
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_Po_header.proc_Po_header_GetAll",
                new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }


        public decimal Po_Header_Insert(
        decimal p_id, string p_po_code, string p_pr_code, string p_po_no, string p_supplier_code, DateTime p_po_date, string p_price_type, string p_port_out, string p_payment_type, DateTime p_lsd, decimal p_cont_type, decimal p_pack_type, string p_packing_detail, decimal p_total_amount, decimal p_status, string p_reject_reason, string p_notes, string p_created_by, DateTime p_created_date, string p_modify_by, DateTime p_modify_date, decimal p_deleted)
        {
            try
            {
                OracleHelper.ExecuteNonQuery(Common.gConnectString, CommandType.StoredProcedure, "Pkg_Po_Header.Proc_Po_Header_Insert",
                new OracleParameter("p_id", OracleDbType.Decimal, p_id, ParameterDirection.Input),
                new OracleParameter("p_po_code", OracleDbType.Varchar2, p_po_code, ParameterDirection.Input),
                new OracleParameter("p_pr_code", OracleDbType.Varchar2, p_pr_code, ParameterDirection.Input),
                new OracleParameter("p_po_no", OracleDbType.Varchar2, p_po_no, ParameterDirection.Input),
                new OracleParameter("p_supplier_code", OracleDbType.Varchar2, p_supplier_code, ParameterDirection.Input),
                new OracleParameter("p_po_date", OracleDbType.Date, p_po_date, ParameterDirection.Input),
                new OracleParameter("p_price_type", OracleDbType.Varchar2, p_price_type, ParameterDirection.Input),
                new OracleParameter("p_port_out", OracleDbType.Varchar2, p_port_out, ParameterDirection.Input),
                new OracleParameter("p_payment_type", OracleDbType.Varchar2, p_payment_type, ParameterDirection.Input),
                new OracleParameter("p_lsd", OracleDbType.Date, p_lsd, ParameterDirection.Input),
                new OracleParameter("p_cont_type", OracleDbType.Decimal, p_cont_type, ParameterDirection.Input),
                new OracleParameter("p_pack_type", OracleDbType.Decimal, p_pack_type, ParameterDirection.Input),
                new OracleParameter("p_packing_detail", OracleDbType.Varchar2, p_packing_detail, ParameterDirection.Input),
                new OracleParameter("p_total_amount", OracleDbType.Decimal, p_total_amount, ParameterDirection.Input),
                new OracleParameter("p_status", OracleDbType.Decimal, p_status, ParameterDirection.Input),
                new OracleParameter("p_reject_reason", OracleDbType.Varchar2, p_reject_reason, ParameterDirection.Input),
                new OracleParameter("p_notes", OracleDbType.Varchar2, p_notes, ParameterDirection.Input),
                new OracleParameter("p_created_by", OracleDbType.Varchar2, p_created_by, ParameterDirection.Input),
                new OracleParameter("p_created_date", OracleDbType.Date, p_created_date, ParameterDirection.Input),
                new OracleParameter("p_modify_by", OracleDbType.Varchar2, p_modify_by, ParameterDirection.Input),
                new OracleParameter("p_modify_date", OracleDbType.Date, p_modify_date, ParameterDirection.Input),
                new OracleParameter("p_deleted", OracleDbType.Decimal, p_deleted, ParameterDirection.Input)); return 0;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }


     

    

    }
}

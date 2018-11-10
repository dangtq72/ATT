
namespace DataAccessLayer.Import
{
    using DataAccess;
    using NaviCommon;
    using Oracle.DataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ObjInfo.Import;
    public class ContractDetailDA
    {
        public decimal InsertContractDetail(ContractDetail[] contractDetails, OracleTransaction trans)
        {
            decimal _result = -1;
            try
            {
                var conn = new OracleConnection(Common.gConnectString);
                var cmd = new OracleCommand("pkg_contract_detail.proc_insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = trans;
                cmd.Parameters.Add("p_contract_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_product_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_bravo_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_product_name", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_country_name", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_firm", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_quantity", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_total_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_co_free_tax", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                foreach (var detail in contractDetails)
                {
                    cmd.Parameters["p_contract_code"].Value = detail.Contract_Code;
                    cmd.Parameters["p_product_code"].Value = detail.Product_Code;
                    cmd.Parameters["p_bravo_code"].Value = detail.Product_Code;
                    cmd.Parameters["p_product_name"].Value = detail.Product_Code;
                    cmd.Parameters["p_country_name"].Value = detail.Product_Code;
                    cmd.Parameters["p_firm"].Value = detail.Product_Code;
                    cmd.Parameters["p_quantity"].Value = detail.Quantity;
                    cmd.Parameters["p_price"].Value = detail.Price;
                    cmd.Parameters["p_total_price"].Value = detail.Total_Price;
                    cmd.Parameters["p_co_free_tax"].Value = detail.Co_Free_Tax;
                    
                    cmd.ExecuteNonQuery();
                    _result = Convert.ToInt32(cmd.Parameters["p_result"].Value);
                    if (_result < 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                _result = -1;
            }
            return _result;
        }

        public decimal UpdateContractDetail(ContractDetail[] contractDetails, OracleTransaction trans)
        {
            decimal _result = -1;
            try
            {
                var conn = new OracleConnection(Common.gConnectString);
                var cmd = new OracleCommand("pkg_contract_detail.proc_update", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = trans;
                cmd.Parameters.Add("p_contract_detail_id", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_contract_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_product_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_bravo_code", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_product_name", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_country_name", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_firm", OracleDbType.Varchar2, ParameterDirection.Input);
                cmd.Parameters.Add("p_quantity", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_total_price", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_co_free_tax", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("p_result", OracleDbType.Decimal, ParameterDirection.Output);
                foreach (var detail in contractDetails)
                {
                    cmd.Parameters["p_contract_detail_id"].Value = detail.Contract_Detail_Id;
                    cmd.Parameters["p_contract_code"].Value = detail.Contract_Code;
                    cmd.Parameters["p_product_code"].Value = detail.Product_Code;
                    cmd.Parameters["p_bravo_code"].Value = detail.Product_Code;
                    cmd.Parameters["p_product_name"].Value = detail.Product_Code;
                    cmd.Parameters["p_country_name"].Value = detail.Product_Code;
                    cmd.Parameters["p_firm"].Value = detail.Product_Code;
                    cmd.Parameters["p_quantity"].Value = detail.Quantity;
                    cmd.Parameters["p_price"].Value = detail.Price;
                    cmd.Parameters["p_total_price"].Value = detail.Total_Price;
                    cmd.Parameters["p_co_free_tax"].Value = detail.Co_Free_Tax;

                    cmd.ExecuteNonQuery();
                    _result = Convert.ToInt32(cmd.Parameters["p_result"].Value);
                    if (_result < 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                _result = -1;
            }
            return _result;
        }
    }
}

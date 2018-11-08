using DataAccess;
using NaviCommon;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjInfo.ModuleBaseData;

namespace DataAccessLayer.ModuleBaseDataDA
{
    public class ProductDA
    {
        public static DataSet Product_Getall()
        {
            try
            {
                var p_return = OracleHelper.ExecuteDataset(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_product.pro_product_getAll",
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return p_return;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public static DataSet Product_GetById(decimal _product_id)
        {
            try
            {
                var mDs = OracleHelper.ExecuteDataset(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_product.pro_product_getByID",
                    new OracleParameter("p_product_id", OracleDbType.Decimal, _product_id, ParameterDirection.Input),
                    new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
                return mDs;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public static DataSet Product_GetPage(string _product_text, int _start, int _end, string _orderBy, string _orderType, ref int _totalRecord)
        {
            try
            {
                var p_ReturnTotal = new OracleParameter("p_total_record", OracleDbType.Int32, ParameterDirection.Output) { Size = 9 };
                var p_Cursor = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                var Ds = OracleHelper.ExecuteDataset(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_product.p_product_getPage",
                    new OracleParameter("p_product_text", OracleDbType.Varchar2, _product_text, ParameterDirection.Input),
                    
                    new OracleParameter("p_start", OracleDbType.Int32, _start, ParameterDirection.Input),
                    new OracleParameter("p_end", OracleDbType.Int32, _end, ParameterDirection.Input),
                    new OracleParameter("p_order_by", OracleDbType.Varchar2, _orderBy, ParameterDirection.Input),
                    new OracleParameter("p_order_type", OracleDbType.Varchar2, _orderType, ParameterDirection.Input),
                    p_ReturnTotal,
                    p_Cursor);
                _totalRecord = Convert.ToInt32(p_ReturnTotal.Value.ToString());
                return Ds;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
        public static int Product_Delete(decimal _product_id)
        {
            try
            {
                var mReturn = new OracleParameter("m_return", OracleDbType.Int32, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_product.pro_product_delete",
                    new OracleParameter("p_product_id", OracleDbType.Decimal, _product_id, ParameterDirection.Input),
                    mReturn);
                return Convert.ToInt32(mReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public static decimal Product_Insert(Product_Info _obj)
        {
            try
            {
                var pReturn = new OracleParameter("p_return", OracleDbType.Decimal, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_product.pro_product_insert",
                    new OracleParameter("p_productCode", OracleDbType.Varchar2, _obj.Product_Code, ParameterDirection.Input),
                    new OracleParameter("p_productName", OracleDbType.Varchar2, _obj.Product_Name, ParameterDirection.Input),
                    new OracleParameter("p_bravoCode", OracleDbType.Varchar2,_obj.Bravo_Code, ParameterDirection.Input),
                    new OracleParameter("p_note", OracleDbType.Varchar2,_obj.Note, ParameterDirection.Input),
                    pReturn);
                return Convert.ToDecimal(pReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public static int Product_Update(Product_Info _obj )
        {
            try
            {
                var pReturn = new OracleParameter("p_return", OracleDbType.Int32, ParameterDirection.Output);
                OracleHelper.ExecuteNonQuery(
                    Common.gConnectString,
                    CommandType.StoredProcedure,
                    "pkg_product.pro_product_update",
                    new OracleParameter("p_productId", OracleDbType.Decimal, _obj.Product_Id, ParameterDirection.Input),
                    new OracleParameter("p_productCode", OracleDbType.Varchar2,_obj.Product_Code, ParameterDirection.Input),
                    new OracleParameter("p_productName", OracleDbType.Varchar2,_obj.Product_Name, ParameterDirection.Input),
                    new OracleParameter("p_bravoCode", OracleDbType.Varchar2,_obj.Bravo_Code, ParameterDirection.Input),
                    new OracleParameter("p_note", OracleDbType.Varchar2,_obj.Note, ParameterDirection.Input),
                    pReturn);
                return Convert.ToInt32(pReturn.Value.ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}

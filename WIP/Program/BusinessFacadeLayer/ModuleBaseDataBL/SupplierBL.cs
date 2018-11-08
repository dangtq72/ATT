using DataAccessLayer.ModuleBaseDataDA;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessFacadeLayer.ModuleBaseDataBL
{
    public class SupplierBL
    {
        public List<SupplierInfo> GetAll()
        {
            List<SupplierInfo> list = new List<SupplierInfo>();

            try
            {
                SupplierDA _da = new SupplierDA();
                list = CBO<SupplierInfo>.FillCollectionFromDataSet(_da.GetAll());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list;
        }
        public SupplierInfo GetbyId(decimal id)
        {
            List<SupplierInfo> list = new List<SupplierInfo>();

            try
            {
                SupplierDA _da = new SupplierDA();
                list = CBO<SupplierInfo>.FillCollectionFromDataSet(_da.GetById(id));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list[0];
        }
        public List<SupplierInfo> Search(string keysearch, ref decimal p_total_record, string p_from = "1", string p_to = "10")
        {
            List<SupplierInfo> list = new List<SupplierInfo>();
            SupplierDA _da = new SupplierDA();
            try
            {
                list = CBO<SupplierInfo>.FillCollectionFromDataSet(_da.Search(keysearch, p_from, p_to, ref p_total_record));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                list = new List<SupplierInfo>();
            }
            return list;
        }
        public decimal Insert(SupplierInfo supplier)
        {
            decimal ck = -1;
            try
            {
                SupplierDA _da = new SupplierDA();
                ck = _da.Insert(supplier);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return ck;
        }
        public decimal Update(SupplierInfo supplier)
        {
            decimal ck = -1;
            try
            {
                SupplierDA _da = new SupplierDA();
                ck = _da.Update(supplier);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return ck;
        }
        public decimal Delete(decimal id)
        {
            decimal ck = -1;
            try
            {
                SupplierDA _da = new SupplierDA();
                ck = _da.Delete(id);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return ck;
        }
    }
}

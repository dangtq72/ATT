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
    public class CustomerBL
    {
        public List<CustomerInfo> Customer_GetAll()
        {
            List<CustomerInfo> list = new List<CustomerInfo>();

            try
            {
                CustomerDA _da = new CustomerDA();
                list = CBO<CustomerInfo>.FillCollectionFromDataSet(_da.Customer_GetAll());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list;
        }
        public CustomerInfo Customer_GetById(decimal id)
        {
            CustomerInfo Obj_Info = new CustomerInfo();

            try
            {
                CustomerDA _da = new CustomerDA();
                Obj_Info = CBO<CustomerInfo>.FillObject_From_DataSet(_da.Customer_GetById(id));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return Obj_Info;
        }
        public List<CustomerInfo> Customer_Search(string keysearch, ref decimal p_total_record, string p_from = "1", string p_to = "10")
        {
            List<CustomerInfo> list = new List<CustomerInfo>();
            CustomerDA _da = new CustomerDA();
            try
            {
                list = CBO<CustomerInfo>.FillCollectionFromDataSet(_da.Customer_Search(keysearch, p_from, p_to, ref p_total_record));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                list = new List<CustomerInfo>();
            }
            return list;
        }
        public decimal Customer_Insert(CustomerInfo Obj_Info)
        {
            decimal ck = -1;
            try
            {
                CustomerDA _da = new CustomerDA();
                ck = _da.Insert(Obj_Info);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return ck;
        }
        public decimal Customer_Update(CustomerInfo Obj_Info)
        {
            decimal ck = -1;
            try
            {
                CustomerDA _da = new CustomerDA();
                ck = _da.Update(Obj_Info);
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
                CustomerDA _da = new CustomerDA();
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

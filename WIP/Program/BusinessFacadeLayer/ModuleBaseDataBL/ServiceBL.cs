using DataAccessLayer.ModuleBaseDataDA;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using System;
using System.Collections.Generic;

namespace BusinessFacadeLayer.ModuleBaseDataBL
{
    public class ServiceBL
    {
        public List<ServiceInfo> Service_GetAll()
        {
            List<ServiceInfo> list = new List<ServiceInfo>();

            try
            {
                ServiceDA _da = new ServiceDA();
                list = CBO<ServiceInfo>.FillCollectionFromDataSet(_da.Service_GetAll());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list;
        }
        public List<ServiceInfo> Service_Search(string p_key_search,ref decimal p_total_record, string p_from = "1", string p_to = "10")
        {
            List<ServiceInfo> list = new List<ServiceInfo>();
            ServiceDA _da = new ServiceDA();
            try
            {
                list = CBO<ServiceInfo>.FillCollectionFromDataSet(_da.Service_Search(p_key_search,p_from, p_to, ref p_total_record));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                list = new List<ServiceInfo>();
            }
            return list;
        }
        public decimal Insert_Service(ServiceInfo Obj_info)
        {
            try
            {
                ServiceDA _da = new ServiceDA();
                return _da.Service_Insert(Obj_info);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}

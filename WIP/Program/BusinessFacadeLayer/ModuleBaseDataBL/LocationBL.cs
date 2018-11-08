using DataAccessLayer.ModuleBaseDataDA;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using System;
using System.Collections.Generic;

namespace BusinessFacadeLayer.ModuleBaseDataBL
{
    public class LocationBL
    {
        public List<LocationInfo> Location_GetAll()
        {
            List<LocationInfo> list = new List<LocationInfo>();

            try
            {
                LocationDA _da = new LocationDA();
                list = CBO<LocationInfo>.FillCollectionFromDataSet(_da.Location_GetAll());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list;
        }
        public List<LocationInfo> Location_Search(string keysearch, ref decimal p_total_record, string p_from = "1", string p_to = "10")
        {
            List<LocationInfo> list = new List<LocationInfo>();
            LocationDA _da = new LocationDA();
            try
            {
                list = CBO<LocationInfo>.FillCollectionFromDataSet(_da.Location_Search(keysearch, p_from, p_to, ref p_total_record));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                list = new List<LocationInfo>();
            }
            return list;
        }
        public decimal Location_Insert(LocationInfo Obj_Info)
        {
            decimal ck = -1;
            try
            {
                LocationDA _da = new LocationDA();
                ck = _da.Insert(Obj_Info);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return ck;
        }
    }
}

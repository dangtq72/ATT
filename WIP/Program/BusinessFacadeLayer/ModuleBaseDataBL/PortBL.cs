using System;
using System.Collections.Generic;
using DataAccessLayer.ModuleBaseDataDA;
using NaviCommon;
using ObjInfo.ModuleBaseData;

namespace BusinessFacadeLayer.ModuleBaseDataBL
{
    public class PortBL
    {
        public static List<PortInfo> Port_GetAll()
        {
            var p_List = new List<PortInfo>();
            try
            {
                p_List = CBO<PortInfo>.FillCollectionFromDataSet(PortDA.Port_Getall());

            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return p_List;
        }
        public static PortInfo Port_GetByID(decimal _portId)
        {
            var p_object = new PortInfo();
            try
            {
                p_object = (PortInfo)CBO.FillObjectFromDataSet(PortDA.Port_GetbyId(_portId), typeof(PortInfo));
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return p_object;
        }
        public static List<PortInfo> Port_Getpage(
            string _portText,
            int _start,
            int _end,
            string _orderBy,
            string _orderType,
            ref int _totalRecord)
        {
            var p_lst = new List<PortInfo>();
            try
            {
                p_lst = CBO<PortInfo>.FillCollectionFromDataSet(PortDA.Port_GetPage(_portText, _start, _end, _orderBy, _orderType, ref _totalRecord));
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return p_lst;
        }
        public static int Port_Delete(decimal _portId)
        {
            try
            {
                return PortDA.Port_Delete(_portId);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public static decimal Port_Insert(PortInfo _obj)
        {
            try
            {
                return PortDA.Port_Insert(_obj);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public static int Port_Update(PortInfo _obj)
        {
            try
            {
                return PortDA.Port_Update(_obj);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }

    }
}

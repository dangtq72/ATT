using BusinessFacadeLayer.MemmoryBL;
using BusinessFacadeLayer.ModuleBaseDataBL;
using ObjInfo.Catalogue;
using ObjInfo.ModuleBaseData;
using ObjInfo.Nation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnThanh.Commons
{
    public class DataMemory
    {
        public static Hashtable c_hs_Allcode = new Hashtable();
        public static List<NationInfo> GetNation()
        {
            try
            {
                List<NationInfo> _lst = new List<NationInfo>();
                Memory_BL _bl = new Memory_BL();
                _lst =  _bl.GetNation();
                return _lst;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new List<NationInfo>();
            }
        }

        public static void Get_DB_Mem()
        {
            try
            {
                Get_AllCode();
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
        }

        static void Get_AllCode()
        {
            try
            {
                #region Allcode
                c_hs_Allcode.Clear();
                Memory_BL _AllCodeBL = new Memory_BL();
                List<AllCodeInfo> _lst_al = _AllCodeBL.GetAllCode();

                if (_lst_al.Count > 0)
                {
                    foreach (AllCodeInfo item in _lst_al)
                    {
                        if (c_hs_Allcode.ContainsKey(item.CdName + "|" + item.CdType) == false)
                        {
                            List<AllCodeInfo> _lst = new List<AllCodeInfo>();
                            _lst.Add(item);
                            c_hs_Allcode[item.CdName + "|" + item.CdType] = _lst;
                        }
                        else
                        {
                            List<AllCodeInfo> _lst = (List<AllCodeInfo>)c_hs_Allcode[item.CdName + "|" + item.CdType];
                            _lst.Add(item);
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
        }

        public static List<AllCodeInfo> AllCode_GetBy_CdTypeCdName(string p_cdtype, string p_cdname)
        {
            try
            {
                if (c_hs_Allcode.ContainsKey(p_cdname + "|" + p_cdtype))
                {
                    List<AllCodeInfo> _lst = new List<AllCodeInfo>();

                    List<AllCodeInfo> _lst_tem = (List<AllCodeInfo>)c_hs_Allcode[p_cdname + "|" + p_cdtype];

                    foreach (AllCodeInfo item in _lst_tem)
                        _lst.Add(item);

                    _lst = _lst.OrderBy(m => m.LSTODR).ToList();
                    return _lst;
                }
                else return new List<AllCodeInfo>();
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new List<AllCodeInfo>();
            }
        }

        public static List<AllCodeInfo> Get_AllCodeByCDTYPE(string cdtype)
        {
            List<AllCodeInfo> list = new List<AllCodeInfo>();
            try
            {
                if (c_hs_Allcode.ContainsKey(cdtype))
                {
                    List<AllCodeInfo> _lst = new List<AllCodeInfo>();

                    List<AllCodeInfo> _lst_tem = (List<AllCodeInfo>)c_hs_Allcode[cdtype];

                    foreach (AllCodeInfo item in _lst_tem)
                        _lst.Add(item);

                    _lst = _lst.OrderBy(m => m.LSTODR).ToList();
                    return _lst;
                }
                else
                    return new List<AllCodeInfo>();

            }
            catch (Exception ex)
            {
               
                NaviCommon.Common.log.Error(ex.ToString());
                return new List<AllCodeInfo>();
            }
           
        }
        public static List<SupplierInfo> Get_All_Supplier()
        {
            List<SupplierInfo> list = new List<SupplierInfo>();
            try
            {
                SupplierBL _BL = new SupplierBL();
                list = _BL.GetAll();
                return list;
            }
            catch (Exception ex)
            {

                NaviCommon.Common.log.Error(ex.ToString());
                return new List<SupplierInfo>();
            }

        }
        public static List<CarriersInfo> Get_All_Carriers()
        {
            List<CarriersInfo> list = new List<CarriersInfo>();
            try
            {
                CarriersBL _BL = new CarriersBL();
                list = _BL.GetAll();
                return list;
            }
            catch (Exception ex)
            {

                NaviCommon.Common.log.Error(ex.ToString());
                return new List<CarriersInfo>();
            }

        }

        public static List<PortInfo> Get_All_Port()
        {
            List<PortInfo> list = new List<PortInfo>();
            try
            {

                list = PortBL.Port_GetAll();
                list = list.Where(x => x.Type == Convert.ToInt16(NaviCommon.ATT_Enum.Port_Type.CangXuat)).ToList();
                return list;
            }
            catch (Exception ex)
            {

                NaviCommon.Common.log.Error(ex.ToString());
                return new List<PortInfo>();
            }

        }
    }
}
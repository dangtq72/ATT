using DataAccessLayer.ModuleBaseDataDA;
using DataAccessLayer.UserAndRole;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using ObjInfo.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessFacadeLayer.UserAndRole
{
    public class Au_GroupBL
    {
        public List<Au_GroupInfo> GetAll()
        {
            List<Au_GroupInfo> list = new List<Au_GroupInfo>();

            try
            {
                Au_GroupDA _da = new Au_GroupDA();
                list = CBO<Au_GroupInfo>.FillCollectionFromDataSet(_da.GetAll());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list;
        }
        public Au_GroupInfo GetbyId(decimal id)
        {
            List<Au_GroupInfo> list = new List<Au_GroupInfo>();

            try
            {
                Au_GroupDA _da = new Au_GroupDA();
                list = CBO<Au_GroupInfo>.FillCollectionFromDataSet(_da.GetById(id));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list[0];
        }
        public List<Au_GroupInfo> Search(string keysearch, ref decimal p_total_record, string p_from = "1", string p_to = "10")
        {
            List<Au_GroupInfo> list = new List<Au_GroupInfo>();
            Au_GroupDA _da = new Au_GroupDA();
            try
            {
                list = CBO<Au_GroupInfo>.FillCollectionFromDataSet(_da.Search(keysearch, p_from, p_to, ref p_total_record));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                list = new List<Au_GroupInfo>();
            }
            return list;
        }
        public decimal Insert(Au_GroupInfo _pbj)
        {
            decimal ck = -1;
            try
            {
                Au_GroupDA _da = new Au_GroupDA();
                ck = _da.Insert(_pbj);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return ck;
        }
        public decimal Update(Au_GroupInfo _pbj)
        {
            decimal ck = -1;
            try
            {
                Au_GroupDA _da = new Au_GroupDA();
                ck = _da.Update(_pbj);
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

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
    public class CarriersBL
    {
        public List<CarriersInfo> GetAll()
        {
            List<CarriersInfo> list = new List<CarriersInfo>();

            try
            {
                CarriersDA _da = new CarriersDA();
                list = CBO<CarriersInfo>.FillCollectionFromDataSet(_da.GetAll());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list;
        }
        public CarriersInfo GetbyId(decimal id)
        {
            List<CarriersInfo> list = new List<CarriersInfo>();

            try
            {
                CarriersDA _da = new CarriersDA();
                list = CBO<CarriersInfo>.FillCollectionFromDataSet(_da.GetById(id));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list[0];
        }
        public List<CarriersInfo> Search(string keysearch, ref decimal p_total_record, string p_from = "1", string p_to = "10")
        {
            List<CarriersInfo> list = new List<CarriersInfo>();
            CarriersDA _da = new CarriersDA();
            try
            {
                list = CBO<CarriersInfo>.FillCollectionFromDataSet(_da.Search(keysearch, p_from, p_to, ref p_total_record));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                list = new List<CarriersInfo>();
            }
            return list;
        }
        public decimal Insert(CarriersInfo carriers)
        {
            decimal ck = -1;
            try
            {
                CarriersDA _da = new CarriersDA();
                ck = _da.Insert(carriers);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return ck;
        }
        public decimal Update(CarriersInfo carriers)
        {
            decimal ck = -1;
            try
            {
                CarriersDA _da = new CarriersDA();
                ck = _da.Update(carriers);
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
                CarriersDA _da = new CarriersDA();
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

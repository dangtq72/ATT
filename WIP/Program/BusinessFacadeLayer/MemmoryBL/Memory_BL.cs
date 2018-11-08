using DataAccessLayer.ModuleMemmoryDA;
using NaviCommon;
using ObjInfo.Catalogue;
using ObjInfo.Nation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacadeLayer.MemmoryBL
{
    public class Memory_BL
    {
        #region AllCode
        private static readonly object SLockerAllCode = new object();

        private static List<AllCodeInfo> _sAllCodeCollectionInMemory;

        public static void LoadAllCodeToMemory()
        {
            lock (SLockerAllCode)
            {
                var ds = MemmoryDA.GetAllCode();
                var lstAllCode = CBO<AllCodeInfo>.FillCollectionFromDataSet(ds);
                _sAllCodeCollectionInMemory = lstAllCode;
            }
        }

        public static List<AllCodeInfo> GetAllInAllCode()
        {
            lock (SLockerAllCode)
            {
                return _sAllCodeCollectionInMemory;
            }
        }

        public static List<AllCodeInfo> GetAllCodeByCdName(string cdName)
        {
            lock (SLockerAllCode)
            {
                return _sAllCodeCollectionInMemory.Where(o => string.Equals(o.CdName, cdName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
        }

        public static List<AllCodeInfo> GetAllCodeByCdType(string cdType)
        {
            lock (SLockerAllCode)
            {
                return _sAllCodeCollectionInMemory.Where(o => string.Equals(o.CdType, cdType, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
        }
        #endregion

        #region Nation
        public List<NationInfo> GetNation()
        {
            List<NationInfo> list = new List<NationInfo>();

            try
            {
                MemmoryDA _da = new MemmoryDA();
                list = CBO<NationInfo>.FillCollectionFromDataSet(_da.GetNation());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list;
        }

        #endregion
        #region Allcode
        public List<AllCodeInfo> GetAllCode()
        {
            List<AllCodeInfo> list = new List<AllCodeInfo>();

            try
            {
               
                var ds = MemmoryDA.GetAllCode();
                list = CBO<AllCodeInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list;
        }
        #endregion
    }
}

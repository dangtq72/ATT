using DataAccess;
using NaviCommon;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ModuleMemmoryDA
{
    public class MemmoryDA
    {
        public DataSet GetNation()
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_nation.proc_getall",
                new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public static DataSet GetAllCode()
        {
            try
            {
                return OracleHelper.ExecuteDataset(Common.gConnectString, CommandType.StoredProcedure, "pkg_allcode.proc_getall",
                new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}

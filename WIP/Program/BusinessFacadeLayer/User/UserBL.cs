using DataAccessLayer;
using NaviCommon;
using ObjInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacadeLayer
{
    public class UserBL
    {
        public List<UserInfo> User_GetAll()
        {
            List<UserInfo> list = new List<UserInfo>();

            try
            {
                UserDA _da = new UserDA();
                list = CBO<UserInfo>.FillCollectionFromDataSet(_da.User_GetAll());
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return list;
        }
        public UserInfo User_GetById(decimal id)
        {
            UserInfo Obj_Info = new UserInfo();
            try
            {
                UserDA _da = new UserDA();
                Obj_Info = CBO<UserInfo>.FillObject_From_DataSet(_da.User_GetById(id));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return Obj_Info;
        }
        public List<UserInfo> User_Search(string p_key, ref decimal p_total_record, string p_from = "1", string p_to = "10")
        {
            List<UserInfo> list = new List<UserInfo>();
            UserDA _da = new UserDA();
            try
            {
                list = CBO<UserInfo>.FillCollectionFromDataSet(_da.User_Search(p_key,p_from, p_to, ref p_total_record));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                list = new List<UserInfo>();
            }
            return list;
        }
        public decimal User_Insert(UserInfo Obj_Info)
        {
            decimal ck = -1;
            try
            {
                UserDA _da = new UserDA();
                ck = _da.User_Insert(Obj_Info);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return ck;
        }
        public decimal User_Update(UserInfo Obj_Info)
        {
            decimal ck = -1;
            try
            {
                UserDA _da = new UserDA();
                ck = _da.User_Update(Obj_Info);
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
                UserDA _da = new UserDA();
                ck = _da.User_Delete(id);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return ck;
        }
        public UserInfo CheckLogin(string user_name, string pass)
        {
            UserInfo Obj_Info = new UserInfo();
            try
            {
                UserDA _da = new UserDA();
                Obj_Info = CBO<UserInfo>.FillObject_From_DataSet(_da.CHECK_lOGIN(user_name, pass));
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return Obj_Info;
        }
    }
}

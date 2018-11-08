using BusinessFacadeLayer.MemmoryBL;
using NaviCommon;
using ObjInfo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnThanh
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            LoadAllConfigData();
            Commons.DataMemory.Get_DB_Mem();

            Thread _thrSend_TTUser = new Thread(Send_TTUser);
            _thrSend_TTUser.IsBackground = true;
            _thrSend_TTUser.Start();
        }
        protected void LoadAllConfigData()
        {
            try
            {
                NaviCommon.Common.gConnectString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
               
            }
            catch (Exception)
            {
                //Common.log.Error("Không load được config: PercentDiscountRateAllOrder ");
                NaviCommon.Common.log.Error("Không load được config: PercentDiscountRateAllOrder ");
            }
        }
        void Send_TTUser()
        {
            try
            {
                while (true)
                {
                    UserInfo _obj = Commons.SendTTUser.Get_Insert_User();
                    if (_obj != null)
                    {
                        // gửi thông tin đến sđt hoặc email
                        // CustomerScheduleMatricesBL customerScheduleMatricesbl = new CustomerScheduleMatricesBL();
                        //customerScheduleMatricesbl.CustomerScheduleMatrices_Insert(_obj);
                    }
                }
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
        }
    }
}

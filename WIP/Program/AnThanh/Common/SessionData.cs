using ObjInfo;
using System;
using System.Web;

namespace AnThanh
{
    public class SessionData
    {
        public static UserInfo CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session["Account"] == null)
                {
                    return null;
                }
                else
                {
                    return (UserInfo)HttpContext.Current.Session["Account"];
                }
            }
            set
            {
                HttpContext.Current.Session["Account"] = value;
            }
        }
        /// <summary>
        /// Lấy dữ liệu từ session
        /// </summary>
        /// <param name="pKey">key của session </param>
        /// <param name="pObj">Values</param>
        /// <returns></returns>
        public static void SetDataSession(string pKey, object pObj)
        {
            try
            {
                HttpContext.Current.Session[pKey] = pObj;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
        }
    }
}
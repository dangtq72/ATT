using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;

namespace NaviCommon
{
    public class Common
    {
        // -- Default số bản ghi hiển thị trên 1 trang
        public const int constRecordOnPage = 10;
        public const string urlImport_File  = "/Content/ImportFile/";

        //public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("Log_Msg_ALL");
        //public static readonly log4net.ILog Log_MsgMarketData = log4net.LogManager.GetLogger("Log_Msg_MarketData");
        //public static readonly log4net.ILog Log_MsgDataFeed = log4net.LogManager.GetLogger("Log_Msg_DataFeed");

        static NaviCommon.MyQueue c_queue_send = new NaviCommon.MyQueue();
        public static string gConnectString = "";
        /// <summary>
        /// Luu trang thai ket noi toi services provideData
        /// </summary>
        public static bool ConnectedWCF = false;

        /// <summary>
        ///so ban ghi /1 trang 
        /// </summary>
        public static int RecordOnpage = 10;

        public static string c_TIME_EXP_CMND = "TIME_EXP_CMND";
        public static string c_TIME_EXP_CCCD = "TIME_EXP_CCCD";
        public static string c_TIME_EXP_HC = "TIME_EXP_HC";
        public static string c_EXP_PAY_DAY = "EXP_PAY_DAY";
        public static string c_PHONE_FAX = "PHONE_FAX";
        public static string c_ADDRESS = "ADDRESS";
        public static string c_ORG_NAME = "ORG_NAME";
        public static string c_RECORDONPAGE = "RECORDONPAGE";

    }
    internal static class DateTimeCommonData
    {
        internal const string DATE_FORMAT_N0 = "dd/MM/yyyy";
        internal const string DATE_FORMAT_Y2 = "yyMMdd";
        internal const string TIME_FORMAT_N0 = "HH:mm:ss";
        internal const string DATETIME_FORMAT_N0 = "dd/MM/yyyy - HH:mm:ss";
    }

}

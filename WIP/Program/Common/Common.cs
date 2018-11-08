using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVS_Common
{
    public class Common
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string constAssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); //System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static string gConnectString = "";
        public static string gConnectStringSQL = "";
        public const char Field = (char)0x02; //phan cach giua cac field
        public const char FieldValue = (char)0x01A;//phan cach giua field va value
        // -- Discount_Type
        public const int const_Discount_Rate  = 1;
        public const int const_Discount_Value = 2;
        // -- Default số bản ghi hiển thị trên 1 trang
        public const int constRecordOnPage = 20;

        public static readonly List<int> cLstRecordOnPage = new List<int> {10, 20, 30, 50 };

        public const string constPasswordSpecCharacter = "!#%";

        public const int AdministratorUserId = -99;
        public const string urlImage_mark = "/Content/Image/";
        //public const string urlImage_Product = "http://192.168.2.62:3333/Content/Image_Product/";
        public const string urlImage_Product = "/Content/Image_Product/";
        public const string urlImport_File = "/Content/ImportFile/";
        public const string urlBarcodeFileExp = "/Content/BarcodeFileExport/";
        public const string constFormLogin = "/Home/Index";
        public const string constFormQuyenTruyCap = "/Home/QuyenTruyCap";
        public const string constFormError = "/Home/Error";
        public static string dateTime_Now = DateTime.Now.ToString("dd/MM/yyyy");
        //danh sách các PRODUCTINSTANCE  ghi tạm thời
        public static Hashtable TEMP_PRODUCTINSTANCE = new Hashtable();
        // enum data
        public static string temp_enum_Agent_Branch = "AGENT_BRANCH";
        public static string temp_enum_Agent_Branch_Code = "CODE";

        //status của productinstance
        public static int product_in_store      = 1;
        public static int product_in_store_tran = 5;
        public static bool gLoadWhenResetPool = false;

        public static bool c_is_call_auto = false;
        public static bool c_is_call_auto_inventory = false;

        public static Hashtable cHashRegisterUser = new Hashtable();
    }
}

﻿using ObjInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Xml.Linq;

namespace NaviCommon
{
    public class CommonFuc
    {
        public const string strTimeFormat = "HH:mm:ss";
        public const string strDate = "dd/MM/yyyy";
        private static readonly Random rand = new Random();

        public static String FormatNumber(decimal pStr)
        {
            try
            {
                if (pStr != 0)
                {
                    return String.Format("{0:#,###}", pStr);
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return "0";
            }
        }

        /// <summary>
        /// Hàm làm tròn lên số double 1.2 ->2 ..
        /// </summary>
        /// <param name="pDoubleNum">Giá trị kiểu double </param>
        /// <returns>trả về kiểu Integer với giá trị làm tròn lên </returns>
        public static int RoundUp(double pDoubleNum)
        {
            try
            {
                return Convert.ToInt32(Math.Ceiling(pDoubleNum).ToString());
            }
            catch (Exception ex)
            {
                Common.log.Error("Loi Double : " + pDoubleNum.ToString() + ex.ToString());
                return -1;
            }
        }

        public static DateTime CurrentDate()
        {
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                //string IFormatDate = "dd/MM/yyyy HH:mm tt"; //khoong lay giay 
                string IFormatDate = "dd/MM/yyyy HH:mm:ss";
                string pStr = DateTime.Now.ToString(IFormatDate);
                return DateTime.ParseExact(pStr, IFormatDate, provider);

            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return DateTime.MinValue;
            }
        }
        /// <summary>
        /// Lấy ngày tháng duy nhất 
        /// </summary>
        /// <returns></returns>
        public static DateTime TruncDate()
        {
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                string IFormatDate = "dd/MM/yyyy";
                string pStr = DateTime.Now.ToString(IFormatDate);
                return DateTime.ParseExact(pStr, IFormatDate, provider);

            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Lay ten luu lai anh cho do bi trung ten khi tai anh len tu client
        /// </summary>
        /// <returns></returns>
        public static string GetImageNames()
        {
            try
            {
                string IFormatDate = "ddMMyyyyhhmmss";
                string pStr = DateTime.Now.ToString(IFormatDate);
                return pStr;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return DateTime.Now.ToString("ddMMyyyyhhmmss");
            }
        }

        /// <summary>
        /// truyền vào ngày tháng trả ra thứ mấy 
        /// </summary>
        /// <param name="pDate"></param>
        /// <returns></returns>
        public static string GetDayOfWeek(DateTime pDate, string pLanguage)
        {
            try
            {
                string pStr = "";
                int day = Convert.ToInt32(pDate.DayOfWeek);
                if (!string.IsNullOrEmpty(pLanguage))
                {
                    if (pLanguage.ToUpper() == "VI")
                    {
                        if (day == 1)
                        {
                            pStr = "Thứ hai";
                        }
                        else if (day == 2)
                        {
                            pStr = "Thứ ba";
                        }
                        else if (day == 3)
                        {
                            pStr = "Thứ tư";
                        }
                        else if (day == 4)
                        {
                            pStr = "Thứ năm";
                        }
                        else if (day == 5)
                        {
                            pStr = "Thứ sáu";
                        }
                        else if (day == 6)
                        {
                            pStr = "Thứ bẩy";
                        }
                        else if (day == 0)
                        {
                            pStr = "Chủ nhật";
                        }
                    }
                    else
                    {
                        if (day == 1)
                        {
                            pStr = "Monday";
                        }
                        else if (day == 2)
                        {
                            pStr = "Tuesday";
                        }
                        else if (day == 3)
                        {
                            pStr = "Wednesday";
                        }
                        else if (day == 4)
                        {
                            pStr = "Thursday";
                        }
                        else if (day == 5)
                        {
                            pStr = "Friday";
                        }
                        else if (day == 6)
                        {
                            pStr = "Saturday";
                        }
                        else if (day == 0)
                        {
                            pStr = "Sunday";
                        }
                    }
                }
                else
                {
                    if (day == 1)
                    {
                        pStr = "Monday";
                    }
                    else if (day == 2)
                    {
                        pStr = "Tuesday";
                    }
                    else if (day == 3)
                    {
                        pStr = "Wednesday";
                    }
                    else if (day == 4)
                    {
                        pStr = "Thursday";
                    }
                    else if (day == 5)
                    {
                        pStr = "Friday";
                    }
                    else if (day == 6)
                    {
                        pStr = "Saturday";
                    }
                    else if (day == 0)
                    {
                        pStr = "Sunday";
                    }
                }

                return pStr;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return "";
            }
        }

        public static string Create_OTP_Code()
        {
            try
            {
                // chu thuong 97 - 122
                // chu hoa 65 - 87
                // so 48 - 57
                StringBuilder sb = new StringBuilder();
                char c;
                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int _r = rand.Next(1, 2);
                    if (_r == 1)
                    {
                        c = Convert.ToChar(Convert.ToInt32(rand.Next(48, 57)));
                    }
                    else
                    {
                        c = Convert.ToChar(Convert.ToInt32(rand.Next(97, 122)));
                    }
                    sb.Append(c);
                }

                return sb.ToString().ToLower();
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Đọc file excel ra dataset
        /// </summary>
        /// <param name="filelocation">Tên file</param>
        public static DataSet ReadXlsxFile(string filelocation)
        {
            try
            {
                string HDR = "No";
                //string HDR = "Yes";

                string IMEX = "0";
                string strConn;
                //if (filelocation.Substring(filelocation.LastIndexOf('.')).ToLower() == ".xlsx")
                //    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filelocation + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
                //else
                //    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filelocation + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

                // IMEX=1 là excel hiển thị như thế nào thì nó sẽ đọc như thế
                // donght ko can check version nữa mặc định mình sẽ cài thằng 2013 nên ko cần check thằng thấp hơn .xls
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filelocation + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=" + IMEX + "\"";

                DataSet output = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(strConn))
                {
                    conn.Open();

                    DataTable schemaTable = conn.GetOleDbSchemaTable(
                        OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    foreach (DataRow schemaRow in schemaTable.Rows)
                    {
                        string sheet = schemaRow["TABLE_NAME"].ToString();

                        if (!sheet.EndsWith("_"))
                        {
                            try
                            {
                                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                                cmd.CommandType = CommandType.Text;

                                DataTable outputTable = new DataTable(sheet);
                                output.Tables.Add(outputTable);
                                new OleDbDataAdapter(cmd).Fill(outputTable);
                            }
                            catch (Exception ex)
                            {
                                Common.log.Error(ex.Message);
                            }
                        }
                    }
                }

                return output;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return null;
            }
        }

        public static DataSet FillDataSetFromExcel(string filePath)
        {
            try
            {
                DataSet ds_return = new DataSet();
                // Lưu file vao server
                //string filePath = Microsoft.SqlServer.Server.MapPath("/Content/FlexcelDesignFile/" + uploadFile.FileName);
                //uploadFile.SaveAs(filePath);

                // Đọc file Excel ra DataSet
                string file_extension = System.IO.Path.GetExtension(filePath);
                string connectionString_excel = "";
                switch (file_extension.ToUpper())
                {
                    case ".XLS": //Excel 97-03
                        connectionString_excel = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
                        break;
                    case ".XLSX": //Excel 07~
                        connectionString_excel = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"");
                        break;
                }
                OleDbConnection con = new OleDbConnection(connectionString_excel);
                con.Open();

                // Get lis SheetName in file
                List<string> lst_sheetname = new List<string>();
                DataTable dt = new DataTable();
                dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string item = dt.Rows[i]["TABLE_NAME"].ToString().Replace("'", "");
                    if (item.Contains("$"))
                        lst_sheetname.Add(item);
                }

                // Get data in file
                if (lst_sheetname.Count > 0)
                {
                    for (int sheet_index = 0; sheet_index < lst_sheetname.Count; sheet_index++)
                    {
                        OleDbDataAdapter cmd = new System.Data.OleDb.OleDbDataAdapter("select * from [" + lst_sheetname[sheet_index].ToString() + "]", con);
                        DataTable dt_data = new DataTable();
                        cmd.Fill(dt_data);
                        ds_return.Tables.Add(dt_data);
                    }
                }
                con.Close();

                // Return DataSet
                return ds_return;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        /// <summary>
        /// Định dạng lại cái số điện thoại nhập vào
        /// </summary>
        /// <param name="p_phone"></param>
        /// <returns></returns>
        public static string FormatPhone(string p_phone)
        {
            try
            {
                string result = p_phone.Replace(".", "").Replace(" ", "").Replace("+84", "0").Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "");
                string subStr = result.Substring(0, 2);
                string _kq = result.Substring(2, result.Length - 2);
                if (subStr == "84")
                {

                    result = "0" + _kq;

                }
                else
                {
                    if (result.IndexOf("0") != 0)
                    {
                        result = "0" + result;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return null;
            }
        }

        public static string Create_Random_Character(int p_number_get)
        {
            try
            {

                // chu thuong 97 - 122
                // chu hoa 65 - 87
                // so 48 - 57
                StringBuilder sb = new StringBuilder();
                char c;
                Random rand = new Random();
                for (int i = 0; i < p_number_get; i++)
                {
                    c = Convert.ToChar(rand.Next(97, 122));
                    sb.Append(c);
                }
                return sb.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return "";
            }
        }

        public static string Create_Random_Password()
        {
            try
            {
                // chu thuong 97 - 122
                // chu hoa 65 - 87
                // so 48 - 57
                StringBuilder sb = new StringBuilder();
                char c;
                //Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int _r = rand.Next(1, 4);
                    if (_r == 1)
                    {
                        c = Convert.ToChar(rand.Next(48, 57));
                    }
                    else
                    {
                        c = Convert.ToChar(rand.Next(97, 122));
                    }
                    sb.Append(c);
                }

                return sb.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách các children control của 1 parent control. Đây là các childen theo Logical, tức là các childen mà khai báo. 
        /// Ví dụ sử dụng: foreach (RibbonButton tb in FindLogicalChildren<RibbonButton>(this))
        /// {
        ///         _str = _str + tb.Name + ";";
        /// }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindLogicalChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {

                foreach (object _obj in LogicalTreeHelper.GetChildren(depObj))
                {
                    if (_obj != null && _obj is T)
                    {
                        yield return (T)_obj;
                    }

                    if (_obj is DependencyObject)
                    {
                        foreach (T childOfChild in FindLogicalChildren<T>((DependencyObject)_obj))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Lay control cha cua 1 control bat ky
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public static T FindLogicalParent<T>(DependencyObject depObj) where T : DependencyObject
        {
            try
            {
                T parent = default(T);
                if (depObj != null)
                {
                    DependencyObject _obj = LogicalTreeHelper.GetParent(depObj);
                    parent = _obj as T;
                    if (parent == null)
                    {
                        parent = FindLogicalParent<T>(_obj);
                    }
                }
                return parent;
            }
            catch
            {
                return default(T);
            }
        }

        public static T FindFirstElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            if (count == 0)
                return null;

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);

                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    var result = FindFirstElementInVisualTree<T>(child);
                    if (result != null)
                        return result;

                }
            }
            return null;
        }

        public static bool CompareObject<T>(T Object1, T object2)
        {
            //Get the type of the object
            Type type = typeof(T);

            //return false if any of the object is false
            if (Object1 == null || object2 == null)
                return false;

            //Loop through each properties inside class and get values for the property from both the objects and compare
            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                // riêng đối vs thằng time (định kỳ tính) thì không xét
                if (property.Name == "Board_Time" || property.Name == "Time")
                    continue;

                if (property.Name != "ExtensionData")
                {
                    string Object1Value = string.Empty;
                    string Object2Value = string.Empty;
                    if (type.GetProperty(property.Name).GetValue(Object1, null) != null)
                        Object1Value = type.GetProperty(property.Name).GetValue(Object1, null).ToString();
                    if (type.GetProperty(property.Name).GetValue(object2, null) != null)
                        Object2Value = type.GetProperty(property.Name).GetValue(object2, null).ToString();
                    if (Object1Value.Trim() != Object2Value.Trim())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //public static DataSet Get_DataDB(string p_connection, string p_sql)
        //{
        //    try
        //    {
        //        return OracleHelper.ExecuteDataset(p_connection, CommandType.Text, p_sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        NaviCommon.Common.log.Error(ex.ToString());
        //        return new DataSet();
        //    }
        //}

        /// <summary>
        /// So sánh 2 thời gian T1 và T2, =  1 là T1 > T2, = 2 là T2 > T1, = 0 là T1 = T2
        /// </summary>
        public static int Compare_Timspan(string p_time_1, string p_time_2)
        {
            try
            {
                string[] _times_1 = p_time_1.Split(':');
                string[] _times_2 = p_time_2.Split(':');

                string t1 = "2015" + _times_1[0] + _times_1[1] + _times_1[2];
                string t2 = "2015" + _times_2[0] + _times_2[1] + _times_2[2];

                int _t_1 = Convert.ToInt32(t1);
                int _t_2 = Convert.ToInt32(t2);

                if (_t_1 > _t_2)
                    return 1;
                else if (_t_2 > _t_1)
                    return 2;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// Check xem lệnh có nằm trong khoảng thời gian cần check hay không, nếu không có khoảng thời gian check thì ko check lệnh đó
        /// </summary>
    

        public static string Get_From_To_Page(int p_CurrentPage, ref string p_to)
        {
            try
            {
                string p_from = ((p_CurrentPage - 1) * Common.RecordOnpage + 1).ToString();
                p_to = ((p_CurrentPage - 1) * Common.RecordOnpage + Common.RecordOnpage).ToString();

                return p_from;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                p_to = "10";
                return "1";
            }
        }

        public static string Get_HtmlPaging<T>(int p_total_record, int PCurrentPage, string pLoaiBanghi = "Bản ghi")
        {
            try
            {
                return Paging(PCurrentPage, Common.RecordOnpage, p_total_record, "jsPaging", pLoaiBanghi);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return "";
            }
        }

        public static string Get_HtmlPaging_2<T>(int p_total_record, int PCurrentPage, string pLoaiBanghi = "Bản ghi")
        {
            try
            {
                return Paging(PCurrentPage, Common.RecordOnpage, p_total_record, "jsPaging_2", pLoaiBanghi);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return "";
            }
        }

        public static string Paging(int pCurPage, int pRecordOnPage, int pTotalRecord, string p_js_function = "", string _str_loai_ban_ghi = "")
        {
            try
            {
                if (_str_loai_ban_ghi == "")
                {
                    _str_loai_ban_ghi = "Bản ghi";
                }
                if (p_js_function == "")
                {
                    p_js_function = "page";
                }
                string pStrPaging = "";
                double _dobTotalRec = Convert.ToDouble(pTotalRecord);
                int _TotalPage = NaviCommon.CommonFuc.RoundUp(_dobTotalRec / pRecordOnPage);
                pStrPaging = WritePaging(_TotalPage, pCurPage, pTotalRecord, pRecordOnPage, _str_loai_ban_ghi, p_js_function);
                return pStrPaging;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return "";
            }
        }

        public static string WritePaging(int iPageCount, int iCurrentPage, int iTotalRecords, int iPageSize, string pLoaiBanGhi, string p_jsfuncion = "")
        {
            try
            {
                if (p_jsfuncion == "")
                {
                    p_jsfuncion = "page";
                }
                string strPage = "";
                strPage += "<div id='d_page'>";
                // strPage += "<div id='d_total_rec'>" + "Có tổng " + iTotalRecords + " " + pLoaiBanGhi + "</div>";
                strPage += "<div id='d_total_rec'>" + "Có tổng " + iTotalRecords + " " + pLoaiBanGhi + " </div>";
                strPage += "<div id='d_number_of_page'>";
                if (iPageCount <= 1) return strPage;
                if (iCurrentPage > 1)
                {
                    //sangdd moi them dong 1 trở về trang đầu
                    strPage += "<li onclick=\"" + p_jsfuncion + "(1)\"><span id=\"first\"  href=\"\"><<</span></li>";

                    strPage += "<li onclick=\"" + p_jsfuncion + "('" + (iCurrentPage - 1) + "')\"><span id=\"back\"  href=\"\"><</span></li>";
                }
                if (iPageCount <= 5)
                {
                    for (int j = 0; j < iPageCount; j++)
                    {
                        if (iCurrentPage == (j + 1))
                        {
                            //HungTD rem doan nay
                            strPage += "<li style=\"background-color: #CDCDCD;\" onclick=\"" + p_jsfuncion + "(" + (j + 1) + ")\"><span class=\"a-active\" id=" + (j + 1) + "  href=\"\">" + (j + 1) + "</span></li>";
                        }
                        else
                        {
                            strPage += "<li onclick=\"" + p_jsfuncion + "(" + (j + 1) + ")\"><span id=" + (j + 1) + "  href=\"\">" + (j + 1) + "</span></li>";
                        }
                    }
                }
                else
                {
                    string cl = "";
                    int t;
                    int pagePreview = 0; //nếu đang ở trang 2 thì vẽ đc có 1 trang trước nó nên sẽ vẽ thêm 3 trang phía sau 
                    //default là vẽ 2 trang trc 2 trang sau 
                    int soTrangVeLui = 2;
                    if ((iPageCount - iCurrentPage) == 1)
                    {
                        soTrangVeLui = soTrangVeLui + 1;
                    }
                    else if ((iPageCount - iCurrentPage) == 0)
                    {
                        soTrangVeLui = soTrangVeLui + 2;
                    }
                    for (t = iCurrentPage - soTrangVeLui; t <= iCurrentPage; t++) //ve truoc 2 trang 
                    {
                        if (t < 1) continue;
                        cl = t == iCurrentPage ? "a-active" : "";
                        strPage += t == iCurrentPage ? "<li onclick=\"" + p_jsfuncion + "(" + (t) + ")\" style=\"background-color: #CDCDCD;\"><span class=" + cl + " id=" + (t) + "  href=\"\">" + (t) + "</span></li>"
                                    : "<li   onclick=\"" + p_jsfuncion + "(" + (t) + ")\"><span class=" + cl + " id=" + (t) + "  href=\"\">" + (t) + "</span></li>";
                        //strPage += "<li onclick=\"page(" + (t) + ")\"><span class=" + cl + " id=" + (t) + "  href=\"\">" + (t) + "</span></li>";
                        pagePreview++;
                    }
                    t = 0;
                    cl = "";
                    if (iCurrentPage == 1) //truong hop trang dau tien thi ve du 5 trang 
                    {
                        for (t = iCurrentPage + 1; t < iCurrentPage + 5; t++)
                        {
                            if (t >= t + 5 || t > iPageCount) continue;
                            cl = t == iCurrentPage ? "a-active" : "";
                            strPage += t == iCurrentPage ? "<li onclick=\"" + p_jsfuncion + "(" + (t) + ")\" style=\"background-color: #CDCDCD;\"><span class=" + cl + " id=" + (t) + "  href=\"\">" + (t) + "</span></li>"
                                     : "<li   onclick=\"" + p_jsfuncion + "(" + (t) + ")\"><span class=" + cl + " id=" + (t) + "  href=\"\">" + (t) + "</span></li>";
                            //strPage += "<li  onclick=\"page(" + (t) + ")\"><span class=" + cl + " id=" + (t) + "  href=\"\">" + (t) + "</span></li>";
                        }
                    }
                    else if (iCurrentPage > 1)  //truogn hop ma la trang lon hon 1 thi se ve 4 trang ke tiep + 1 trang truoc 
                    {
                        int incr = 5 - (pagePreview - 1);
                        for (t = iCurrentPage + 1; t < iCurrentPage + incr; t++)
                        {
                            if (t >= t + incr || t > iPageCount) continue;
                            cl = t == iCurrentPage ? "a-active" : "";
                            strPage += t == iCurrentPage ? "<li onclick=\"" + p_jsfuncion + "(" + (t) + ")\" style=\"background-color: #CDCDCD;\"><span class=" + cl + " id=" + (t) + "  href=\"\">" + (t) + "</span></li>"
                                     : "<li   onclick=\"" + p_jsfuncion + "(" + (t) + ")\"><span class=" + cl + " id=" + (t) + "  href=\"\">" + (t) + "</span></li>";
                            //strPage += "<li onclick=\"page(" + (t) + ")\"><span class=" + cl + " id=" + (t) + "  href=\"\">" + (t) + "</span></li>";
                        }
                    }

                }
                if (iCurrentPage < iPageCount)
                {
                    strPage += "<li onclick=\"" + p_jsfuncion + "('" + (iCurrentPage + 1) + "')\"><span id=\"next\"  href=\"\">></span></li>";
                    //sangdd moi them dong 1 trở về trang cuối
                    strPage += "<li onclick=\"" + p_jsfuncion + "(" + iPageCount + ")\"><span id=\"end\"  href=\"\">>></span></li>";
                }
                strPage += "</div>";
                strPage += "</div>";
                return strPage;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return string.Empty;
            }
        }

        public static string Get_File_name(ref string p_file_Path)
        {
            try
            {
                int _last_index_char = p_file_Path.LastIndexOf("\\");
                if (_last_index_char == -1)
                {
                    return p_file_Path;
                }
                string _file_name = p_file_Path.Substring(_last_index_char + 1);
                p_file_Path = p_file_Path.Substring(0, _last_index_char);

                return _file_name;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return null;
            }
        }

        public static string Encrypt(string toEncrypt)
        {
            try
            {
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                byte[] hashedBytes;
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(toEncrypt));
                StringBuilder s = new StringBuilder();
                foreach (byte _hashedByte in hashedBytes)
                {
                    s.Append(_hashedByte.ToString("x2"));
                }
                return s.ToString();
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return "";
            }
        }

        public static DataTable Rename_Colums_DataTable(DataTable p_dt, Dictionary<string, string> p_dic)
        {
            try
            {
                // ds_resuft.Tables[0].Columns["Str_Order_date"].ColumnName = "Ngày GD";
                // ds_resuft.Tables[0].Columns["Str_Order_date"].SetOrdinal(0);
                // if (p_dt.Columns.Contains(_colums))
                // p_dt.Columns.Remove(_colums);

                DataTable _dt = new DataTable();

                // tạo table với các cột là key của hash
                //foreach (DictionaryEntry de in p_hs_columns)
                //{
                foreach (KeyValuePair<string, string> pair in p_dic)
                {
                    string _column = (string)pair.Key;

                    DataColumn dc = new DataColumn();
                    dc.ColumnName = p_dt.Columns[_column].ColumnName;
                    dc.DataType = p_dt.Columns[_column].DataType;

                    _dt.Columns.Add(dc);
                }

                // Gán giá trị của table cũ vào table mới
                foreach (DataRow sourcerow in p_dt.Rows)
                {
                    DataRow destRow = _dt.NewRow();
                    foreach (KeyValuePair<string, string> pair in p_dic)
                    {
                        string _column = (string)pair.Key;
                        destRow[_column] = sourcerow[_column];
                    }
                    _dt.Rows.Add(destRow);
                }

                //Đổi tên cột thành value của hash
                foreach (KeyValuePair<string, string> pair in p_dic)
                {
                    string _column = (string)pair.Key;
                    string _name = (string)pair.Value;

                    _dt.Columns[_column].ColumnName = _name;
                }
                return _dt;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return null;
            }
        }

        #region Convert số sang chữ

        public static string NumberToTextVN(decimal total)
        {
            try
            {
                string rs = "";
                total = Math.Round(total, 0);
                string[] ch = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                string[] rch = { "lẻ", "mốt", "", "", "", "lăm" };
                string[] u = { "", "mươi", "trăm", "ngàn", "", "", "triệu", "", "", "tỷ", "", "", "ngàn", "", "", "triệu" };
                string nstr = total.ToString();

                int[] n = new int[nstr.Length];
                int len = n.Length;
                for (int i = 0; i < len; i++)
                {
                    n[len - 1 - i] = Convert.ToInt32(nstr.Substring(i, 1));
                }

                for (int i = len - 1; i >= 0; i--)
                {
                    if (i % 3 == 2)// số 0 ở hàng trăm
                    {
                        if (n[i] == 0 && n[i - 1] == 0 && n[i - 2] == 0) continue;//nếu cả 3 số là 0 thì bỏ qua không đọc
                    }
                    else if (i % 3 == 1) // số ở hàng chục
                    {
                        if (n[i] == 0)
                        {
                            if (n[i - 1] == 0) { continue; }// nếu hàng chục và hàng đơn vị đều là 0 thì bỏ qua.
                            else
                            {
                                rs += " " + rch[n[i]]; continue;// hàng chục là 0 thì bỏ qua, đọc số hàng đơn vị
                            }
                        }
                        if (n[i] == 1)//nếu số hàng chục là 1 thì đọc là mười
                        {
                            rs += " mười"; continue;
                        }
                    }
                    else if (i != len - 1)// số ở hàng đơn vị (không phải là số đầu tiên)
                    {
                        if (n[i] == 0)// số hàng đơn vị là 0 thì chỉ đọc đơn vị
                        {
                            if (i + 2 <= len - 1 && n[i + 2] == 0 && n[i + 1] == 0) continue;
                            rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                            continue;
                        }
                        if (n[i] == 1)// nếu là 1 thì tùy vào số hàng chục mà đọc: 0,1: một / còn lại: mốt
                        {
                            rs += " " + ((n[i + 1] == 1 || n[i + 1] == 0) ? ch[n[i]] : rch[n[i]]);
                            rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                            continue;
                        }
                        if (n[i] == 5) // cách đọc số 5
                        {
                            if (n[i + 1] != 0) //nếu số hàng chục khác 0 thì đọc số 5 là lăm
                            {
                                rs += " " + rch[n[i]];// đọc số 
                                rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                                continue;
                            }
                        }
                    }
                    rs += " " + ch[n[i]];
                    //rs += (rs == "" ? " " : ", ") + ch[n[i]];// đọc số
                    rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                }
                //if (rs[rs.Length - 1] != ' ')
                //    rs += " đồng";
                //else
                //    rs += "đồng";

                if (rs.Length > 2)
                {
                    string rs1 = rs.Substring(0, 2);
                    rs1 = rs1.ToUpper();
                    rs = rs.Substring(2);
                    rs = rs1 + rs;
                }
                return rs.Trim().Replace("lẻ,", "lẻ").Replace("mươi,", "mươi").Replace("trăm,", "trăm").Replace("mười,", "mười");
            }
            catch
            {
                return "";
            }
        }
        #endregion
    }

    public static class Extensions
    {
        public static string ToDelimitedString<T>(this IEnumerable<T> source, Func<T, string> func, string char_join)
        {
            return ToDelimitedString(source, char_join, func);
        }

        public static string ToDelimitedString<T>(this IEnumerable<T> source, string delimiter, Func<T, string> func)
        {
            return String.Join(delimiter, source.Select(func).ToArray());
        }
    }
}

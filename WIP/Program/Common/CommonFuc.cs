namespace NVS_Common
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CommonFunc
    {
        public const string DATEFORMAT = "dd/MM/yyyy";
        public const string DATETIMEFORMAT = "HH:mm - dd/MM/yyyy";

        public static DateTime ConvertString2Date(string str)
        {
            var provider = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                return DateTime.ParseExact(str, DATEFORMAT, provider);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime ConvertStringDateTime2DateTime(string str, string format = "")
        {
            var provider = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                return DateTime.ParseExact(str, !string.IsNullOrEmpty(format) ? format : DATETIMEFORMAT, provider);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public static bool CheckPasswordStrength(string p_Password)
        {
            try
            {
                var _numberMatch = 0;
                if (p_Password.Length < 8)
                    return false;

                if (Regex.IsMatch(p_Password, @"\d+")) _numberMatch++;  // check co chua so khong
                if (Regex.IsMatch(p_Password, @"[a-z]")) _numberMatch++; // check co chua chu thuong khong
                if (Regex.IsMatch(p_Password, @"[A-Z]")) _numberMatch++; // check co chua chu hoa khong
                if (Regex.IsMatch(p_Password, @"[!@#\$%\^&\*\?_~\-\(\);\.\+:]+")) _numberMatch++;

                if (CheckIsUnicode(p_Password)) _numberMatch++;
                if (CheckIsUnicode_Upper(p_Password)) _numberMatch++;

                return _numberMatch >= 3;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckIsUnicode_Upper(string p_unicode)
        {
            try
            {
                var pattern = new string[7];

                pattern[0] = "á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ";
                pattern[1] = "ó|ỏ|ò|ọ|õ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ";
                pattern[2] = "é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ";
                pattern[3] = "ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ";
                pattern[4] = "í|ì|ỉ|ị|ĩ";
                pattern[5] = "ý|ỳ|ỷ|ỵ|ỹ";
                pattern[6] = "đ";

                // kiểm tra xem có chữ tiếng việt thường hay không
                return pattern.Select(t => Regex.Matches(p_unicode, t.ToUpper())).Any(matchs => matchs.Count > 0);
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckNoneUnicodeAndSpecChar(string pStr)
        {
            try
            {
                return Regex.IsMatch(pStr, @"\w+");
            }
            catch
            {
                return false;
            }
        }

        public static string Encrypt(string toEncrypt)
        {
            try
            {
                var md5Hasher = new MD5CryptoServiceProvider();
                var encoder = new UTF8Encoding();
                var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(toEncrypt));
                var s = new StringBuilder();
                foreach (var _hashedByte in hashedBytes)
                {
                    s.Append(_hashedByte.ToString("x2"));
                }

                return s.ToString();
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return string.Empty;
            }
        }

        public static string Paging(
            int pCurentPage,
            int pRecordOnPage,
            int pTotalRecord,
            string pLanguage = "",
            string pFunction = "ChangePage",
            string pFuctionChange = "ChangeRecord",
            string idDivNumberRecordPerPage = "sltRecordPage")
        {
            try
            {
                const string ACTIVECLASS = "active";
                const string ABC1 = "</select>";

                var strDisplayRecord = "<label>Hiển thị </label><select id=\"" + idDivNumberRecordPerPage + "\" onchange=\"javascript:" + pFuctionChange + "();\">";
                var _abc = string.Empty;
                foreach (var item in Common.cLstRecordOnPage)
                {
                    if (pRecordOnPage == Common.constRecordOnPage)
                    {
                        _abc = _abc + "<option " + (item == Common.constRecordOnPage ? " selected " : " ") + "value = " + item + ">" + item + "</option>";
                    }
                    else
                    {
                        _abc = _abc + "<option " + (item == pRecordOnPage ? " selected " : " ") + "value = " + item + ">" + item + "</option>";
                    }
                }

                strDisplayRecord = strDisplayRecord + _abc + ABC1;

                var strPage = "  <div class=\"d-paging-left\">" + strDisplayRecord + " &nbsp;bản ghi trên <b>" + pTotalRecord + "</b> bản ghi</div>";

                var _dobTotalRec = Convert.ToDouble(pTotalRecord);
                var iPageCount = (int)Math.Ceiling(_dobTotalRec / pRecordOnPage);

                strPage += "<div class=\"d_number_of_page\" id=\"d_number_of_page\">";

                if (iPageCount > 1)
                {
                    if (pCurentPage > 1)
                    {
                        strPage += "<a class=\"prev\" href=\"javascript:" + pFunction + "(" + (pCurentPage - 1) + ");\"></a>";
                    }

                    if (iPageCount <= 5)
                    {
                        for (var j = 0; j < iPageCount; j++)
                        {
                            if (pCurentPage == (j + 1))
                            {
                                strPage += "<a class=\"" + ACTIVECLASS + "\" href=\"javascript:" + pFunction + "(" + (j + 1) + ");\">" + (j + 1) + "</a>";
                            }
                            else
                            {
                                strPage += "<a href=\"javascript:" + pFunction + "(" + (j + 1) + ");\">" + (j + 1) + "</a>";
                            }
                        }
                    }
                    else
                    {
                        // Hiển thị tràn đầu
                        if (pCurentPage > 3)
                        {
                            strPage += "<a href=\"javascript:" + pFunction + "(" + 1 + ");\">" + 1 + "</a>";
                            strPage += "<a class=\"dot\" href=\"javascript:;\">...</a>";
                        }

                        string cl;
                        int t;
                        var pagePreview = 0;
                        var soTrangVeLui = 2;
                        if (iPageCount - pCurentPage == 1)
                            soTrangVeLui = soTrangVeLui + 1;
                        else if (iPageCount - pCurentPage == 0)
                        {
                            soTrangVeLui = soTrangVeLui + 2;
                        }

                        for (t = pCurentPage - soTrangVeLui; t <= pCurentPage; t++)
                        {
                            if (t < 1) continue;
                            cl = t == pCurentPage ? ACTIVECLASS : string.Empty;
                            strPage += "<a class=\"" + cl + "\" href=\"javascript:" + pFunction + "(" + t + ");\">" + t + "</a>";
                            pagePreview++;
                        }

                        if (pCurentPage == 1)
                        {
                            // truong hop trang dau tien thi ve du 5 trang 
                            for (t = pCurentPage + 1; t < pCurentPage + 5; t++)
                            {
                                if (t >= t + 5 || t > iPageCount) continue;
                                cl = t == pCurentPage ? ACTIVECLASS : string.Empty;

                                strPage += "<a class=\"" + cl + "\" href=\"javascript:" + pFunction + "(" + t + ");\">" + t + "</a>";
                            }
                        }
                        else if (pCurentPage > 1)
                        {
                            // truogn hop ma la trang lon hon 1 thi se ve 4 trang ke tiep + 1 trang truoc 
                            var incr = 5 - (pagePreview - 1);
                            for (t = pCurentPage + 1; t < pCurentPage + incr; t++)
                            {
                                if (t >= t + incr || t > iPageCount) continue;
                                cl = t == pCurentPage ? ACTIVECLASS : string.Empty;
                                strPage += "<a class=\"" + cl + "\" href=\"javascript:" + pFunction + "(" + t + ");\">" + t + "</a>";
                            }
                        }

                        if (iPageCount - pCurentPage > 2)
                        {
                            // Hiển thị trang cuối 
                            strPage += "<a class=\"dot\" href=\"javascript:;\">...</a>";
                            strPage += "<a href=\"javascript:" + pFunction + "(" + iPageCount + ");\">" + iPageCount + "</a>";
                        }
                    }

                    if (pCurentPage < iPageCount)
                    {
                        strPage += "<a class=\"next\" href=\"javascript:" + pFunction + "(" + (pCurentPage + 1) + ");\"></a>";
                    }
                }

                strPage += "</div>";

                return strPage;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return string.Empty;
            }
        }

        public static string Get_File_name(ref string p_file_Path)
        {
            try
            {
                var _last_index_char = p_file_Path.LastIndexOf("\\", StringComparison.Ordinal);
                if (_last_index_char == -1)
                {
                    return p_file_Path;
                }

                var _file_name = p_file_Path.Substring(_last_index_char + 1);
                p_file_Path = p_file_Path.Substring(0, _last_index_char);

                return _file_name;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return null;
            }
        }

        public static string GetImageNames()
        {
            try
            {
                const string IFormatDate = "ddMMyyyyhhmmss";
                var pStr = DateTime.Now.ToString(IFormatDate);
                return pStr;
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return DateTime.Now.ToString("ddMMyyyyhhmmss");
            }
        }

        private static bool CheckIsUnicode(string p_unicode)
        {
            try
            {
                var pattern = new string[7];
                pattern[0] = "á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ";
                pattern[1] = "ó|ỏ|ò|ọ|õ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ";
                pattern[2] = "é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ";
                pattern[3] = "ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ";
                pattern[4] = "í|ì|ỉ|ị|ĩ";
                pattern[5] = "ý|ỳ|ỷ|ỵ|ỹ";
                pattern[6] = "đ";
                return pattern.Select(t => Regex.Matches(p_unicode, t)).Any(matchs => matchs.Count > 0);
            }
            catch
            {
                return false;
            }
        }
    }
}

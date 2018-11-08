namespace NaviCommon.Extension
{
    using System;
    using System.Globalization;

    public static class DateTimeExtension
    {
        public static DateTime FirstDateOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static DateTime LastDateOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
        }

        public static DateTime NextWorkingDay(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Friday: return dateTime.AddDays(3);
                case DayOfWeek.Saturday: return dateTime.AddDays(2);
                default: return dateTime.AddDays(1);
            }
        }

        public static string ToDateStringN0(this DateTime dateTime)
        {
            return dateTime == Null.NullDate ? string.Empty : dateTime.ToString(DateTimeCommonData.DATE_FORMAT_N0, CultureInfo.InvariantCulture);
        }

        public static string ToDateStringY2(this DateTime dateTime)
        {
            return dateTime == Null.NullDate ? string.Empty : dateTime.ToString(DateTimeCommonData.DATE_FORMAT_Y2);
        }

        public static string ToTimeStringN0(this DateTime dateTime)
        {
            return dateTime == Null.NullDate ? string.Empty : dateTime.ToString(DateTimeCommonData.TIME_FORMAT_N0);
        }

        public static string ToDateTimeStringN0(this DateTime dateTime) 
        {
            return dateTime == Null.NullDate ? string.Empty : dateTime.ToString(DateTimeCommonData.DATETIME_FORMAT_N0);
        }
    }
}

using System.Globalization;

namespace TadbirPardazProject.Common.Utilities
{
    public static class DateTimeExtension
    {
        private static readonly string[] Separators = new string[4] { "/", " ", "-", ":" };

        public static string ToPersianDate(int persianYear, int persianMonth, int persianDay)
        {
            return $"{persianYear:d2}/{persianMonth:d2}/{persianDay:d2}";
        }
        public static string ToPersianDate(this DateTime date)
        {
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
            {
                return "";
            }

            PersianCalendar persianCalendar = new PersianCalendar();
            return ToPersianDate(persianCalendar.GetYear(date), persianCalendar.GetMonth(date), persianCalendar.GetDayOfMonth(date));
        }

        public static DateTime? ToDateTimeNullable(this string persianDate, bool hasTime = true)
        {
            return string.IsNullOrWhiteSpace(persianDate) ? null : new DateTime?(persianDate.ToDateTime(hasTime));
        }

        public static DateTime ToDateTime(this string persianDate)
        {
            if (string.IsNullOrEmpty(persianDate))
            {
                return DateTime.MinValue;
            }

            PersianCalendar persianCalendar = new PersianCalendar();
            string[] array = persianDate.Trim().Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            int year = int.Parse(array[0]);
            int month = int.Parse(array[1]);
            int day = int.Parse(array[2]);
            return persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        public static DateTime ToDateTime(this string persianDate, bool hasTime)
        {
            if (string.IsNullOrEmpty(persianDate))
            {
                return DateTime.MinValue;
            }

            string[] array = persianDate.Trim().Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            int year = int.Parse(array[0]);
            int month = int.Parse(array[1]);
            int day = int.Parse(array[2]);
            int hour = 0;
            int minute = 0;
            int second = 0;
            if (hasTime && array.Length > 3)
            {
                hour = int.Parse(array[3].Replace("(", ""));
                minute = int.Parse(array[4]);
                if (array.Length == 6)
                {
                    second = int.Parse(array[5].Replace(")", ""));
                }
            }

            return new PersianCalendar().ToDateTime(year, month, day, hour, minute, second, 0);
        }

        public static DateTime ToDateTime(int persianYear, int persianMonth, int persianDay)
        {
            return new PersianCalendar().ToDateTime(persianYear, persianMonth, persianDay, 0, 0, 0, 0);
        }

    }
}

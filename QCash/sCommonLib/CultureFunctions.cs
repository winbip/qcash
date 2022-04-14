using System;
using System.Globalization;

namespace sCommonLib
{
    public class CultureFunctions
    {

        private static bool CultureExists()
        {
            string customCultureName = "bn-BD-skpaul";
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.UserCustomCulture))
            {
                if (ci.Name.Equals(customCultureName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }


        public static void ConfigureCulture()
        {
            if (!CultureExists())
            {
                RegisterBengaliBangladeshCulture();
            }
        }


        private static void RegisterBengaliBangladeshCulture()
        {
            CreateBengaliBangladeshCultureAndRegionInfoBuilder().Register();
        }

        private static CultureAndRegionInfoBuilder CreateBengaliBangladeshCultureAndRegionInfoBuilder()
        {
            CultureAndRegionInfoBuilder builder = new CultureAndRegionInfoBuilder("bn-BD-skpaul", CultureAndRegionModifiers.None);

            // there is no neutral Bengali culture to set the parent to
            builder.Parent = CultureInfo.InvariantCulture;

            builder.CultureEnglishName = "Bengali (Bangladesh)";
            builder.CultureNativeName = " (Bldesh)"; //TODO: Insert "Bangla" before (Bldesh)
            builder.ThreeLetterISOLanguageName = "ben";
            builder.ThreeLetterWindowsLanguageName = "ben";
            builder.TwoLetterISOLanguageName = "bn";

            builder.RegionEnglishName = "Bangladesh";
            builder.RegionNativeName = "Bldesh"; //TODO: Insert "Bangla" before (Bldesh)
            builder.ThreeLetterISORegionName = "BGD";
            builder.ThreeLetterWindowsRegionName = "BGD";
            builder.TwoLetterISORegionName = "BD";

            builder.IetfLanguageTag = "bn-BD";

            builder.IsMetric = true;
            builder.KeyboardLayoutId = 1081;
            builder.GeoId = 0x17; // Bangladesh

            builder.GregorianDateTimeFormat = CreateBangladeshDateTimeFormatInfo();

            builder.NumberFormat = CreateBangladeshNumberFormatInfo();
            builder.CurrencyEnglishName = "Bangladesh Taka";
            builder.CurrencyNativeName = "Bangladesh Taka";
            builder.ISOCurrencySymbol = "BDT";

            builder.TextInfo = CultureInfo.InvariantCulture.TextInfo;

            builder.CompareInfo = CultureInfo.InvariantCulture.CompareInfo;

            return builder;
        }

        private static NumberFormatInfo CreateBangladeshNumberFormatInfo()
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.CurrencyDecimalDigits = 2;
            numberFormatInfo.CurrencyDecimalSeparator = ".";
            numberFormatInfo.CurrencyGroupSeparator = ",";
            numberFormatInfo.CurrencyGroupSizes = new int[] { 3, 2 };
            numberFormatInfo.CurrencyNegativePattern = 12;
            numberFormatInfo.CurrencyPositivePattern = 2;
            numberFormatInfo.CurrencySymbol = "Tk"; //Default is BDT
            numberFormatInfo.DigitSubstitution = DigitShapes.None;
            numberFormatInfo.NaNSymbol = "NaN";
            numberFormatInfo.NativeDigits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            numberFormatInfo.NegativeInfinitySymbol = "-Infinity";
            numberFormatInfo.NegativeSign = "-";
            numberFormatInfo.NumberDecimalDigits = 2;
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";
            numberFormatInfo.NumberGroupSizes = new int[] { 3, 2 };
            numberFormatInfo.NumberNegativePattern = 1;
            numberFormatInfo.PercentDecimalDigits = 2;
            numberFormatInfo.PercentDecimalSeparator = ".";
            numberFormatInfo.PercentGroupSeparator = ",";
            numberFormatInfo.PercentGroupSizes = new int[] { 3, 2 };
            numberFormatInfo.PercentNegativePattern = 0;
            numberFormatInfo.PercentPositivePattern = 0;
            numberFormatInfo.PercentSymbol = "%";
            numberFormatInfo.PerMilleSymbol = "‰";
            numberFormatInfo.PositiveInfinitySymbol = "Infinity";
            numberFormatInfo.PositiveSign = "+";
            return numberFormatInfo;
        }

        private static DateTimeFormatInfo CreateBangladeshDateTimeFormatInfo()
        {
            Calendar calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

            DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();

            dateTimeFormatInfo.Calendar = calendar;

            dateTimeFormatInfo.AbbreviatedDayNames = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            dateTimeFormatInfo.DayNames = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" }; //TODO: Day required
            dateTimeFormatInfo.ShortestDayNames = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            dateTimeFormatInfo.AbbreviatedMonthNames = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "" };
            dateTimeFormatInfo.MonthNames = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "" };

            dateTimeFormatInfo.AbbreviatedMonthGenitiveNames = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "" };
            dateTimeFormatInfo.MonthGenitiveNames = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "" };

            dateTimeFormatInfo.AMDesignator = "AM";
            dateTimeFormatInfo.CalendarWeekRule = CalendarWeekRule.FirstDay;
            dateTimeFormatInfo.DateSeparator = "/"; //Default is "-"
            dateTimeFormatInfo.FirstDayOfWeek = DayOfWeek.Sunday;
            dateTimeFormatInfo.FullDateTimePattern = "dd MMMM yyyy HH:mm:ss";
            dateTimeFormatInfo.LongDatePattern = "dd MMMM yyyy";
            dateTimeFormatInfo.LongTimePattern = "HH:mm:ss";
            dateTimeFormatInfo.MonthDayPattern = "dd MMMM";
            dateTimeFormatInfo.PMDesignator = "PM";
            dateTimeFormatInfo.ShortDatePattern = "dd/MM/yyyy";
            dateTimeFormatInfo.ShortTimePattern = "HH:mm";
            dateTimeFormatInfo.TimeSeparator = ":";
            dateTimeFormatInfo.YearMonthPattern = "MMMM, yyyy";

            return dateTimeFormatInfo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Threading;

namespace Celibacy_days
{
    class Hebrew_calendar
    {
        public Hebrew_calendar()
        {
            hc = new HebrewCalendar();
            culture = CultureInfo.CreateSpecificCulture("he-IL");
            culture.DateTimeFormat.Calendar = hc;
            Thread.CurrentThread.CurrentCulture = culture;
        }
        HebrewCalendar hc;
        CultureInfo culture;

        public int getCurrentYear()
        {
            DateTime startOfYear = DateTime.Now;
            return hc.GetYear(startOfYear);
        }
        public int getCurrentMonth()
        {
            DateTime startOfYear = DateTime.Now;
            return hc.GetMonth(startOfYear);
        }
        public int getCurrentDay()
        {
            DateTime startOfYear = DateTime.Now;
            return hc.GetDayOfMonth(startOfYear);
        }

        public int DaysInMonth(int Year, int Month)
        {
            return hc.GetDaysInMonth(Year, Month);
        }
        public int firstDayInMonth(int Year, int Month)
        {
            DateTime startOfMonth = hc.ToDateTime(Year, Month, 1, 0, 0, 0, 0);
            //DayOfWeek
            return Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));
        }
        public bool previousMonthLeap(int Year, int Month)
        {
            Month--;
            if(Month == 0)
            {
                Month = 12;
                Year--;
                if (hc.IsLeapYear(Year))
                    Month = 13;
            }            
            return (hc.GetDaysInMonth(Year, Month) == 30) ? true :false;
        }

        public bool LeapYear(int Year)
        {
            if (Year > 343 && Year < 999)
                Year += 5000;
            return hc.IsLeapYear(Year);
        }
        public bool LeapMonth(int Year, int Month)
        {
            if (Year > 343 && Year < 999)
                Year += 5000;
            return hc.GetDaysInMonth(Year, Month) == 30 ? true: false;
        }
        public string FormatHebrew(int num)
        {
            if (num <= 0)
                throw new ArgumentOutOfRangeException();
            StringBuilder ret = new StringBuilder(new string('ת', num / 400));
            num %= 400;
            if (num >= 100)
            {
                ret.Append("קרש"[num / 100 - 1]);
                num %= 100;
            }
            switch (num)
            {
                // Avoid letter combinations from the Tetragrammaton
                case 16:
                    ret.Append("טז");
                    break;
                case 15:
                    ret.Append("טו");
                    break;
                default:
                    if (num >= 10)
                    {
                        ret.Append("יכלמנסעפצ"[num / 10 - 1]);
                        num %= 10;
                    }
                    if (num > 0)
                        ret.Append("אבגדהוזחט"[num - 1]);
                    break;
            }
            return ret.ToString();
        }
        public string getCurrentYearString(int Year = 0)
        {
            string str;
            if (Year ==0)
                 str = FormatHebrew(getCurrentYear()%1000);
            else
                str = FormatHebrew(Year % 1000);
            str += str[str.Length -1];//'\"';
            StringBuilder sb = new StringBuilder(str);
            sb[sb.Length - 2] = '\"';
            str = sb.ToString();

            return str;
        }
        public string getCurrentMonthString(int Year = 0,int Month = 0)
        {
            if (Year == 0)
                Year = getCurrentYear();
            string str;
            if (Month != 0)
                str = hc.ToDateTime(Year, Month, 1, 0, 0, 0, 0).ToString("MMMM");
            else
                str = hc.ToDateTime(Year, getCurrentMonth(), 1, 0, 0, 0, 0).ToString();
            if(str == "אדר" && LeapYear(Year))
            {
                str += ' ';
                str += 'א';
            }
            return str;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celibacy_days
{
    
    class Converter
    {
        private static readonly Converter instance = new Converter();

        private Converter()
        {
        }

        public static Converter Instance
        {
            get
            {
                return instance;
            }
        }
        public string convrtDay(string day)
        {
            switch (day)
            {
                case "1":
                    return "ראשון";
                case "2":
                    return "שני";
                case "3":
                    return "שלישי";
                case "4":
                    return "רביעי";
                case "5":
                    return "חמישי";
                case "6":
                    return "שישי";
                case "7":
                    return "שבת";
                default:
                    return "-1";
            }
        }

        private string[] letters = { "אבגדהוזחט", "יכלמנסעפצ" , "קרשת" };
        private string[] FinalLetters = { "יךלםןסעףץ" };
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

        public int FormatHebrew(string num)
        {
            if (num.Length == 0)
                throw new ArgumentOutOfRangeException();
            int ret = 0;
            int length = num.Length;
            bool finishFor_i;
            for (int i = 0; i < length; i++)
            {
                finishFor_i = false;
                int length2 = letters.Length;
                for (int j = 0; j < length2; j++)
                {
                    if (finishFor_i)
                        break;
                    int length3 = letters[j].Length;
                    for (int k = 0; k < length3; k++)
                    {
                        if (num[i] == letters[j][k])
                        {
                            ret += IntPow(10, (uint)j) * (k + 1);
                            finishFor_i = true;
                            break;
                        }
                    }
                }
                if (finishFor_i)
                    continue;
                int length4 = FinalLetters.Length;
                for (int k = 0; k < length4; k++)
                {
                    if (num[i] == FinalLetters[0][k])
                    {
                        ret += 10 * (k + 1);
                        finishFor_i = true;
                        break;
                    }
                }
            }
            return ret;
        }
        private int IntPow(int x, uint pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if (pow == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }

        public int dateToInt(int year,int month,int day)
        {
            return ((year % 1000) * 10000) + (month * 100) + day;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celibacy_days
{
    interface ISetting
    {
        int defaultValue();
        void setValue(int newValue, bool Change = false);
        int getValue();
        string getTitel();
    }
    class Setting_dayOfMonth_missingAfterFull : ISetting
    {
        public Setting_dayOfMonth_missingAfterFull(int line_)
        {
            line = line_;
        }
        public int defaultValue()
        {
            return 1;
        }
        public string getTitel()
        {
            return "\"יום החודש\" כשראוה ב ל' בחודש וחדש האחר כך הוא חודש חסר אם לשמור את יום א ' בחודש";
        }
        public void setValue(int newValue, bool Change = false)
        {
            Value = newValue;
            if(Change)
            {
                DatabaseSettings databaseSettings = DatabaseSettings.Instance;
                databaseSettings.lineChanger(newValue + "", line);
            }
        }
        public int getValue()
        {
            return Value;
        }
        int Value = 0;
        int line;
    }


    class Day31 : ISetting
    {
        public Day31(int line_)
        {
            line = line_;
        }
        public int defaultValue()
        {
            return 1;
        }
        public string getTitel()
        {
            return "יום השלושים ואחד";
        }
        public void setValue(int newValue, bool Change = false)
        {
            Value = newValue;
            if (Change)
            {
                DatabaseSettings databaseSettings = DatabaseSettings.Instance;
                databaseSettings.lineChanger(newValue + "", line);
            }
        }
        public int getValue()
        {
            return Value;
        }
        int Value = 0;
        int line;
    }

}

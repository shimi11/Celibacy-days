using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;



namespace Celibacy_days
{
    public partial class MainPanel : Form
    {
        Hebrew_calendar hebrew_calendar;
        int coutntMonth;
        int coutntYear;
        List<Forms.DayBox> allDAY;

        private MainPanel()
        {
            InitializeComponent();
            hebrew_calendar = new Hebrew_calendar();
            coutntMonth = hebrew_calendar.getCurrentMonth();
            coutntYear = hebrew_calendar.getCurrentYear();
            allDAY = new List<Forms.DayBox>();
            displaDays();
        }
        private static readonly MainPanel instance = new MainPanel();
        public static MainPanel Instance
        {
            get
            {
                return instance;
            }
        }

        public void displaDays()
        {


            int days_per_month = hebrew_calendar.DaysInMonth(coutntYear, coutntMonth);
            int day_of_week = hebrew_calendar.firstDayInMonth(coutntYear, coutntMonth);

            /*for (int i = 1;i<6;i++ )
            {
                tableLayoutPanel1.Controls.Add(new ComboBox { Dock = DockStyle.Fill }, 0, i);
            }*/
            MonthName.Text = hebrew_calendar.getCurrentMonthString(coutntYear, coutntMonth);
            YearName.Text = hebrew_calendar.getCurrentYearString(coutntYear);

            allDAY.Clear();

            //first lets create a blank usercontrol
            int x = 29 - day_of_week + 1;
            if (hebrew_calendar.previousMonthLeap(coutntYear, coutntMonth))
            {
                x++;
            }
            for (int i = 1; i <= day_of_week; i++)
            {
                Forms.DayBox ucblank = new Forms.DayBox(hebrew_calendar.FormatHebrew(x++));
                allDAY.Add(ucblank);
            }
            bool isLeapMonth = (days_per_month == 30) ? true : false;
            bool isLeapYear = hebrew_calendar.LeapYear(coutntYear);
            for (int i = 1; i <= days_per_month; i++)
            {
                Forms.DayBox ucblank = new Forms.DayBox((allDAY.Count) % 7 + 1 + "", hebrew_calendar.FormatHebrew(i)
                    , MonthName.Text, coutntMonth, YearName.Text, isLeapMonth, isLeapYear,
                   Converter.Instance.dateToInt(coutntYear, coutntMonth,i));
                //ucblank.dayInMonth(hebrew_calendar.FormatHebrew(i));
                allDAY.Add(ucblank);
            }
            x = 1;
            while (allDAY.Count < (7 * 6))
            {
                if (allDAY.Count == (7 * 5))
                {
                    break;
                }
                Forms.DayBox ucblank = new Forms.DayBox(hebrew_calendar.FormatHebrew(x++));
                allDAY.Add(ucblank);
            }

            tableLayoutPanel1.Controls.Clear();
            //Thread.Sleep(2000);
            tableLayoutPanel1.Visible = false;
            //int width = tableLayoutPanel1.GetColumnWidths()[1];
            //int height = tableLayoutPanel1.GetRowHeights()[1];

            for (int i = 0; i < 6; i++)
            {
                if (i == 5 && allDAY.Count == (7 * 5))
                {
                    break;
                }
                for (int j = 6; j >= 0; j--)
                {
                    tableLayoutPanel1.Controls.Add(allDAY[(i * 7) + j],6-j,i+1);
                    //Thread.Sleep(500);
                }
            }
            tableLayoutPanel1.Visible = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            coutntMonth++;
            if ((coutntMonth == 13 && !hebrew_calendar.LeapYear(coutntYear)) ||
                (coutntMonth == 14 && hebrew_calendar.LeapYear(coutntYear)))
            {
                coutntYear++;
                coutntMonth = 1;
            }
            displaDays();

        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            coutntMonth--;
            if (coutntMonth == 0)
            {
                coutntYear--;
                coutntMonth = 12;
                if (hebrew_calendar.LeapYear(coutntYear))
                {
                    coutntMonth++;
                }
            }
            displaDays();

        }
        private void buttonGoToday_Click(object sender, EventArgs e)
        {
            coutntMonth = hebrew_calendar.getCurrentMonth();
            coutntYear = hebrew_calendar.getCurrentYear();
            displaDays();

        }
    }
}

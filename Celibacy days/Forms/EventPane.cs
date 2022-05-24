using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Celibacy_days.Forms
{
    public partial class eventForm : Form
    {
        public eventForm(string dayInWeek_, string dayInMonth__, string Month_, int MonthNum_, string year_,
            bool isLeapMonth_, bool isLeapYear_)
        {
            dayInWeek = dayInWeek_;
            dayInMonth_ = dayInMonth__;
            Month = Month_;
            MonthNum = MonthNum_;
            year = year_;
            isLeapMonth = isLeapMonth_;
            isLeapYear = isLeapYear_;
            isLeapYear = isLeapYear_;

            Converter converter = Converter.Instance;
            InitializeComponent();
            textBoxData.Text = "יום " +
                  converter.convrtDay(dayInWeek) + " " + dayInMonth_ + "' " + Month
                  + " " + year;
            dateEvent = converter.FormatHebrew(year) * 10000;
            dateEvent += MonthNum * 100;
            dateEvent += converter.FormatHebrew(dayInMonth_);

            int myEnumMemberCount = Enum.GetNames(typeof(VisionType)).Length;
            try
            {
                for (int i = 0; i < myEnumMemberCount - 1; i++)
                {
                    //string str = Enum.GetName(typeof(VisionType), i);
                    list_events.Items.Add(Environment.Instance.hashmapEvent[(VisionType)i]);
                }
            }
            catch
            {

            }


        }
        private string dayInWeek;
        private string dayInMonth_;
        private string Month;
        private int MonthNum;
        private string year;
        private bool isLeapMonth;
        private bool isLeapYear;
        private int dateEvent;
        private void save_event_Click(object sender, EventArgs e)
        {
            Environment.Instance.addEvent(dateEvent, (VisionType)list_events.SelectedIndex - 1);
            //this.ShowDialog();
            this.Close();

        }


        private void buttonSelect_Click(object sender, EventArgs e)
        {
            list_events.Visible = true;
        }

        private void list_events_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSelect.Text = (string)list_events.Items[list_events.SelectedIndex];
            if (list_events.SelectedIndex > 0)
            {
                save_event.Visible = true;
            }
            else
                save_event.Visible = false;

            list_events.Visible = false;

        }
    }
}

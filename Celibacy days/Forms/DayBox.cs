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
    public partial class DayBox : UserControl
    {
        public string dayInWeek { get; set; }
        public string dayInMonth { get; set; }
        public string Month { get; set; }
        public int MonthNum { get; set; }
        public string year { get; set; }
        public bool isLeapMonth { get; set; }
        public bool isLeapYear { get; set; }
        //public int dateDay { get; set; }

        private bool belongsToMonth = false;

        public DayBox()
        {
            InitializeComponent();
        }
        public DayBox(string dayInWeek_, string dayInMonth_, string Month_, int MonthNum_, string year_,
    bool isLeapMonth_, bool isLeapYear_/*, int dateDay_*/)
        {
            dayInWeek = dayInWeek_;
            dayInMonth = dayInMonth_;
            Month = Month_;
            MonthNum = MonthNum_;
            year = year_;
            isLeapMonth = isLeapMonth_;
            isLeapYear = isLeapYear_;
            //dateDay = dateDay_;
            belongsToMonth = true;

            InitializeComponent();
            label_dayInMonth.Text = dayInMonth_;
            //colorUpdate();
        }
        public DayBox(string dayInMonth_)
        {
            dayInMonth = dayInMonth_;
            InitializeComponent();
            label_dayInMonth.Text = dayInMonth_;
        }

        private void DayBox_Load(object sender, EventArgs e)
        {

        }

        private void DayBox_Click(object sender, EventArgs e)
        {

            
            
        }
    }
}

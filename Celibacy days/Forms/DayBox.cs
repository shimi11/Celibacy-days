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
        public int dateDay { get; set; }

        private bool belongsToMonth = false;

        public DayBox()
        {
            InitializeComponent();
        }
        public DayBox(string dayInWeek_, string dayInMonth_, string Month_, int MonthNum_, string year_,
    bool isLeapMonth_, bool isLeapYear_, int dateDay_)
        {
            dayInWeek = dayInWeek_;
            dayInMonth = dayInMonth_;
            Month = Month_;
            MonthNum = MonthNum_;
            year = year_;
            isLeapMonth = isLeapMonth_;
            isLeapYear = isLeapYear_;
            dateDay = dateDay_;
            belongsToMonth = true;

            InitializeComponent();
            label_dayInMonth.Text = dayInMonth_;
            UpdateBoard();
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
            if (belongsToMonth)
            {   
                eventForm event_form = new eventForm(dayInWeek, dayInMonth, Month, MonthNum, year,
                isLeapMonth, isLeapYear);
                event_form.ShowDialog();
                UpdateBoard();
            }

        }

        public void UpdateBoard()
        {
            this.BackColor = Color.FromArgb(100, 100, 255);
            List<Event> list= Environment.Instance.getEvent(dateDay);
            if(list != null)
            { 
                foreach (Event e in list)
                {
                    switch (e.getType())
                    {
                        case (int)VisionType.error:
                            {
                                BackColor = Color.Black;
                                break;
                            }
                        case (int)VisionType.cycleNight:
                            {
                                this.labelCycleNight.BackColor = Color.Red;
                                this.labelCycleNight.Visible = true;
                                break;
                            }
                        case (int)VisionType.cycleDay:
                            {
                                this.labelCycleDay.BackColor = Color.Red;
                                this.labelCycleDay.Visible = true;
                                break;
                            }
                        default:
                            {
                                BackColor = Color.Black;
                                break;
                            }

                    }
                }
            }
        }

    }
}

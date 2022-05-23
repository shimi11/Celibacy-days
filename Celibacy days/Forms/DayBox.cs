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
            if (belongsToMonth)
            {

                if (Database.Instance.ThereIsEvent(dateDay) 
                    != EventType.erorr)
                {
                }
                else
                {
                    eventForm event_form = new eventForm(dayInWeek, dayInMonth, Month, MonthNum, year,
                    isLeapMonth, isLeapYear);
                    event_form.ShowDialog();
                }
                colorUpdate();
            }

        }

        public void colorUpdate()
        {
            /*BackColor = Color.Blue;
            panel3.BackColor = Color.FromArgb(200, 200, 255);
            switch (database.ThereIsEvent(dateDay))
            {
                case EventType.erorr:
                    {
                        *//*if (dayInWeek == "7")
                            BackColor = Color.Blue;
                        else
                            BackColor = Color.FromArgb(200, 200, 255);*//*
                        break;
                    }
                case EventType.cycleNight:
                    {
                        panel5.BackColor = Color.Red;
                        panel5.Visible = true;
                        break;
                    }
                case EventType.cycleDay:
                    {
                        panel4.BackColor = Color.Red;
                        panel4.Visible = true;
                        break;
                    }
                *//*case EventType.cycle:
                    {
                        panel5.BackColor = Color.Red;
                        panel5.Visible = true;
                        panel4.BackColor = Color.Red;
                        panel4.Visible = true;
                        break;
                    }*//*
                default:
                    {
                        BackColor = Color.Black;
                        break;
                    }

            }

            if (calculating_info.isToday(dateDay))
            {
                panel1.BackColor = Color.Black;
                panel2.BackColor = Color.Black;
                flowLayoutPanel1.BackColor = Color.Black;
                flowLayoutPanel2.BackColor = Color.Black;
            }
            else
            {
                panel1.BackColor = panel3.BackColor;
                panel2.BackColor = panel3.BackColor;
                flowLayoutPanel1.BackColor = panel3.BackColor;
                flowLayoutPanel2.BackColor = panel3.BackColor;

            }
            AllCelibacyType.Clear();
            List<InfoDay> AllCelibacy = new List<InfoDay>();
            AllCelibacy = calculating_info.getAllCelibacyDay(true);
            int len = AllCelibacy.Count;
            for (int i = 0; i < len; i++)
            {
                if (dateDay == AllCelibacy[i].date)
                {
                    switch (AllCelibacy[i].celibacyTypes)
                    {
                        case CelibacyType.erorr:
                            {
                                break;
                            }
                        case CelibacyType.celibacyDayTheMonth_D:
                        case CelibacyType.Day30_D:
                        case CelibacyType.Day31_D:
                            {
                                button2.Visible = true;
                                break;
                            }
                        case CelibacyType.celibacyDayTheMonth_N:
                        case CelibacyType.Day30_N:
                        case CelibacyType.Day31_N:
                            {
                                button1.Visible = true;
                                break;
                            }

                    }
                }
            }*/

            /*AllCelibacyType = calculating_info.ThereIsCelibacy(dateDay);
            int len = AllCelibacyType.Count;
            for (int i = 0; i< len; i++)
            {
                switch(AllCelibacyType[i])
                {
                    case CelibacyType.erorr:
                        {
                            break;
                        }
                    case CelibacyType.celibacyDayTheMonth_D:
                    case CelibacyType.Day30_D:
                    case CelibacyType.Day31_D:
                        {
                            button2.Visible = true;
                            break;
                        }
                    case CelibacyType.celibacyDayTheMonth_N:
                    case CelibacyType.Day30_N:
                    case CelibacyType.Day31_N:
                        {
                            button1.Visible = true;
                            break;
                        }

                }
            }*/
        }

    }
}

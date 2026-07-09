using System;
using System.Globalization;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private void btGet_Click(object sender, EventArgs e) {
            DateTime date = dtpDate.Value;

            tbOut.Text = date.AddDays((double)nudDay.Value)
                             .ToString("yyyy/MM/dd");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {

        }


        private void button1_Click(object sender, EventArgs e) {
            DateTime birth = dtpBirth.Value.Date;
            DateTime today = DateTime.Today;

            //var age = today.Year - birth.Year;
            //if (today < birth.AddYears(age)) {
            //    age--;
            //}



            var days = (today - birth).Days;

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(birth.DayOfWeek);

            

            tbOut.Text = $"‚ ‚È‚½‚Í{GetAge(birth, today)}Î‚Å‚·";
            tbDays.Text = days.ToString();
            tbOut3.Text = $"¶‚Ü‚ê‚½{birth.Month}ŒŽ{birth.Day}“ú‚Í‘æ{NthWeek(birth)}T‚Ì{dayOfWeek}‚Å‚·";

            DateTime nextbirthday = new DateTime(today.Year, birth.Month, birth.Day);

            if(nextbirthday < today) {
                nextbirthday.AddYears(1);
            }

            var span = nextbirthday - today;

            if(span.Days == 0) {
                tbOut4.Text = "’a¶“ú‚Í¡“ú‚Å‚·";
            } else {
                tbOut4.Text = $"’a¶“ú‚Ü‚Å‚ ‚Æ{span.Days}“ú‚Å‚·";
            }

            
                    }

        private void dtpBirth_ValueChanged(object sender, EventArgs e) {

        }

        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        private void tbOut3_TextChanged(object sender, EventArgs e) {

        }

        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }

    }
}
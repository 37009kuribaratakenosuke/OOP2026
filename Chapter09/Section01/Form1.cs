using System;

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
            DateTime birth = dtpBirth.Value;
            DateTime today = DateTime.Today;

            var age = today.Year - birth.Year;
            if (today < birth.AddYears(age)) {
                age--;
            }

            var days = (today - birth).Days;

            tbOut.Text = $"‚ ‚È‚½‚Í{age.ToString()}Î‚Å‚·";
            tbDays.Text = days.ToString();
        }
    }
}
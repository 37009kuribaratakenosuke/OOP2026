using Microsoft.VisualBasic;
using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton1_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            var str = today.ToString("yyyy/MM/dd hh:mm");
            tbOut1.Text = str;
        }

        private void btButton2_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            var str = today.ToString("yyyy”NMMŒŽdd“ú hhŽžmm•ªss•b");
            tbOut2.Text = str;
        }

        private void btButton3_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = today.ToString("gg y”NMŒŽd“ú(dddd)", culture);
            tbOut3.Text = str;
        }
    }
}

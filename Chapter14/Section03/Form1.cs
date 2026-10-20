
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e) {
            var elapsed = await DoLongTimeWork(5000);
            MessageBox.Show(elapsed + "ƒ~ƒŠ•b");
        }

        private async Task<long> DoLongTimeWork(int milliseconds) {
            var sw = Stopwatch.StartNew();

            await Task.Run(() => {
                Thread.Sleep(milliseconds);
            });

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}

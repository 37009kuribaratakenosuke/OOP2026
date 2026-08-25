namespace CarReportSystem {
    public sealed class Settings {

        //唯一のSettingオブジェクト
        private static Settings _instance = new Settings();

        //メイン画面に設定した色情報
        public int MainFormBackColor { get; set; }
        = SystemColors.Control.ToArgb();

        public static Settings Instance {
            get { return _instance; }
        }


        private Settings() { }
    }
}

namespace Section01 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            dtpDate = new DateTimePicker();
            btGet = new Button();
            nudDay = new NumericUpDown();
            tbOut = new TextBox();
            dtpBirth = new DateTimePicker();
            button1 = new Button();
            tbDays = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbOut3 = new TextBox();
            label3 = new Label();
            tbOut4 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(26, 32);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 39);
            dtpDate.TabIndex = 0;
            // 
            // btGet
            // 
            btGet.Location = new Point(290, 40);
            btGet.Name = "btGet";
            btGet.Size = new Size(75, 23);
            btGet.TabIndex = 1;
            btGet.Text = "取得";
            btGet.UseVisualStyleBackColor = true;
            btGet.Click += btGet_Click;
            // 
            // nudDay
            // 
            nudDay.Location = new Point(75, 171);
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 23);
            nudDay.TabIndex = 3;
            nudDay.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // tbOut
            // 
            tbOut.Location = new Point(55, 386);
            tbOut.Name = "tbOut";
            tbOut.Size = new Size(200, 23);
            tbOut.TabIndex = 2;
            // 
            // dtpBirth
            // 
            dtpBirth.Location = new Point(35, 332);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(200, 23);
            dtpBirth.TabIndex = 4;
            dtpBirth.ValueChanged += dtpBirth_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(321, 332);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "計算";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tbDays
            // 
            tbDays.Location = new Point(55, 434);
            tbDays.Name = "tbDays";
            tbDays.Size = new Size(200, 23);
            tbDays.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 389);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 6;
            label1.Text = "年齢";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 485);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 7;
            label2.Text = "メモ";
            // 
            // tbOut3
            // 
            tbOut3.Location = new Point(55, 477);
            tbOut3.Multiline = true;
            tbOut3.Name = "tbOut3";
            tbOut3.Size = new Size(200, 23);
            tbOut3.TabIndex = 2;
            tbOut3.TextChanged += tbOut3_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 442);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 7;
            label3.Text = "経過日数";
            // 
            // tbOut4
            // 
            tbOut4.Location = new Point(55, 516);
            tbOut4.Multiline = true;
            tbOut4.Name = "tbOut4";
            tbOut4.Size = new Size(200, 23);
            tbOut4.TabIndex = 2;
            tbOut4.TextChanged += tbOut3_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 583);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dtpBirth);
            Controls.Add(nudDay);
            Controls.Add(tbOut4);
            Controls.Add(tbOut3);
            Controls.Add(tbDays);
            Controls.Add(tbOut);
            Controls.Add(btGet);
            Controls.Add(dtpDate);
            Name = "Form1";
            Text = "S";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDate;
        private Button btGet;
        private NumericUpDown nudDay;
        private TextBox tbOut;
        private DateTimePicker dtpBirth;
        private Button button1;
        private TextBox tbDays;
        private Label label1;
        private Label label2;
        private TextBox tbOut3;
        private Label label3;
        private TextBox tbOut4;
    }
}

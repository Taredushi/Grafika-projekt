namespace biometria_1
{
    partial class PoziomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.MinimumTextBox = new System.Windows.Forms.TextBox();
            this.MaximumTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SyncCheckBox = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.strzalkaMin = new System.Windows.Forms.PictureBox();
            this.strzalkaMax = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strzalkaMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strzalkaMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(55, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Poziom:";
            // 
            // MinimumTextBox
            // 
            this.MinimumTextBox.Location = new System.Drawing.Point(117, 56);
            this.MinimumTextBox.MaxLength = 3;
            this.MinimumTextBox.Name = "MinimumTextBox";
            this.MinimumTextBox.Size = new System.Drawing.Size(52, 20);
            this.MinimumTextBox.TabIndex = 1;
            this.MinimumTextBox.Text = "0";
            this.MinimumTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MinimumTextBox.TextChanged += new System.EventHandler(this.MinimumTextBox_TextChanged);
            // 
            // MaximumTextBox
            // 
            this.MaximumTextBox.Location = new System.Drawing.Point(183, 56);
            this.MaximumTextBox.MaxLength = 3;
            this.MaximumTextBox.Name = "MaximumTextBox";
            this.MaximumTextBox.Size = new System.Drawing.Size(52, 20);
            this.MaximumTextBox.TabIndex = 3;
            this.MaximumTextBox.Text = "255";
            this.MaximumTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaximumTextBox.TextChanged += new System.EventHandler(this.MaximumTextBox_TextChanged);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(328, 234);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(15, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kanał:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Czerwony",
            "Zielony",
            "Niebieski"});
            this.comboBox1.Location = new System.Drawing.Point(60, 10);
            this.comboBox1.MaxDropDownItems = 3;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SyncCheckBox
            // 
            this.SyncCheckBox.AutoSize = true;
            this.SyncCheckBox.Location = new System.Drawing.Point(184, 5);
            this.SyncCheckBox.Name = "SyncCheckBox";
            this.SyncCheckBox.Size = new System.Drawing.Size(86, 30);
            this.SyncCheckBox.TabIndex = 13;
            this.SyncCheckBox.Text = "Synchronizuj\r\nkanały";
            this.SyncCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SyncCheckBox.UseVisualStyleBackColor = true;
            this.SyncCheckBox.CheckedChanged += new System.EventHandler(this.SyncCheckBox_CheckedChanged);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisX.Interval = 255D;
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.LineWidth = 0;
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(16, 90);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Green,
        System.Drawing.Color.Blue};
            series2.ChartArea = "ChartArea1";
            series2.IsXValueIndexed = true;
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(271, 142);
            this.chart1.TabIndex = 14;
            this.chart1.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.strzalkaMin);
            this.panel1.Controls.Add(this.strzalkaMax);
            this.panel1.Location = new System.Drawing.Point(10, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 35);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(14, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 15);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // strzalkaMin
            // 
            this.strzalkaMin.Image = global::biometria_1.Properties.Resources.arrow;
            this.strzalkaMin.Location = new System.Drawing.Point(9, 20);
            this.strzalkaMin.Name = "strzalkaMin";
            this.strzalkaMin.Size = new System.Drawing.Size(10, 10);
            this.strzalkaMin.TabIndex = 9;
            this.strzalkaMin.TabStop = false;
            this.strzalkaMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.strzalkaMin_MouseDown);
            this.strzalkaMin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.strzalkaMin_MouseMove);
            this.strzalkaMin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.strzalkaMin_MouseUp);
            // 
            // strzalkaMax
            // 
            this.strzalkaMax.Image = global::biometria_1.Properties.Resources.arrow;
            this.strzalkaMax.Location = new System.Drawing.Point(265, 20);
            this.strzalkaMax.Name = "strzalkaMax";
            this.strzalkaMax.Size = new System.Drawing.Size(10, 10);
            this.strzalkaMax.TabIndex = 10;
            this.strzalkaMax.TabStop = false;
            this.strzalkaMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.strzalkaMax_MouseDown);
            this.strzalkaMax.MouseMove += new System.Windows.Forms.MouseEventHandler(this.strzalkaMax_MouseMove);
            this.strzalkaMax.MouseUp += new System.Windows.Forms.MouseEventHandler(this.strzalkaMax_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(322, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 200);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podgląd";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(25, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 150);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(441, 234);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 17;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(24, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 2);
            this.label2.TabIndex = 18;
            // 
            // PoziomForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(550, 282);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SyncCheckBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MaximumTextBox);
            this.Controls.Add(this.MinimumTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(566, 321);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(566, 321);
            this.Name = "PoziomForm";
            this.Text = "Poziom";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strzalkaMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strzalkaMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MinimumTextBox;
        private System.Windows.Forms.TextBox MaximumTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox strzalkaMin;
        private System.Windows.Forms.PictureBox strzalkaMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox SyncCheckBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label2;
    }
}
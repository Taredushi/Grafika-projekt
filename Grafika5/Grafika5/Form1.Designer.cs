using System.Drawing;
using biometria_1.Properties;

namespace biometria_1
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.histogramPanel = new System.Windows.Forms.Panel();
            this.HistogramComboBox = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.OdchWartoscL = new System.Windows.Forms.Label();
            this.OdchL = new System.Windows.Forms.Label();
            this.SredniaWartosc = new System.Windows.Forms.Label();
            this.SredniaL = new System.Windows.Forms.Label();
            this.LiczbaWartoscL = new System.Windows.Forms.Label();
            this.LiczbaL = new System.Windows.Forms.Label();
            this.PoziomValueL = new System.Windows.Forms.Label();
            this.PoziomL = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RozciagniecieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyrownanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorRGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozjasnijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.przyciemnijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreskaToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.czarnoBiałeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryzacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recznyProgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automatycznyProgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lokalnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.maskaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozmycieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prewittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pionowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poziomyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pionowyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.poziomyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lapleaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pionowyLaplaceToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.poziomyLaplaceToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.skosnyLaplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wykrycieNarożnikówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wschodNaroznikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zachodNaroznikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polnocnyzachodNaroznikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poludniowyWschodNaroznikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kuwaharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maska3KuwaharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maska5KuwaharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maska3MedianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maska5MedianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pustyLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.procentowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.previousButton = new System.Windows.Forms.ToolStripButton();
            this.nextButton = new System.Windows.Forms.ToolStripButton();
            this.zoomInButton = new System.Windows.Forms.ToolStripButton();
            this.zoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.zoomResetButton = new System.Windows.Forms.ToolStripButton();
            this.centerButton = new System.Windows.Forms.ToolStripButton();
            this.resetButton = new System.Windows.Forms.ToolStripButton();
            this.kopiaButton = new System.Windows.Forms.ToolStripButton();
            this.rButton = new System.Windows.Forms.ToolStripButton();
            this.gButton = new System.Windows.Forms.ToolStripButton();
            this.bButton = new System.Windows.Forms.ToolStripButton();
            this.histogramButton = new System.Windows.Forms.ToolStripButton();
            this.grayScaleButton = new System.Windows.Forms.ToolStripButton();
            this.OryginalPictureBox = new System.Windows.Forms.PictureBox();
            this.KopiaPictureBox = new System.Windows.Forms.PictureBox();
            this.fuzzyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.histogramPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OryginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KopiaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Pliki|*.gif;*.jpg;*.jpeg;*.tif;*.tiff;*.png";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.OryginalPictureBox);
            this.splitContainer1.Panel1MinSize = 440;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.histogramPanel);
            this.splitContainer1.Panel2.Controls.Add(this.KopiaPictureBox);
            this.splitContainer1.Panel2MinSize = 440;
            this.splitContainer1.Size = new System.Drawing.Size(895, 415);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // histogramPanel
            // 
            this.histogramPanel.Controls.Add(this.HistogramComboBox);
            this.histogramPanel.Controls.Add(this.chart1);
            this.histogramPanel.Controls.Add(this.OdchWartoscL);
            this.histogramPanel.Controls.Add(this.OdchL);
            this.histogramPanel.Controls.Add(this.SredniaWartosc);
            this.histogramPanel.Controls.Add(this.SredniaL);
            this.histogramPanel.Controls.Add(this.LiczbaWartoscL);
            this.histogramPanel.Controls.Add(this.LiczbaL);
            this.histogramPanel.Controls.Add(this.PoziomValueL);
            this.histogramPanel.Controls.Add(this.PoziomL);
            this.histogramPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramPanel.Location = new System.Drawing.Point(0, 0);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(445, 411);
            this.histogramPanel.TabIndex = 3;
            this.histogramPanel.Visible = false;
            // 
            // HistogramComboBox
            // 
            this.HistogramComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HistogramComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HistogramComboBox.FormattingEnabled = true;
            this.HistogramComboBox.Items.AddRange(new object[] {
            "Czerwony",
            "Zielony",
            "Niebieski",
            "Uśredniony"});
            this.HistogramComboBox.Location = new System.Drawing.Point(291, 9);
            this.HistogramComboBox.Name = "HistogramComboBox";
            this.HistogramComboBox.Size = new System.Drawing.Size(151, 21);
            this.HistogramComboBox.TabIndex = 19;
            this.HistogramComboBox.SelectedIndexChanged += new System.EventHandler(this.HistogramComboBox_SelectedIndexChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.Interval = 255D;
            chartArea3.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chart1.Location = new System.Drawing.Point(16, 52);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Green,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Orange};
            series3.ChartArea = "ChartArea1";
            series3.IsXValueIndexed = true;
            series3.Name = "Histogram";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(419, 243);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // OdchWartoscL
            // 
            this.OdchWartoscL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OdchWartoscL.AutoSize = true;
            this.OdchWartoscL.Location = new System.Drawing.Point(337, 356);
            this.OdchWartoscL.Name = "OdchWartoscL";
            this.OdchWartoscL.Size = new System.Drawing.Size(0, 13);
            this.OdchWartoscL.TabIndex = 17;
            // 
            // OdchL
            // 
            this.OdchL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OdchL.AutoSize = true;
            this.OdchL.Location = new System.Drawing.Point(260, 356);
            this.OdchL.Name = "OdchL";
            this.OdchL.Size = new System.Drawing.Size(71, 13);
            this.OdchL.TabIndex = 16;
            this.OdchL.Text = "Odch. stand.:";
            // 
            // SredniaWartosc
            // 
            this.SredniaWartosc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SredniaWartosc.AutoSize = true;
            this.SredniaWartosc.Location = new System.Drawing.Point(312, 325);
            this.SredniaWartosc.Name = "SredniaWartosc";
            this.SredniaWartosc.Size = new System.Drawing.Size(0, 13);
            this.SredniaWartosc.TabIndex = 15;
            // 
            // SredniaL
            // 
            this.SredniaL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SredniaL.AutoSize = true;
            this.SredniaL.Location = new System.Drawing.Point(260, 325);
            this.SredniaL.Name = "SredniaL";
            this.SredniaL.Size = new System.Drawing.Size(46, 13);
            this.SredniaL.TabIndex = 14;
            this.SredniaL.Text = "Średnia:";
            // 
            // LiczbaWartoscL
            // 
            this.LiczbaWartoscL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LiczbaWartoscL.AutoSize = true;
            this.LiczbaWartoscL.Location = new System.Drawing.Point(138, 356);
            this.LiczbaWartoscL.Name = "LiczbaWartoscL";
            this.LiczbaWartoscL.Size = new System.Drawing.Size(0, 13);
            this.LiczbaWartoscL.TabIndex = 13;
            // 
            // LiczbaL
            // 
            this.LiczbaL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LiczbaL.AutoSize = true;
            this.LiczbaL.Location = new System.Drawing.Point(88, 356);
            this.LiczbaL.Name = "LiczbaL";
            this.LiczbaL.Size = new System.Drawing.Size(41, 13);
            this.LiczbaL.TabIndex = 12;
            this.LiczbaL.Text = "Liczba:";
            // 
            // PoziomValueL
            // 
            this.PoziomValueL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PoziomValueL.AutoSize = true;
            this.PoziomValueL.Location = new System.Drawing.Point(138, 325);
            this.PoziomValueL.Name = "PoziomValueL";
            this.PoziomValueL.Size = new System.Drawing.Size(0, 13);
            this.PoziomValueL.TabIndex = 11;
            // 
            // PoziomL
            // 
            this.PoziomL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PoziomL.AutoSize = true;
            this.PoziomL.Location = new System.Drawing.Point(88, 325);
            this.PoziomL.Name = "PoziomL";
            this.PoziomL.Size = new System.Drawing.Size(44, 13);
            this.PoziomL.TabIndex = 10;
            this.PoziomL.Text = "Poziom:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Gif(.gif)|*.gif|Jpg(.jpg)|*.jpg|Tif(.tif)|*.tiff";
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.filtryToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(895, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetujToolStripMenuItem,
            this.wczytajToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.zamknijToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // resetujToolStripMenuItem
            // 
            this.resetujToolStripMenuItem.Name = "resetujToolStripMenuItem";
            this.resetujToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.resetujToolStripMenuItem.Text = "Resetuj";
            this.resetujToolStripMenuItem.Visible = false;
            this.resetujToolStripMenuItem.Click += new System.EventHandler(this.resetujToolStripMenuItem_Click);
            // 
            // wczytajToolStripMenuItem
            // 
            this.wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            this.wczytajToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.wczytajToolStripMenuItem.Text = "Wczytaj";
            this.wczytajToolStripMenuItem.Click += new System.EventHandler(this.wczytajToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // filtryToolStripMenuItem
            // 
            this.filtryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem,
            this.kolorRGBToolStripMenuItem,
            this.binaryzacjaToolStripMenuItem,
            this.aToolStripMenuItem,
            this.maskaToolStripMenuItem,
            this.rozmycieToolStripMenuItem,
            this.prewittToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.lapleaceToolStripMenuItem,
            this.wykrycieNarożnikówToolStripMenuItem,
            this.kuwaharToolStripMenuItem,
            this.medianowyToolStripMenuItem,
            this.cannaToolStripMenuItem});
            this.filtryToolStripMenuItem.Name = "filtryToolStripMenuItem";
            this.filtryToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filtryToolStripMenuItem.Text = "Filtry";
            this.filtryToolStripMenuItem.Visible = false;
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RozciagniecieToolStripMenuItem,
            this.wyrownanieToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // RozciagniecieToolStripMenuItem
            // 
            this.RozciagniecieToolStripMenuItem.Name = "RozciagniecieToolStripMenuItem";
            this.RozciagniecieToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.RozciagniecieToolStripMenuItem.Text = "Rozciągnięcie";
            this.RozciagniecieToolStripMenuItem.Click += new System.EventHandler(this.RozciagniecieToolStripMenuItem_Click);
            // 
            // wyrownanieToolStripMenuItem
            // 
            this.wyrownanieToolStripMenuItem.Name = "wyrownanieToolStripMenuItem";
            this.wyrownanieToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.wyrownanieToolStripMenuItem.Text = "Wyrównanie";
            this.wyrownanieToolStripMenuItem.Click += new System.EventHandler(this.wyrownanieToolStripMenuItem_Click);
            // 
            // kolorRGBToolStripMenuItem
            // 
            this.kolorRGBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rozjasnijToolStripMenuItem,
            this.przyciemnijToolStripMenuItem,
            this.kreskaToolStripMenuItem,
            this.czarnoBiałeToolStripMenuItem1});
            this.kolorRGBToolStripMenuItem.Name = "kolorRGBToolStripMenuItem";
            this.kolorRGBToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.kolorRGBToolStripMenuItem.Text = "Kolor (RGB)";
            // 
            // rozjasnijToolStripMenuItem
            // 
            this.rozjasnijToolStripMenuItem.Name = "rozjasnijToolStripMenuItem";
            this.rozjasnijToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.rozjasnijToolStripMenuItem.Text = "Rozjaśnij (f. logarytmiczna)";
            this.rozjasnijToolStripMenuItem.Click += new System.EventHandler(this.rozjasnijToolStripMenuItem_Click);
            // 
            // przyciemnijToolStripMenuItem
            // 
            this.przyciemnijToolStripMenuItem.Name = "przyciemnijToolStripMenuItem";
            this.przyciemnijToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.przyciemnijToolStripMenuItem.Text = "Przyciemnij (f. kwadratowa)";
            this.przyciemnijToolStripMenuItem.Click += new System.EventHandler(this.przyciemnijToolStripMenuItem_Click);
            // 
            // kreskaToolStripMenuItem
            // 
            this.kreskaToolStripMenuItem.Name = "kreskaToolStripMenuItem";
            this.kreskaToolStripMenuItem.Size = new System.Drawing.Size(217, 6);
            // 
            // czarnoBiałeToolStripMenuItem1
            // 
            this.czarnoBiałeToolStripMenuItem1.Name = "czarnoBiałeToolStripMenuItem1";
            this.czarnoBiałeToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.czarnoBiałeToolStripMenuItem1.Text = "Obraz czarno-biały";
            this.czarnoBiałeToolStripMenuItem1.Click += new System.EventHandler(this.czarnobialeToolStripMenuItem_Click);
            // 
            // binaryzacjaToolStripMenuItem
            // 
            this.binaryzacjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recznyProgToolStripMenuItem,
            this.procentowaToolStripMenuItem,
            this.fuzzyToolStripMenuItem,
            this.automatycznyProgToolStripMenuItem,
            this.lokalnaToolStripMenuItem});
            this.binaryzacjaToolStripMenuItem.Name = "binaryzacjaToolStripMenuItem";
            this.binaryzacjaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.binaryzacjaToolStripMenuItem.Text = "Binaryzacja";
            // 
            // recznyProgToolStripMenuItem
            // 
            this.recznyProgToolStripMenuItem.Name = "recznyProgToolStripMenuItem";
            this.recznyProgToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.recznyProgToolStripMenuItem.Text = "Ręczny próg";
            this.recznyProgToolStripMenuItem.Click += new System.EventHandler(this.recznyProgToolStripMenuItem_Click);
            // 
            // automatycznyProgToolStripMenuItem
            // 
            this.automatycznyProgToolStripMenuItem.Name = "automatycznyProgToolStripMenuItem";
            this.automatycznyProgToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.automatycznyProgToolStripMenuItem.Text = "Automatyczny próg (Otsu)";
            this.automatycznyProgToolStripMenuItem.Click += new System.EventHandler(this.automatycznyProgToolStripMenuItem_Click);
            // 
            // lokalnaToolStripMenuItem
            // 
            this.lokalnaToolStripMenuItem.Name = "lokalnaToolStripMenuItem";
            this.lokalnaToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.lokalnaToolStripMenuItem.Text = "Lokalna (Niblack)";
            this.lokalnaToolStripMenuItem.Click += new System.EventHandler(this.lokalnaToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(183, 6);
            // 
            // maskaToolStripMenuItem
            // 
            this.maskaToolStripMenuItem.Name = "maskaToolStripMenuItem";
            this.maskaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.maskaToolStripMenuItem.Text = "Maska";
            this.maskaToolStripMenuItem.Click += new System.EventHandler(this.maskaToolStripMenuItem_Click);
            // 
            // rozmycieToolStripMenuItem
            // 
            this.rozmycieToolStripMenuItem.Name = "rozmycieToolStripMenuItem";
            this.rozmycieToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.rozmycieToolStripMenuItem.Text = "Rozmycie";
            this.rozmycieToolStripMenuItem.Click += new System.EventHandler(this.rozmycieToolStripMenuItem_Click);
            // 
            // prewittToolStripMenuItem
            // 
            this.prewittToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pionowyToolStripMenuItem,
            this.poziomyToolStripMenuItem});
            this.prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
            this.prewittToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.prewittToolStripMenuItem.Text = "Prewitt";
            this.prewittToolStripMenuItem.Visible = false;
            // 
            // pionowyToolStripMenuItem
            // 
            this.pionowyToolStripMenuItem.Name = "pionowyToolStripMenuItem";
            this.pionowyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pionowyToolStripMenuItem.Text = "Pionowy";
            this.pionowyToolStripMenuItem.Click += new System.EventHandler(this.pionowyPrewittToolStripMenuItem_Click);
            // 
            // poziomyToolStripMenuItem
            // 
            this.poziomyToolStripMenuItem.Name = "poziomyToolStripMenuItem";
            this.poziomyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.poziomyToolStripMenuItem.Text = "Poziomy";
            this.poziomyToolStripMenuItem.Click += new System.EventHandler(this.poziomyPrewittToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pionowyToolStripMenuItem1,
            this.poziomyToolStripMenuItem1});
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.sobelToolStripMenuItem.Text = "Sobel";
            // 
            // pionowyToolStripMenuItem1
            // 
            this.pionowyToolStripMenuItem1.Name = "pionowyToolStripMenuItem1";
            this.pionowyToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.pionowyToolStripMenuItem1.Text = "Pionowy";
            this.pionowyToolStripMenuItem1.Click += new System.EventHandler(this.pionowySobelToolStripMenuItem1_Click);
            // 
            // poziomyToolStripMenuItem1
            // 
            this.poziomyToolStripMenuItem1.Name = "poziomyToolStripMenuItem1";
            this.poziomyToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.poziomyToolStripMenuItem1.Text = "Poziomy";
            this.poziomyToolStripMenuItem1.Click += new System.EventHandler(this.poziomySobelToolStripMenuItem1_Click);
            // 
            // lapleaceToolStripMenuItem
            // 
            this.lapleaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pionowyLaplaceToolStripMenuItem2,
            this.poziomyLaplaceToolStripMenuItem2,
            this.skosnyLaplaceToolStripMenuItem});
            this.lapleaceToolStripMenuItem.Name = "lapleaceToolStripMenuItem";
            this.lapleaceToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.lapleaceToolStripMenuItem.Text = "Laplace";
            this.lapleaceToolStripMenuItem.Visible = false;
            // 
            // pionowyLaplaceToolStripMenuItem2
            // 
            this.pionowyLaplaceToolStripMenuItem2.Name = "pionowyLaplaceToolStripMenuItem2";
            this.pionowyLaplaceToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.pionowyLaplaceToolStripMenuItem2.Text = "Pionowy";
            this.pionowyLaplaceToolStripMenuItem2.Click += new System.EventHandler(this.pionowyLaplaceToolStripMenuItem2_Click);
            // 
            // poziomyLaplaceToolStripMenuItem2
            // 
            this.poziomyLaplaceToolStripMenuItem2.Name = "poziomyLaplaceToolStripMenuItem2";
            this.poziomyLaplaceToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.poziomyLaplaceToolStripMenuItem2.Text = "Poziomy";
            this.poziomyLaplaceToolStripMenuItem2.Click += new System.EventHandler(this.poziomyLaplaceToolStripMenuItem2_Click);
            // 
            // skosnyLaplaceToolStripMenuItem
            // 
            this.skosnyLaplaceToolStripMenuItem.Name = "skosnyLaplaceToolStripMenuItem";
            this.skosnyLaplaceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.skosnyLaplaceToolStripMenuItem.Text = "Skośny";
            this.skosnyLaplaceToolStripMenuItem.Click += new System.EventHandler(this.skosnyLaplaceToolStripMenuItem_Click);
            // 
            // wykrycieNarożnikówToolStripMenuItem
            // 
            this.wykrycieNarożnikówToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wschodNaroznikToolStripMenuItem,
            this.zachodNaroznikToolStripMenuItem,
            this.polnocnyzachodNaroznikToolStripMenuItem,
            this.poludniowyWschodNaroznikToolStripMenuItem});
            this.wykrycieNarożnikówToolStripMenuItem.Name = "wykrycieNarożnikówToolStripMenuItem";
            this.wykrycieNarożnikówToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.wykrycieNarożnikówToolStripMenuItem.Text = "Wykrycie narożników";
            this.wykrycieNarożnikówToolStripMenuItem.Visible = false;
            // 
            // wschodNaroznikToolStripMenuItem
            // 
            this.wschodNaroznikToolStripMenuItem.Name = "wschodNaroznikToolStripMenuItem";
            this.wschodNaroznikToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.wschodNaroznikToolStripMenuItem.Text = "Wschód";
            this.wschodNaroznikToolStripMenuItem.Click += new System.EventHandler(this.wschodNaroznikToolStripMenuItem_Click);
            // 
            // zachodNaroznikToolStripMenuItem
            // 
            this.zachodNaroznikToolStripMenuItem.Name = "zachodNaroznikToolStripMenuItem";
            this.zachodNaroznikToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.zachodNaroznikToolStripMenuItem.Text = "Zachód";
            this.zachodNaroznikToolStripMenuItem.Click += new System.EventHandler(this.zachodNaroznikToolStripMenuItem_Click);
            // 
            // polnocnyzachodNaroznikToolStripMenuItem
            // 
            this.polnocnyzachodNaroznikToolStripMenuItem.Name = "polnocnyzachodNaroznikToolStripMenuItem";
            this.polnocnyzachodNaroznikToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.polnocnyzachodNaroznikToolStripMenuItem.Text = "Północny-Zachód";
            this.polnocnyzachodNaroznikToolStripMenuItem.Click += new System.EventHandler(this.polnocnyzachodNaroznikToolStripMenuItem_Click);
            // 
            // poludniowyWschodNaroznikToolStripMenuItem
            // 
            this.poludniowyWschodNaroznikToolStripMenuItem.Name = "poludniowyWschodNaroznikToolStripMenuItem";
            this.poludniowyWschodNaroznikToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.poludniowyWschodNaroznikToolStripMenuItem.Text = "Południowy-Wschód";
            this.poludniowyWschodNaroznikToolStripMenuItem.Click += new System.EventHandler(this.poludniowyWschodNaroznikToolStripMenuItem_Click);
            // 
            // kuwaharToolStripMenuItem
            // 
            this.kuwaharToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maska3KuwaharToolStripMenuItem,
            this.maska5KuwaharToolStripMenuItem});
            this.kuwaharToolStripMenuItem.Name = "kuwaharToolStripMenuItem";
            this.kuwaharToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.kuwaharToolStripMenuItem.Text = "Kuwahar";
            this.kuwaharToolStripMenuItem.Visible = false;
            // 
            // maska3KuwaharToolStripMenuItem
            // 
            this.maska3KuwaharToolStripMenuItem.Name = "maska3KuwaharToolStripMenuItem";
            this.maska3KuwaharToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.maska3KuwaharToolStripMenuItem.Text = "Maska 3x3";
            this.maska3KuwaharToolStripMenuItem.Click += new System.EventHandler(this.maska3KuwaharToolStripMenuItem_Click);
            // 
            // maska5KuwaharToolStripMenuItem
            // 
            this.maska5KuwaharToolStripMenuItem.Name = "maska5KuwaharToolStripMenuItem";
            this.maska5KuwaharToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.maska5KuwaharToolStripMenuItem.Text = "Maska 5x5";
            this.maska5KuwaharToolStripMenuItem.Click += new System.EventHandler(this.maska5KuwaharToolStripMenuItem_Click);
            // 
            // medianowyToolStripMenuItem
            // 
            this.medianowyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maska3MedianToolStripMenuItem,
            this.maska5MedianToolStripMenuItem});
            this.medianowyToolStripMenuItem.Name = "medianowyToolStripMenuItem";
            this.medianowyToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.medianowyToolStripMenuItem.Text = "Medianowy";
            this.medianowyToolStripMenuItem.Visible = false;
            // 
            // maska3MedianToolStripMenuItem
            // 
            this.maska3MedianToolStripMenuItem.Name = "maska3MedianToolStripMenuItem";
            this.maska3MedianToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.maska3MedianToolStripMenuItem.Text = "Maska 3x3";
            this.maska3MedianToolStripMenuItem.Click += new System.EventHandler(this.maska3MedianToolStripMenuItem_Click);
            // 
            // maska5MedianToolStripMenuItem
            // 
            this.maska5MedianToolStripMenuItem.Name = "maska5MedianToolStripMenuItem";
            this.maska5MedianToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.maska5MedianToolStripMenuItem.Text = "Maska 5x5";
            this.maska5MedianToolStripMenuItem.Click += new System.EventHandler(this.maska5MedianToolStripMenuItem_Click);
            // 
            // cannaToolStripMenuItem
            // 
            this.cannaToolStripMenuItem.Name = "cannaToolStripMenuItem";
            this.cannaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cannaToolStripMenuItem.Text = "Canna";
            this.cannaToolStripMenuItem.Visible = false;
            this.cannaToolStripMenuItem.Click += new System.EventHandler(this.cannaToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            this.pomocToolStripMenuItem.Click += new System.EventHandler(this.pomocToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.pustyLabel);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 460);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(895, 22);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.SizeChanged += new System.EventHandler(this.flowLayoutPanel1_SizeChanged);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 7;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Location = new System.Drawing.Point(59, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 18);
            this.label5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(67, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rozmiar:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(121, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Location = new System.Drawing.Point(227, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 18);
            this.label3.TabIndex = 2;
            // 
            // pustyLabel
            // 
            this.pustyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pustyLabel.Location = new System.Drawing.Point(235, 0);
            this.pustyLabel.Name = "pustyLabel";
            this.pustyLabel.Size = new System.Drawing.Size(388, 18);
            this.pustyLabel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Location = new System.Drawing.Point(629, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 18);
            this.label4.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.progressBar1.Location = new System.Drawing.Point(634, 1);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(255, 15);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightGray;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openButton,
            this.saveButton,
            this.toolStripSeparator1,
            this.previousButton,
            this.nextButton,
            this.toolStripSeparator2,
            this.zoomInButton,
            this.zoomOutButton,
            this.zoomResetButton,
            this.centerButton,
            this.resetButton,
            this.toolStripSeparator3,
            this.kopiaButton,
            this.rButton,
            this.gButton,
            this.bButton,
            this.histogramButton,
            this.toolStripSeparator4,
            this.grayScaleButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(895, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // procentowaToolStripMenuItem
            // 
            this.procentowaToolStripMenuItem.Name = "procentowaToolStripMenuItem";
            this.procentowaToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.procentowaToolStripMenuItem.Text = "Procentowa";
            this.procentowaToolStripMenuItem.Click += new System.EventHandler(this.procentowaToolStripMenuItem_Click);
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(23, 22);
            this.openButton.Text = "toolStripButton1";
            this.openButton.ToolTipText = "Otwórz";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "toolStripButton2";
            this.saveButton.ToolTipText = "Zapisz";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previousButton.Image = ((System.Drawing.Image)(resources.GetObject("previousButton.Image")));
            this.previousButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(23, 22);
            this.previousButton.Text = "toolStripButton3";
            this.previousButton.ToolTipText = "Do tyłu";
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.Image")));
            this.nextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(23, 22);
            this.nextButton.Text = "toolStripButton4";
            this.nextButton.ToolTipText = "Do przodu";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // zoomInButton
            // 
            this.zoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInButton.Image")));
            this.zoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(23, 22);
            this.zoomInButton.Text = "toolStripButton1";
            this.zoomInButton.ToolTipText = "Przybliż";
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutButton.Image")));
            this.zoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(23, 22);
            this.zoomOutButton.Text = "toolStripButton3";
            this.zoomOutButton.ToolTipText = "Oddal";
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomResetButton
            // 
            this.zoomResetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomResetButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomResetButton.Image")));
            this.zoomResetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomResetButton.Name = "zoomResetButton";
            this.zoomResetButton.Size = new System.Drawing.Size(23, 22);
            this.zoomResetButton.Text = "toolStripButton2";
            this.zoomResetButton.ToolTipText = "Rozmiar oryginalny";
            this.zoomResetButton.Click += new System.EventHandler(this.zoomResetButton_Click);
            // 
            // centerButton
            // 
            this.centerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.centerButton.Image = ((System.Drawing.Image)(resources.GetObject("centerButton.Image")));
            this.centerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.centerButton.Name = "centerButton";
            this.centerButton.Size = new System.Drawing.Size(23, 22);
            this.centerButton.Text = "toolStripButton1";
            this.centerButton.ToolTipText = "Wyśrodkuj obraz";
            this.centerButton.Click += new System.EventHandler(this.centerButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
            this.resetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(23, 22);
            this.resetButton.Text = "toolStripButton1";
            this.resetButton.ToolTipText = "Resetuj obraz";
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // kopiaButton
            // 
            this.kopiaButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kopiaButton.Image = ((System.Drawing.Image)(resources.GetObject("kopiaButton.Image")));
            this.kopiaButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kopiaButton.Name = "kopiaButton";
            this.kopiaButton.Size = new System.Drawing.Size(23, 22);
            this.kopiaButton.Text = "toolStripButton1";
            this.kopiaButton.ToolTipText = "Wersja robocza";
            this.kopiaButton.Click += new System.EventHandler(this.kopiaButton_Click);
            // 
            // rButton
            // 
            this.rButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rButton.Image = ((System.Drawing.Image)(resources.GetObject("rButton.Image")));
            this.rButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rButton.Name = "rButton";
            this.rButton.Size = new System.Drawing.Size(23, 22);
            this.rButton.Text = "toolStripButton1";
            this.rButton.ToolTipText = "Warstwa R";
            this.rButton.Click += new System.EventHandler(this.rButton_Click);
            // 
            // gButton
            // 
            this.gButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gButton.Image = ((System.Drawing.Image)(resources.GetObject("gButton.Image")));
            this.gButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gButton.Name = "gButton";
            this.gButton.Size = new System.Drawing.Size(23, 22);
            this.gButton.Text = "toolStripButton2";
            this.gButton.ToolTipText = "Warstwa G";
            this.gButton.Click += new System.EventHandler(this.gButton_Click);
            // 
            // bButton
            // 
            this.bButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bButton.Image = ((System.Drawing.Image)(resources.GetObject("bButton.Image")));
            this.bButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bButton.Name = "bButton";
            this.bButton.Size = new System.Drawing.Size(23, 22);
            this.bButton.Text = "toolStripButton3";
            this.bButton.ToolTipText = "Warstwa B";
            this.bButton.Click += new System.EventHandler(this.bButton_Click);
            // 
            // histogramButton
            // 
            this.histogramButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.histogramButton.Image = ((System.Drawing.Image)(resources.GetObject("histogramButton.Image")));
            this.histogramButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.histogramButton.Name = "histogramButton";
            this.histogramButton.Size = new System.Drawing.Size(23, 22);
            this.histogramButton.Text = "toolStripButton4";
            this.histogramButton.ToolTipText = "Histogram";
            this.histogramButton.Click += new System.EventHandler(this.histogramButton_Click);
            // 
            // grayScaleButton
            // 
            this.grayScaleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.grayScaleButton.Image = ((System.Drawing.Image)(resources.GetObject("grayScaleButton.Image")));
            this.grayScaleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.grayScaleButton.Name = "grayScaleButton";
            this.grayScaleButton.Size = new System.Drawing.Size(23, 22);
            this.grayScaleButton.Text = "toolStripButton5";
            this.grayScaleButton.ToolTipText = "Czarno-biały";
            this.grayScaleButton.Click += new System.EventHandler(this.grayScaleButton_Click);
            // 
            // OryginalPictureBox
            // 
            this.OryginalPictureBox.Location = new System.Drawing.Point(10, 9);
            this.OryginalPictureBox.Name = "OryginalPictureBox";
            this.OryginalPictureBox.Size = new System.Drawing.Size(419, 391);
            this.OryginalPictureBox.TabIndex = 0;
            this.OryginalPictureBox.TabStop = false;
            this.OryginalPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OryginalPictureBox_MouseDown);
            this.OryginalPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OryginalPictureBox_MouseMove);
            this.OryginalPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OryginalPictureBox_MouseUp);
            // 
            // KopiaPictureBox
            // 
            this.KopiaPictureBox.Location = new System.Drawing.Point(16, 9);
            this.KopiaPictureBox.Name = "KopiaPictureBox";
            this.KopiaPictureBox.Size = new System.Drawing.Size(419, 391);
            this.KopiaPictureBox.TabIndex = 0;
            this.KopiaPictureBox.TabStop = false;
            this.KopiaPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KopiaPictureBox_MouseDown);
            // 
            // fuzzyToolStripMenuItem
            // 
            this.fuzzyToolStripMenuItem.Name = "fuzzyToolStripMenuItem";
            this.fuzzyToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.fuzzyToolStripMenuItem.Text = "Fuzzy";
            this.fuzzyToolStripMenuItem.Click += new System.EventHandler(this.fuzzyToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(895, 482);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Biometria";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.histogramPanel.ResumeLayout(false);
            this.histogramPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OryginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KopiaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Obrazek obiektObrazek;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox OryginalPictureBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorRGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozjasnijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RozciagniecieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyrownanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przyciemnijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binaryzacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recznyProgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automatycznyProgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lokalnaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator kreskaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem czarnoBiałeToolStripMenuItem1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label pustyLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton previousButton;
        private System.Windows.Forms.ToolStripButton nextButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton grayScaleButton;
        private System.Windows.Forms.ToolStripButton zoomInButton;
        private System.Windows.Forms.ToolStripButton zoomOutButton;
        private System.Windows.Forms.ToolStripButton zoomResetButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton centerButton;
        private System.Windows.Forms.ToolStripButton rButton;
        private System.Windows.Forms.ToolStripButton gButton;
        private System.Windows.Forms.ToolStripButton bButton;
        private System.Windows.Forms.ToolStripButton histogramButton;
        private System.Windows.Forms.PictureBox KopiaPictureBox;
        private System.Windows.Forms.ToolStripButton resetButton;
        private System.Windows.Forms.Panel histogramPanel;
        private System.Windows.Forms.Label OdchWartoscL;
        private System.Windows.Forms.Label OdchL;
        private System.Windows.Forms.Label SredniaWartosc;
        private System.Windows.Forms.Label SredniaL;
        private System.Windows.Forms.Label LiczbaWartoscL;
        private System.Windows.Forms.Label LiczbaL;
        private System.Windows.Forms.Label PoziomValueL;
        private System.Windows.Forms.Label PoziomL;
        private System.Windows.Forms.ComboBox HistogramComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripButton kopiaButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozmycieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lapleaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wykrycieNarożnikówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kuwaharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maskaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pionowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poziomyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pionowyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem poziomyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pionowyLaplaceToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem poziomyLaplaceToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem skosnyLaplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wschodNaroznikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zachodNaroznikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polnocnyzachodNaroznikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poludniowyWschodNaroznikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maska3KuwaharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maska5KuwaharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maska3MedianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maska5MedianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cannaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procentowaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuzzyToolStripMenuItem;
    }
}


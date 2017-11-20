using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using biometria_1.Properties;

namespace biometria_1
{
    public partial class Form1 : Form
    {
        private int PixelX = 0;
        private int PixelY = 0;
        private Bitmap kopia;
        private int zoom = 0;
        private int zoomRGB = 0;
        private bool rgb = false;
        private Control actcontrol;
        private Point preloc;
        private int zoomFactor = 100;
        private int opcja = 0;  //0-kopia 1-r 2-g 3-b

        public Form1()
        {
            InitializeComponent();
        }

        #region Pomocnicze
        private void Clear()
        {
            OryginalPictureBox.Image = null;
            OryginalPictureBox.Update();
            OryginalPictureBox.Height = 386;
            OryginalPictureBox.Width = 438;
            KopiaPictureBox.Image = null;
            OryginalPictureBox.Update();
        }

        private void Center()
        {
            OryginalPictureBox.Location = CenterImage(OryginalPictureBox.Size.Width,
                OryginalPictureBox.Size.Height,
                splitContainer1.Panel1.Width, splitContainer1.Panel1.Height);
            KopiaPictureBox.Location = CenterImage(KopiaPictureBox.Size.Width, KopiaPictureBox.Size.Height,
                splitContainer1.Panel2.Width, splitContainer1.Panel2.Height);
        }

        private Point CenterImage(int xx, int yy, int sx, int sy)
        {
            double x = (sx - xx)/2;
            double y = (sy - yy)/2;
            x += splitContainer1.Panel1.Location.X;
            y += splitContainer1.Panel1.Location.Y;
            return new Point((int) x, (int) y);
        }

        private void LoadImage()
        {
            obiektObrazek = new Obrazek();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Clear();

                string sciezka = openFileDialog.FileName;

                if (File.Exists(sciezka))
                {
                    obiektObrazek.Oryginal = new Bitmap(sciezka);
                    obiektObrazek.Oryginal = CreateNonIndexedImage(obiektObrazek.Oryginal);
                    obiektObrazek.Kopia = new Bitmap(sciezka);
                    obiektObrazek.Kopia = CreateNonIndexedImage(obiektObrazek.Kopia);
                    OryginalPictureBox.Size = obiektObrazek.Oryginal.Size;
                    KopiaPictureBox.Size = obiektObrazek.Oryginal.Size;

                    OryginalPictureBox.Image = Image.FromFile(sciezka);
                    KopiaPictureBox.Image = Image.FromFile(sciezka);
                    filtryToolStripMenuItem.Visible = true;
                    resetujToolStripMenuItem.Visible = true;
                    label2.Text = obiektObrazek.Oryginal.Width + " x " + obiektObrazek.Oryginal.Height;
                    label6.Text = zoomFactor + "%";
                    label1.Visible = true;
                    Center();
                }
                else
                {
                    MessageBox.Show(@"Brak pliku", @"", MessageBoxButtons.OK, MessageBoxIcon.None,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void KopiaPictureBox_Choose()
        {
            Bitmap obrazek1 = null;
            switch (opcja)
            {
                case 0:
                    obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                    break;
                case 1:
                    obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.R), zoomFactor);
                    break;
                case 2:
                    obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.G), zoomFactor);
                    break;
                case 3:
                    obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.B), zoomFactor);
                    break;
            }
            KopiaPictureBox.Size = obrazek1.Size;
            KopiaPictureBox.Image = obrazek1;
        }

        private Bitmap CreateNonIndexedImage(Image src)
        {
            if (src.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics gfx = Graphics.FromImage(newBmp))
                {
                    gfx.DrawImage(src, 0, 0);
                }

                return newBmp;
            }
            else
            {
                Bitmap mapa = new Bitmap(src);
                return mapa;
            }

        }
        private void SaveImage(Image obrazek)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog.FileName;
                int typ = saveFileDialog.FilterIndex;

                switch (typ)
                {
                    case 1:
                        obrazek.Save(name, ImageFormat.Gif);
                        break;
                    case 2:
                        obrazek.Save(name, ImageFormat.Jpeg);
                        break;
                    case 3:
                        obrazek.Save(name, ImageFormat.Tiff);
                        break;
                }
            }
        }

        private void DisableButtons()
        {
            menuStrip1.Enabled = false;
            toolStrip1.Enabled = false;
        }

        private void EnableButtons()
        {
            menuStrip1.Enabled = true;
            toolStrip1.Enabled = true;
        }
        #endregion

        #region Form Controls Events
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Center();
        }
        private void HistogramComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            double srednia = 0;
            double odchylenie = 0;
            switch (HistogramComboBox.SelectedIndex)
            {
                case 0:
                    chart1.Series[0].Color = chart1.PaletteCustomColors[0];
                    srednia = Tools.GetSrednia(obiektObrazek.histogram_r, 0, obiektObrazek.histogram_r.Length);
                    odchylenie = Tools.GetOdchylenie(obiektObrazek.histogram_r, srednia);
                    SredniaWartosc.Text =
                        Math.Round(srednia, 2, MidpointRounding.AwayFromZero)
                            .ToString(CultureInfo.CurrentCulture);
                    OdchWartoscL.Text = Math.Round(odchylenie, 2, MidpointRounding.AwayFromZero)
                        .ToString(CultureInfo.CurrentCulture);

                    Tools.DisplayHistogram(obiektObrazek.PunktyR, chart1);
                    break;
                case 1:
                    chart1.Series[0].Color = chart1.PaletteCustomColors[1];
                    srednia = Tools.GetSrednia(obiektObrazek.histogram_g, 0, obiektObrazek.histogram_g.Length);
                    odchylenie = Tools.GetOdchylenie(obiektObrazek.histogram_g, srednia);
                    SredniaWartosc.Text =
                        Math.Round(srednia, 2, MidpointRounding.AwayFromZero)
                            .ToString(CultureInfo.CurrentCulture);
                    OdchWartoscL.Text = Math.Round(odchylenie, 2, MidpointRounding.AwayFromZero)
                        .ToString(CultureInfo.CurrentCulture);

                    Tools.DisplayHistogram(obiektObrazek.PunktyG, chart1);
                    break;
                case 2:
                    chart1.Series[0].Color = chart1.PaletteCustomColors[2];
                    srednia = Tools.GetSrednia(obiektObrazek.histogram_b, 0, obiektObrazek.histogram_b.Length);
                    odchylenie = Tools.GetOdchylenie(obiektObrazek.histogram_b, srednia);
                    SredniaWartosc.Text =
                        Math.Round(srednia, 2, MidpointRounding.AwayFromZero)
                            .ToString(CultureInfo.CurrentCulture);
                    OdchWartoscL.Text = Math.Round(odchylenie, 2, MidpointRounding.AwayFromZero)
                        .ToString(CultureInfo.CurrentCulture);
                    Tools.DisplayHistogram(obiektObrazek.PunktyB, chart1);
                    break;
                case 3:
                    chart1.Series[0].Color = chart1.PaletteCustomColors[3];
                    srednia = Tools.GetSrednia(obiektObrazek.histogram_u, 0, obiektObrazek.histogram_u.Length);
                    odchylenie = Tools.GetOdchylenie(obiektObrazek.histogram_u, srednia);
                    SredniaWartosc.Text =
                        Math.Round(srednia, 2, MidpointRounding.AwayFromZero)
                            .ToString(CultureInfo.CurrentCulture);
                    OdchWartoscL.Text = Math.Round(odchylenie, 2, MidpointRounding.AwayFromZero)
                        .ToString(CultureInfo.CurrentCulture);
                    Tools.DisplayHistogram(obiektObrazek.PunktyU, chart1);
                    break;
            }
        }
        
        //Pasek statusu
        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            pustyLabel.Width = flowLayoutPanel1.Width - label1.Width - label2.Width - label3.Width - label4.Width -
                               progressBar1.Width - label5.Width - label6.Width - 50;
        }
        #endregion

        #region Mouse Events
        private void OryginalPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (actcontrol == null || actcontrol != sender)
                return;
            var location = actcontrol.Location;
            location.Offset(e.Location.X - preloc.X, e.Location.Y - preloc.Y);
            actcontrol.Location = location;
            KopiaPictureBox.Location = location;
        }

        private void OryginalPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                actcontrol = null;
                Cursor = Cursors.Default;
            }
        }

        private void OryginalPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && OryginalPictureBox.Image != null)
            {
                actcontrol = sender as Control;
                preloc = e.Location;
                Cursor = Cursors.Default;
            }
            if (e.Button == MouseButtons.Right && OryginalPictureBox.Image != null)
            {
                var dana = ((Bitmap) OryginalPictureBox.Image).GetPixel(e.X, e.Y);
                PixelX = e.X;
                PixelY = e.Y;
                PikselForm pikselForm = new PikselForm(dana.A, dana.R, dana.G, dana.B, true);
                PixelChanged_Value(pikselForm);
                pikselForm.ShowDialog();
            }
        }

        private void KopiaPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && KopiaPictureBox.Image != null)
            {
                var dana = ((Bitmap) KopiaPictureBox.Image).GetPixel(e.X, e.Y);
                PikselForm pikselForm = new PikselForm(dana.A, dana.R, dana.G, dana.B, false);
                pikselForm.ShowDialog();
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var results = chart1.HitTest(e.X, e.Y, false,
                ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    double X = result.ChartArea.AxisX.PixelPositionToValue(e.X);
                    int x = (int)X - 1;
                    if (x >= 0 && x <= 255)
                    {
                        PoziomValueL.Text = x.ToString();
                        switch (HistogramComboBox.SelectedIndex)
                        {
                            case 0:
                                LiczbaWartoscL.Text = obiektObrazek.histogram_r[x].ToString();
                                break;
                            case 1:
                                LiczbaWartoscL.Text = obiektObrazek.histogram_g[x].ToString();
                                break;
                            case 2:
                                LiczbaWartoscL.Text = obiektObrazek.histogram_b[x].ToString();
                                break;
                            case 3:
                                LiczbaWartoscL.Text = obiektObrazek.histogram_u[x].ToString();
                                break;
                        }
                    }
                    else
                    {
                        PoziomValueL.Text = "";
                        LiczbaWartoscL.Text = "";
                    }
                }
            }
        }
        #endregion

        #region Change pixel Event
        //obsługa eventu zmiany wartości piksela w Form2
        private void PixelChanged_Value(PikselForm f)
        {
            f.PixelValueChanged += new PikselForm.PixelEventHandler(Changed);
        }

        private void Changed(PikselForm f, PixelEventArgs e)
        {
            float ratioX = PixelX / (float)OryginalPictureBox.ClientSize.Width;
            float ratioY = PixelY / (float)OryginalPictureBox.ClientSize.Height;

            float imageX = obiektObrazek.Kopia.Width * ratioX;
            float imageY = obiektObrazek.Kopia.Height * ratioY;

            obiektObrazek.ClearNext();
            obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
            obiektObrazek.Kopia.SetPixel((int)imageX, (int)imageY, Color.FromArgb(e.A, e.R, e.G, e.B));
            int x = obiektObrazek.Oryginal.Width + zoom;
            int y = obiektObrazek.Oryginal.Height + zoom;
            kopia = new Bitmap(obiektObrazek.Kopia, new Size(x, y));
            KopiaPictureBox.Image = kopia;
        }
        #endregion

        #region Menu toolStrip
        //Menu toolStrip
        private void wczytajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImage();

        }

        //Zapis 
        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveButton_Click(saveButton, EventArgs.Empty);
        }

        //Pomoc
        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"1) Aby przybliżyć/oddalić obraz użyj Scroll'a myszy." + "\n"
                            + @"2) Aby przesunąć obraz wciśnij lewy przycisk myszy na obrazie i przesuń mysz." + "\n"
                            + @"3) Aby wyświetlić wartość piksela wciśnij prawy przycisk myszy.", @"",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        //Resetuj
        private void resetujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KopiaPictureBox.Image = obiektObrazek.Oryginal;
            obiektObrazek.Kopia = obiektObrazek.Oryginal;
            obiektObrazek.Clear();
        }

        //Zamknij
        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Toolbar
        private void openButton_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                switch (opcja)
                {
                    case 0:
                        SaveImage(obiektObrazek.Kopia);
                        break;
                    case 1:
                        SaveImage(obiektObrazek.R);
                        break;
                    case 2:
                        SaveImage(obiektObrazek.G);
                        break;
                    case 3:
                        SaveImage(obiektObrazek.B);
                        break;
                }
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                if (obiektObrazek.Pervous())
                {
                    var result = obiektObrazek.ChangeHistory('p');
                    if (result != null)
                    {
                        obiektObrazek.Kopia = result;
                        Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                        KopiaPictureBox.Size = obrazek1.Size;
                        KopiaPictureBox.Image = obrazek1;
                    }
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                if (obiektObrazek.Next())
                {
                    var result = obiektObrazek.ChangeHistory('n');
                    if (result != null)
                    {
                        obiektObrazek.Kopia = result;
                        Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                        KopiaPictureBox.Size = obrazek1.Size;
                        KopiaPictureBox.Image = obrazek1;
                    }
                }

            }
        }

        private void grayScaleButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                opcja = 0;
                obiektObrazek.ClearNext();
                obiektObrazek.AddOperation_toList(new Bitmap(obiektObrazek.Kopia));
                Tools.ZamienObraz_CzarnoBialy(obiektObrazek.Kopia);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && zoomFactor < 1000 && obiektObrazek.Oryginal != null)
            {
                int tmp = zoomFactor / 4;
                zoomFactor += tmp;
                if (zoomFactor < 110 && zoomFactor > 90)
                {
                    zoomFactor = 100;
                }
                Bitmap obrazek = Tools.Zoom(new Bitmap(obiektObrazek.Oryginal), zoomFactor);
                OryginalPictureBox.Size = obrazek.Size;
                OryginalPictureBox.Image = obrazek;

                KopiaPictureBox_Choose();

                label6.Text = zoomFactor + "%";
                Center();
            }

        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && zoomFactor > 5 && obiektObrazek.Oryginal != null)
            {
                int tmp = zoomFactor / 4;
                zoomFactor -= tmp;
                if (zoomFactor < 110 && zoomFactor > 90)
                {
                    zoomFactor = 100;
                }
                Bitmap obrazek = Tools.Zoom(new Bitmap(obiektObrazek.Oryginal), zoomFactor);
                OryginalPictureBox.Size = obrazek.Size;
                OryginalPictureBox.Image = obrazek;
                KopiaPictureBox_Choose();
                label6.Text = zoomFactor + "%";
                Center();
            }
        }

        private void zoomResetButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                zoomFactor = 100;
                Bitmap obrazek = Tools.Zoom(new Bitmap(obiektObrazek.Oryginal), zoomFactor);
                OryginalPictureBox.Size = obrazek.Size;
                OryginalPictureBox.Image = obrazek;
                KopiaPictureBox_Choose();
                label6.Text = zoomFactor + "%";
                Center();
            }
        }

        private void centerButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                Center();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                obiektObrazek.Kopia = obiektObrazek.Oryginal;
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Oryginal), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
                obiektObrazek.Clear();
                opcja = 0;
            }

        }

        private void rButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                opcja = 1;
                histogramPanel.Visible = false;
                Bitmap czerwony = new Bitmap(obiektObrazek.Kopia);
                Tools.PobierzWarstweKoloru(czerwony, 'r');
                obiektObrazek.R = czerwony;
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(czerwony), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void gButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                opcja = 2;
                histogramPanel.Visible = false;
                Bitmap zielony = new Bitmap(obiektObrazek.Kopia);
                Tools.PobierzWarstweKoloru(zielony, 'g');
                obiektObrazek.G = zielony;
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(zielony), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void bButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                opcja = 3;
                histogramPanel.Visible = false;
                Bitmap niebieski = new Bitmap(obiektObrazek.Kopia);
                Tools.PobierzWarstweKoloru(niebieski, 'b');
                obiektObrazek.B = niebieski;
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(niebieski), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void histogramButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                opcja = 0;
                histogramPanel.Visible = true;
                obiektObrazek.ClearHistogram();
                Tools.GetRGBHistogramPoints(obiektObrazek.Kopia, obiektObrazek);
                HistogramComboBox.SelectedIndex = 1;
                HistogramComboBox.SelectedIndex = 3;
            }
        }

        private void kopiaButton_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && obiektObrazek.Oryginal != null)
            {
                opcja = 0;
                histogramPanel.Visible = false;
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }
        #endregion

        #region Filtry
        //Filtry - Histogram
        private void RozciagniecieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            obiektObrazek.ClearHistogram();
            Tools.GetRGBHistogramPoints(obiektObrazek.Kopia, obiektObrazek);
            FormResult wynik = PoziomForm.ExecuteForm(obiektObrazek);
            if (wynik.Result == DialogResult.OK)
            {
                obiektObrazek.ClearHistogram();
                Tools.GetRGBHistogramPoints(obiektObrazek.Kopia, obiektObrazek);
                int[] lut = Tools.GetLUTRozciaganie(wynik.Min, wynik.Max);

                obiektObrazek.ClearNext();
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);

                obiektObrazek.Kopia = Tools.RozciagnijHistogram(lut, obiektObrazek.Kopia, wynik.Warstwa);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
                obiektObrazek.ClearHistogram();
                Tools.GetRGBHistogramPoints(obiektObrazek.Kopia, obiektObrazek);
                HistogramComboBox.SelectedIndex = 1;
                HistogramComboBox.SelectedIndex = 3;
                opcja = 0;
            }
        }

        private void wyrownanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            obiektObrazek.ClearHistogram();
            Tools.GetRGBHistogramPoints(obiektObrazek.Kopia, obiektObrazek);
            double[] dystR = Tools.GetDystrybuanta(obiektObrazek.histogram_r, obiektObrazek.MaxPixeli);
            double[] dystG = Tools.GetDystrybuanta(obiektObrazek.histogram_g, obiektObrazek.MaxPixeli);
            double[] dystB = Tools.GetDystrybuanta(obiektObrazek.histogram_b, obiektObrazek.MaxPixeli);

            int[] LutR = Tools.GetLUTWyrownanie(dystR, obiektObrazek.histogram_r.Length);
            int[] LutG = Tools.GetLUTWyrownanie(dystG, obiektObrazek.histogram_g.Length);
            int[] LutB = Tools.GetLUTWyrownanie(dystB, obiektObrazek.histogram_b.Length);

            obiektObrazek.ClearNext();
            obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);

            obiektObrazek.Kopia = Tools.WyrownajHistogram(LutR, LutG, LutB, obiektObrazek.Kopia);
            Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
            KopiaPictureBox.Size = obrazek1.Size;
            KopiaPictureBox.Image = obrazek1;
            Center();

            obiektObrazek.ClearHistogram();
            Tools.GetRGBHistogramPoints(obiektObrazek.Kopia, obiektObrazek);
            HistogramComboBox.SelectedIndex = 1;
            HistogramComboBox.SelectedIndex = 3;
            opcja = 0;
        }

        //Filtry - RGB
        private void rozjasnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            int[] lut = new int[256];

            int[] histogram = Tools.GetHistogramUsredniony(obiektObrazek.Kopia);
            int max = 0;
            for (int j = 255; j >= 0; j--)
            {
                if (histogram[j] > 0)
                {
                    max = j;
                    break;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                double licznik = Math.Log(1 + i);
                double mianownik = Math.Log(1 + max);
                lut[i] = (int)Math.Round(255.0 * (licznik/mianownik), 0, MidpointRounding.AwayFromZero);

                if (lut[i] > 255)
                {
                    lut[i] = 255;
                }
                if (lut[i] < 0)
                {
                    lut[i] = 0;
                }
            }

            Bitmap rozjasniony = new Bitmap(obiektObrazek.Kopia);

            unsafe
            {
                BitmapData bitmapData = rozjasniony.LockBits(
                    new Rectangle(0, 0, rozjasniony.Width, rozjasniony.Height), ImageLockMode.ReadWrite,
                    rozjasniony.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(rozjasniony.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        // calculate new pixel value
                        currentLine[x] = (byte)lut[oldBlue];
                        currentLine[x + 1] = (byte)lut[oldGreen];
                        currentLine[x + 2] = (byte)lut[oldRed];
                    }
                }
                rozjasniony.UnlockBits(bitmapData);
            }
            obiektObrazek.ClearNext();
            obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
            obiektObrazek.Kopia = rozjasniony;
            Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
            KopiaPictureBox.Size = obrazek1.Size;
            KopiaPictureBox.Image = obrazek1;
            Center();
            opcja = 0;
        }

        private void przyciemnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            int[] lut = new int[256];
            int[] histogram = Tools.GetHistogramUsredniony(obiektObrazek.Kopia);
            int max = 0;
            for (int j = 255; j >= 0; j--)
            {
                if (histogram[j] > 0)
                {
                    max = j;
                    break;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                lut[i] = (int)Math.Round(255.0 * (Math.Pow((double)i / max, 2.0)), 0, MidpointRounding.AwayFromZero);

                if (lut[i] > 255)
                {
                    lut[i] = 255;
                }
                if (lut[i] < 0)
                {
                    lut[i] = 0;
                }
            }

            Bitmap przyciemniony = new Bitmap(obiektObrazek.Kopia);

            unsafe
            {
                BitmapData bitmapData = przyciemniony.LockBits(
                    new Rectangle(0, 0, przyciemniony.Width, przyciemniony.Height), ImageLockMode.ReadWrite,
                    przyciemniony.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(przyciemniony.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        // calculate new pixel value
                        currentLine[x] = (byte)lut[oldBlue];
                        currentLine[x + 1] = (byte)lut[oldGreen];
                        currentLine[x + 2] = (byte)lut[oldRed];
                    }
                }
                przyciemniony.UnlockBits(bitmapData);
            }
            obiektObrazek.ClearNext();
            obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
            obiektObrazek.Kopia = przyciemniony;
            Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
            KopiaPictureBox.Size = obrazek1.Size;
            KopiaPictureBox.Image = obrazek1;
            Center();
            opcja = 0;
        }

        private void czarnobialeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            grayScaleButton_Click(grayScaleButton,EventArgs.Empty);
        }

        //Filtry - Binaryzacja reczna
        private void recznyProgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayScaleButton_Click(grayScaleButton, EventArgs.Empty);
            if (!Tools.ObrazKolor(obiektObrazek.Kopia))
            {
                progressBar1.Visible = false;
                BinaryzacjaResult wynik = Binaryzacja.ExecuteTreshold(obiektObrazek.Kopia);
                if (wynik.Result == DialogResult.OK)
                {
                    opcja = 0;
                    obiektObrazek.ClearNext();
                    obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                    obiektObrazek.Kopia = Tools.BinaryzacjaReczna(obiektObrazek.Kopia, wynik.RecznyProg);
                    Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                    KopiaPictureBox.Size = obrazek1.Size;
                    KopiaPictureBox.Image = obrazek1;
                    Center();
                }
            }
            else
            {
                MessageBox.Show("Obraz musi być czarno-biały!", "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            } 
        }

        //Filtry - Binaryzacja Otsu
        private void automatycznyProgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Tools.ObrazKolor(obiektObrazek.Kopia))
            {
                progressBar1.Visible = false;
                opcja = 0;
                int treshold = Tools.GetWariancjaMiedzyklasowa(obiektObrazek.Kopia);
                obiektObrazek.ClearNext();
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.BinaryzacjaReczna(obiektObrazek.Kopia, treshold);
                KopiaPictureBox.Size = obiektObrazek.Kopia.Size;
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
            else
            {
                MessageBox.Show("Obraz musi być czarno-biały!", "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        //Filtr - Binaryzacja Niblacka
        private async void lokalnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Tools.ObrazKolor(obiektObrazek.Kopia))
            {    
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                progressBar1.Maximum = obiektObrazek.Kopia.Width*obiektObrazek.Kopia.Height;
                var progress = new Progress<int>(value=>
                {
                    progressBar1.Value ++;
                });
                NiblackResult result = NiblackForm.NiblackExecute();
                if (result.Result == DialogResult.OK)
                {
                    DisableButtons();
                    opcja = 0;
                    obiektObrazek.ClearNext();
                    obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                    obiektObrazek.Kopia = await Tools.PerformNiblack(obiektObrazek.Kopia, result.Parametr, result.Wymiary, progress);
                    KopiaPictureBox.Size = obiektObrazek.Kopia.Size;
                    Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                    KopiaPictureBox.Size = obrazek1.Size;
                    KopiaPictureBox.Image = obrazek1;
                    Center();
                    EnableButtons();
                }

            }
            else
            {
                MessageBox.Show("Obraz musi być czarno-biały!", "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            
        }

        //Filtry na maskach
        private void rozmycieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.Blur, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void maskaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                var result = MaskaForm.MaskForm_Execute();
                if (result.Result == DialogResult.OK)
                {
                    obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                    obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, result.MaskaTable, result.Size);
                    Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                    KopiaPictureBox.Size = obrazek1.Size;
                    KopiaPictureBox.Image = obrazek1;
                    Center();
                }
            }
            
        }

        private void pionowyPrewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.PrewittVertical, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void poziomyPrewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.PrewittHorizontal, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void pionowySobelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.SobelVertical, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void poziomySobelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.SobelHorizontal, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void pionowyLaplaceToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.LaplaceVertical, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void poziomyLaplaceToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.LaplaceHorizontal, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void skosnyLaplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.LaplaceDiagonal, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void wschodNaroznikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.NaroznikWschod, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void zachodNaroznikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.NaroznikZachod, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void polnocnyzachodNaroznikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.PolnocnyZachodNaroznik, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void poludniowyWschodNaroznikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.PoludniowyWschodNaroznik, 3);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private async void maska3KuwaharToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Maximum = 100;
                var progress = new Progress<int>(value =>
                {
                    progressBar1.Value = value;
                });
                DisableButtons();
                obiektObrazek.Kopia = await Tools.PerformMask_Kuwahar(3, obiektObrazek.Kopia, progress);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
                EnableButtons();
            }
        }

        private async void maska5KuwaharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Maximum = 100;
                var progress = new Progress<int>(value =>
                {
                    progressBar1.Value = value;
                });
                DisableButtons();
                obiektObrazek.Kopia = await Tools.PerformMask_Kuwahar(5, obiektObrazek.Kopia, progress);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
                EnableButtons();
            }
        }

        private async void maska3MedianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                DisableButtons();
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Maximum = 100;
                var progress = new Progress<int>(value =>
                {
                    progressBar1.Value = value;
                });

                obiektObrazek.Kopia = await Tools.PerformMask_Median(3, obiektObrazek.Kopia, progress);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
                EnableButtons();
            }
        }

        private async void maska5MedianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Maximum = 100;
                var progress = new Progress<int>(value =>
                {
                    progressBar1.Value = value;
                });
                DisableButtons();
                obiektObrazek.Kopia = await Tools.PerformMask_Median(5, obiektObrazek.Kopia, progress);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
                EnableButtons();
            }
        }
        #endregion

        private void cannaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (obiektObrazek != null && KopiaPictureBox.Image != null)
            {
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.PerformMaska(obiektObrazek.Kopia, MaskTables.Gauss, 5);
                obiektObrazek.Kopia = Tools.cann(obiektObrazek.Kopia);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
        }

        private void procentowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayScaleButton_Click(grayScaleButton, EventArgs.Empty);
            if (!Tools.ObrazKolor(obiektObrazek.Kopia))
            {
                progressBar1.Visible = false;
                BinaryzacjaResult wynik = ValueForm.ExecutePercent();
                if (wynik.Result == DialogResult.OK)
                {
                    opcja = 0;
                    obiektObrazek.ClearNext();
                    obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                    obiektObrazek.Kopia = Tools.BinaryzacjaPercent(obiektObrazek.Kopia, wynik.RecznyProg);
                    Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                    KopiaPictureBox.Size = obrazek1.Size;
                    KopiaPictureBox.Image = obrazek1;
                    Center();
                }
            }
            else
            {
                MessageBox.Show("Obraz musi być czarno-biały!", "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void fuzzyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayScaleButton_Click(grayScaleButton, EventArgs.Empty);
            if (!Tools.ObrazKolor(obiektObrazek.Kopia))
            {
                progressBar1.Visible = false;
                opcja = 0;
                obiektObrazek.ClearNext();
                obiektObrazek.AddOperation_toList(obiektObrazek.Kopia);
                obiektObrazek.Kopia = Tools.BinaryzacjaFuzzy(obiektObrazek.Kopia);
                Bitmap obrazek1 = Tools.Zoom(new Bitmap(obiektObrazek.Kopia), zoomFactor);
                KopiaPictureBox.Size = obrazek1.Size;
                KopiaPictureBox.Image = obrazek1;
                Center();
            }
            else
            {
                MessageBox.Show("Obraz musi być czarno-biały!", "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }
    }
}

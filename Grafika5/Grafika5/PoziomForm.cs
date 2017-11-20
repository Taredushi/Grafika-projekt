using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace biometria_1
{
    public partial class PoziomForm : Form
    {
        private static bool _error = false;
        private bool arrow_down = false;
        private int min;
        private int max;
        private int Y;
        private Control actcontrol;
        private Point preloc;
        private static Obrazek obiektObrazek;
        private Bitmap podglad;
        private static char _warstwa;


        public PoziomForm()
        {
            InitializeComponent();
            MinimumTextBox.KeyPress += new KeyPressEventHandler(this.OnKeyPress);
            MaximumTextBox.KeyPress += new KeyPressEventHandler(this.OnKeyPress);
            DrawGradient(Color.Red);
            Y = strzalkaMin.Location.Y;
            min = strzalkaMin.Location.X;
            max = strzalkaMax.Location.X + 1;
            GetObrazekPodglad();
            comboBox1.SelectedIndex = 1;
            comboBox1.SelectedIndex = 0;
            
        }

        private void DrawGradient(Color endColor)
        {
            Bitmap gradient = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(gradient);
            Brush brush = new LinearGradientBrush(new Point(0, 0), new Point(pictureBox1.Width, pictureBox1.Height), Color.Black, endColor);
            graphics.FillRectangle(brush, new Rectangle(new Point(0,0), pictureBox1.Size));
            pictureBox1.Image = gradient;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            else
            {
                e.Handled = true;
            }
        }

        private void GetObrazekPodglad()
        {
            int x = (obiektObrazek.Kopia.Width/2) - (pictureBox2.Width/2);
            int y = (obiektObrazek.Kopia.Height/2) - (pictureBox2.Height/2);
            Point start = new Point(x,y);
            Rectangle section = new Rectangle(start, new Size(pictureBox2.Width, pictureBox2.Height));
            podglad = new Bitmap(pictureBox2.Width,pictureBox2.Height);
            Graphics g = Graphics.FromImage(podglad);
            g.DrawImage(obiektObrazek.Kopia,0,0,section, GraphicsUnit.Pixel);
            pictureBox2.Image = podglad;
        }

        public static FormResult ExecuteForm(Obrazek obiekt)
        {
            obiektObrazek = obiekt;
            
            using (var form = new PoziomForm())
            {
                
                form.OkButton.DialogResult = DialogResult.OK;
                form.CancelButton.DialogResult = DialogResult.Cancel;
                var result = new FormResult();
                result.Result = form.ShowDialog();
                if (result.Result == DialogResult.OK)
                {
                    result.Min = int.Parse(form.MinimumTextBox.Text);
                    result.Max = int.Parse(form.MaximumTextBox.Text);
                    result.Warstwa = _warstwa;
                }

                return result;
            }
        }

        private void MaximumTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(MaximumTextBox.Text) > 255)
            {
                MaximumTextBox.Text = "255";
            }
            if (int.Parse(MaximumTextBox.Text) <= 255 && int.Parse(MinimumTextBox.Text) < int.Parse(MaximumTextBox.Text))
            {
                PodgladUpdate();
            }
            var location = strzalkaMax.Location;
            location.X = int.Parse(MaximumTextBox.Text) + min;
            location.Y = Y;
            strzalkaMax.Location = location;
        }

        private void MinimumTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(MinimumTextBox.Text) > 255)
            {
                MinimumTextBox.Text = "255";
            }
            if (int.Parse(MinimumTextBox.Text) <= 255 && int.Parse(MinimumTextBox.Text) < int.Parse(MaximumTextBox.Text))
            {
                PodgladUpdate();
            }
            strzalkaMin.Location = new Point(min + int.Parse(MinimumTextBox.Text), Y);
        }

        private char GetWarstwa()
        {
            if (SyncCheckBox.Checked)
                return 'w';
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    return 'r';
                case 1:
                    return 'g';
                case 2:
                    return 'b';
            }
            return 'w';
        }
        private void strzalkaMin_MouseDown(object sender, MouseEventArgs e)
        {
            actcontrol = sender as Control;
            preloc = e.Location;
            Cursor = Cursors.Default;
        }

        private void strzalkaMin_MouseUp(object sender, MouseEventArgs e)
        {
            actcontrol = null;
            Cursor = Cursors.Default;
        }

        private void strzalkaMin_MouseMove(object sender, MouseEventArgs e)
        {
            if (actcontrol == null || actcontrol != sender)
                return;
            var location = actcontrol.Location;
            location.Offset(e.Location.X - preloc.X, e.Location.Y - preloc.Y);
            location.Y = Y;
            
            if (location.X > min && location.X < max && location.X < strzalkaMax.Location.X)
            {
                actcontrol.Location = location;
                MinimumTextBox.Text = (location.X - min - 1).ToString();
            }
            
            
        }

        private void strzalkaMax_MouseDown(object sender, MouseEventArgs e)
        {
            actcontrol = sender as Control;
            preloc = e.Location;
            Cursor = Cursors.Default;
        }

        private void strzalkaMax_MouseUp(object sender, MouseEventArgs e)
        {
            actcontrol = null;
            Cursor = Cursors.Default;
        }

        private void strzalkaMax_MouseMove(object sender, MouseEventArgs e)
        {
            if (actcontrol == null || actcontrol != sender)
                return;
            var location = actcontrol.Location;
            location.Offset(e.Location.X - preloc.X, e.Location.Y - preloc.Y);
            location.Y = Y;

            if (location.X > min && location.X < max && location.X > strzalkaMin.Location.X)
            {
                actcontrol.Location = location;
                MaximumTextBox.Text = (location.X - min - 1).ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Tools.DisplayHistogram(obiektObrazek.PunktyR, chart1);
                    break;
                case 1:
                    Tools.DisplayHistogram(obiektObrazek.PunktyG, chart1);
                    break;
                case 2:
                    Tools.DisplayHistogram(obiektObrazek.PunktyB, chart1);
                    break;
            }
            PodgladUpdate();
        }

        private void SyncCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PodgladUpdate();
        }

        private void PodgladUpdate()
        {
            int[] lut = Tools.GetLUTRozciaganie(int.Parse(MinimumTextBox.Text), int.Parse(MaximumTextBox.Text));
            char warstwa = GetWarstwa();

            pictureBox2.Image = Tools.RozciagnijHistogram(lut, podglad, warstwa);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            _warstwa = GetWarstwa();
        }
    }


    public class FormResult
    {
        public char Warstwa { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public DialogResult Result { get; set; }
    }

}

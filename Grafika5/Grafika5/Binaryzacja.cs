using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biometria_1
{
    public partial class Binaryzacja : Form
    {
        private Control actControl;
        private Point preloc;
        private int Y;
        private int min;
        private int max;
        private static Bitmap podglad;

        public Binaryzacja()
        {
            InitializeComponent();
            Y = strzalkaMin.Location.Y;
            min = strzalkaMin.Location.X;
            max = min + 257;
            PreviewBitmap();
            TresholdTextBox.Text = "128";
            TresholdTextBox.KeyPress += new KeyPressEventHandler(this.OnKeyPress);
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

        public static BinaryzacjaResult ExecuteTreshold(Bitmap obrazek)
        {
            podglad = obrazek;
            using (var form = new Binaryzacja())
            {
                form.OkButton.DialogResult = DialogResult.OK;
                form.CancelButton.DialogResult = DialogResult.Cancel;
                var result = new BinaryzacjaResult();
                result.Result = form.ShowDialog();
                if (result.Result == DialogResult.OK)
                {
                    result.RecznyProg = Int32.Parse(form.TresholdTextBox.Text);
                    
                }  
                return result;
            }
        }

        public static BinaryzacjaResult ExecutePercentage(Bitmap obrazek)
        {
            podglad = obrazek;
            using (var form = new Binaryzacja())
            {
                form.OkButton.DialogResult = DialogResult.OK;
                form.CancelButton.DialogResult = DialogResult.Cancel;
                var result = new BinaryzacjaResult();
                result.Result = form.ShowDialog();
                if (result.Result == DialogResult.OK)
                {
                    result.RecznyProg = Int32.Parse(form.TresholdTextBox.Text);

                }
                return result;
            }
        }

        private void strzalkaMin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                actControl = sender as Control;
                preloc = e.Location;
                Cursor = Cursors.Default;
            }
        }

        private void strzalkaMin_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                actControl = null;
                Cursor = Cursors.Default;
            }
        }

        private void strzalkaMin_MouseMove(object sender, MouseEventArgs e)
        {
            if (actControl == null || actControl != sender)
                return;

            var location = actControl.Location;
            location.Offset(e.Location.X - preloc.X, e.Location.Y - preloc.Y);
            location.Y = Y;
            if (location.X > min && location.X < max)
            {
                actControl.Location = location;
                TresholdTextBox.Text = (location.X - min -1).ToString();
            }
        }

        private void TresholdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(TresholdTextBox.Text) > 255)
            {
                TresholdTextBox.Text = "255";
            }
            strzalkaMin.Location = new Point(int.Parse(TresholdTextBox.Text) + min, Y);
            DrawGradient();
            pictureBox2.Image = Tools.BinaryzacjaReczna(podglad, int.Parse(TresholdTextBox.Text));
        }

        private void PreviewBitmap()
        {
            int x = (podglad.Width / 2) - (pictureBox2.Width / 2);
            int y = (podglad.Height / 2) - (pictureBox2.Height / 2);
            Point start = new Point(x, y);
            Rectangle section = new Rectangle(start, new Size(pictureBox2.Width, pictureBox2.Height));
            Bitmap tmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = Graphics.FromImage(tmp);
            g.DrawImage(podglad, 0, 0, section, GraphicsUnit.Pixel);
            podglad = tmp;
            pictureBox2.Image = tmp;
        }

        private void DrawGradient()
        {
            Bitmap gradient = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(gradient);
            Brush czarny = new SolidBrush(Color.Black);
            graphics.FillRectangle(czarny,
                new Rectangle(new Point(0, 0),
                    new Size(strzalkaMin.Location.X - min -1, pictureBox1.Height)));
            pictureBox1.Image = gradient;
        }
    
    }

    public class BinaryzacjaResult
    {
        public DialogResult Result { get; set; }
        public int RecznyProg { get; set; }
    }
}

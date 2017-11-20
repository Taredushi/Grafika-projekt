using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biometria_1
{
    public partial class PikselForm : Form
    {
        private int _colorR;
        private int _colorG;
        private int _colorB;
        private int _colorA;
        private bool _enable;

        public event PixelEventHandler PixelValueChanged;

        public delegate void PixelEventHandler(PikselForm f, PixelEventArgs e);

        public PikselForm()
        {
            InitializeComponent();
            _colorR = 0;
            _colorG = 0;
            _colorB = 0;
            _enable = false;
        }


        public PikselForm(int a, int r, int g, int b, bool panel)
        {
            InitializeComponent();
            _colorA = a;
            _colorR = r;
            _colorG = g;
            _colorB = b;
            _enable = panel;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = _colorR.ToString();
            textBox2.Text = _colorG.ToString();
            textBox3.Text = _colorB.ToString();
            panel1.Enabled = _enable;
        }
        private void ZmienWartosc_Piksela()
        {
            if (PixelValueChanged != null)
            {
                PixelEventArgs nowyEvent = new PixelEventArgs();
                nowyEvent.A = _colorA;
                nowyEvent.R = _colorR;
                nowyEvent.G = _colorG;
                nowyEvent.B = _colorB;
                PixelValueChanged(this, nowyEvent);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _colorR = int.Parse(textBox1.Text);
            _colorG = int.Parse(textBox2.Text);
            _colorB = int.Parse(textBox3.Text);

            ZmienWartosc_Piksela();
        }

    }

    public class PixelEventArgs: EventArgs
    {
        public int A { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
    }
}

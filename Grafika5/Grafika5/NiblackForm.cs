using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biometria_1
{
    public partial class NiblackForm : Form
    {
        private static bool nieparzysta = false;
        private static double parametr = 0;
        public NiblackForm()
        {
            InitializeComponent();
            parametrTextBox.KeyPress += new KeyPressEventHandler(OnKeyPress_double);
            szerokoscTextBox.KeyPress += new KeyPressEventHandler(OnKeyPress);
        }

        public void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                //OK
            }
            else if (e.KeyChar == '\b')
            {
                //backspace ok
            }
            else
            {
                e.Handled = true;
            }
        }
        public void OnKeyPress_double(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                //OK
            }
            else if (e.KeyChar == '\b')
            {
                //backspace ok
            }
            else if (e.KeyChar == '-' && parametrTextBox.Text == "")
            {
                // OK
            }
            else if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                // OK
            }
            else
            {
                e.Handled = true;
            }
        }

        private void parametrTextBox_Sprawdz()
        {
            if (parametrTextBox.Text.StartsWith(",") || parametrTextBox.Text.StartsWith("."))
            {
                string tmp = "0" + parametrTextBox.Text;
                tmp = tmp.Replace(',', '.');
                parametr = double.Parse(tmp, NumberStyles.Number, CultureInfo.InvariantCulture);
            }
        }

        public static NiblackResult NiblackExecute()
        {
            var result = new NiblackResult();
            while (true)
            {
                using (var form = new NiblackForm())
                {
                    form.OkButton.DialogResult = DialogResult.OK;
                    form.AnulujButton.DialogResult = DialogResult.Cancel;
                    result.Result = form.ShowDialog();
                    if (result.Result == DialogResult.OK)
                    {
                        result.Wymiary = int.Parse(form.szerokoscTextBox.Text);
                        result.Parametr = parametr;

                        if (nieparzysta)
                        {
                            return result;
                        }
                        else
                        {
                            MessageBox.Show(@"Wartość okna musi być nieparzysta!", "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                        }
                    }
                    if (result.Result == DialogResult.Cancel)
                    {
                        return result;
                    }

                }
                
            }
            
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            int tmp = int.Parse(szerokoscTextBox.Text)%2;
            if (tmp > 0)
            {
                nieparzysta = true;
            }
            else
            {
                nieparzysta = false;
            }
            parametrTextBox_Sprawdz();
        }

    }

    public class NiblackResult
    {
        public int Wymiary { get; set; }
        public double Parametr { get; set; }
        public DialogResult Result { get; set; }

    }
}

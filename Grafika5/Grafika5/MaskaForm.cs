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
    public partial class MaskaForm : Form
    {
        public MaskaForm()
        {
            InitializeComponent();
            InitKeyEvent();
        }

        private void InitKeyEvent()
        {
            textBox0.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox1.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox3.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox4.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox5.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox6.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox7.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox8.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox9.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox10.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox11.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox12.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox13.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox14.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox15.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox16.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox17.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox18.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox19.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox20.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox21.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox22.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox23.KeyPress += new KeyPressEventHandler(OnKeyPress);
            textBox24.KeyPress += new KeyPressEventHandler(OnKeyPress);
        }

        public static MaskResult MaskForm_Execute()
        {
            var result = new MaskResult();
            
            using (MaskaForm form = new MaskaForm())
            {
                form.okButton.DialogResult = DialogResult.OK;
                form.cancelButton.DialogResult = DialogResult.Cancel;
                form.smallRadio.Checked = true;
                while (true)
                {
                    result.Result = form.ShowDialog();
                    if (result.Result == DialogResult.OK)
                    {
                        if (!CheckText_Error(form))
                        {
                            var cnt = GetAll(form, typeof(TextBox));
                            int z = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    string pole = "textBox" + z;

                                    foreach (var arg in cnt)
                                    {
                                        if (arg.Name == pole)
                                        {
                                            result.MaskaTable[i, j] = int.Parse(arg.Text);
                                            z++;
                                            break;

                                        }
                                    }

                                }
                            }
                            result.Size = form.smallRadio.Checked ? 3 : 5;
                            return result;
                        }
                        else
                        {
                            MessageBox.Show("Błędna wartość pola, znak \"-\" powinien znajdować się na początku!", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                    if (result.Result == DialogResult.Cancel)
                    {
                        return result;
                    }
                }
            }
        }

        private void smallRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (smallRadio.Checked)
            {
                panel1.Visible = false;
                panel4.Visible = false;
                this.Size = new Size(205, 256);
                
            }
            else
            {
                panel1.Visible = true;
                panel4.Visible = true;
                this.Size = new Size(330, 256);
            }
        }
        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
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
            else if (e.KeyChar == '-')
            {
                // ok
            }
            else
            {
                e.Handled = true;
            }
        }

        private static bool CheckText_Error(MaskaForm form)
        {
            var cnt = GetAll(form, typeof(TextBox));
            foreach (var arg in cnt)
            {
                if (arg.Text.LastIndexOf("-") > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class MaskResult
    {
        public DialogResult Result;
        public int[,] MaskaTable = new int[5,5];
        public int Size { get; set; }
    }
}

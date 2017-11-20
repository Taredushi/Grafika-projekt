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
    public partial class ValueForm : Form
    {
        public ValueForm()
        {
            InitializeComponent();
        }

        public static BinaryzacjaResult ExecutePercent()
        {
            using (var form = new ValueForm())
            {
                form.OkButton.DialogResult = DialogResult.OK;
                form.CancelButton.DialogResult = DialogResult.Cancel;
                var result = new BinaryzacjaResult();
                result.Result = form.ShowDialog();
                if (result.Result == DialogResult.OK)
                {
                    result.RecznyProg = Int32.Parse(form.textBox1.Text);

                }
                return result;
            }
        }
    }
}

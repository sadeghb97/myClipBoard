using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myClipBoard
{

    public partial class settingsForm : Form
    {
        string recpValue;

        protected Form1 frmMain;
        public settingsForm(Form1 frm)
        {
            frmMain = frm;
            InitializeComponent();
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            updnOpacity.ContextMenu = new ContextMenu();
            updnOpacity.Value = Convert.ToDecimal(frmMain.Opacity);
            this.ActiveControl = btnApply;
        }

        private void updnOpacity_ValueChanged(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void updnOpacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            recpValue = updnOpacity.Text;
        }

        private void updnOpacity_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = updnOpacity.Text;
            decimal txtInt = Convert.ToDecimal(txt);
            if (txtInt>1 || txtInt < 0)
            {
                updnOpacity.Text = recpValue;
            }
        }

        private void settingsForm_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            frmMain.Opacity = Convert.ToDouble(updnOpacity.Value);
            this.Close();
        }

        private void updnOpacity_Click(object sender, EventArgs e)
        {
            updnOpacity.Select(0, updnOpacity.Text.Length);
        }
    }
}

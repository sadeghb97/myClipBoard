using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace myClipBoard
{
    public partial class Form1 : Form
    {
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        //const int LinesCapacity = 7;
        const int MaxCapacity=50;
        string IgnoreString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Text = this.Text;
            timer1.Start();
            if(myClipBoard.Properties.Settings.Default.formx==0)
                this.DesktopLocation = new Point(Screen.PrimaryScreen.Bounds.Width-500, 80);
            else
                this.DesktopLocation = new Point(myClipBoard.Properties.Settings.Default.formx, myClipBoard.Properties.Settings.Default.formy);
            this.TopMost = true;
            Opacity = 0;

            ContextMenu cm = new ContextMenu();
            MenuItem aboutItem = new MenuItem("About SBPro Clipboard",aboutItem_Click);
            MenuItem restoreItem = new MenuItem("Restore",restoreItem_Click);
            MenuItem settingsItem = new MenuItem("Settings", settingsItem_Click);
            MenuItem exitItem = new MenuItem("Exit",notifyExitItem_Click);

            cm.MenuItems.Add(aboutItem);
            cm.MenuItems.Add("-");
            cm.MenuItems.Add(restoreItem);
            cm.MenuItems.Add(settingsItem);
            cm.MenuItems.Add("-");
            cm.MenuItems.Add(exitItem);
            notifyIcon1.ContextMenu = cm;

            ContextMenu listCm = new ContextMenu();
            MenuItem sendFrontListCm = new MenuItem("Send To Front",sendFrontListCm_Click);
            MenuItem remListCm = new MenuItem("Remove",remListCm_Click);

            listCm.MenuItems.Add(sendFrontListCm);
            listCm.MenuItems.Add(remListCm);
            listBox1.ContextMenu = listCm;

            if (rkApp.GetValue("SBPro Clipboard") == null)
            {
                rkApp.SetValue("SBPro Clipboard", Application.ExecutablePath);
            }
        }

        private void notifyExitItem_Click(Object sender, EventArgs e)
        {
            myClipBoard.Properties.Settings.Default.formx = this.Location.X;
            myClipBoard.Properties.Settings.Default.formy = this.Location.Y;
            myClipBoard.Properties.Settings.Default.formOpacity = this.Opacity;
            myClipBoard.Properties.Settings.Default.Save();

            notifyIcon1.Visible = false;
            System.Environment.Exit(1);
        }

        private void aboutItem_Click(Object sender, EventArgs e)
        {
            Form2 frmAbout = new Form2();
            frmAbout.StartPosition = FormStartPosition.Manual;
            frmAbout.Left = this.Location.X + (this.Size.Width-frmAbout.Size.Width)/2;
            frmAbout.Top = this.Location.Y + (this.Size.Height - frmAbout.Size.Height) / 2;
            frmAbout.ShowDialog(this);
        }

        private void restoreItem_Click(Object sender, EventArgs e)
        {
            notifyIcon1_MouseClick(null, new MouseEventArgs(MouseButtons.Left,1,1,1,1));
        }

        private void settingsItem_Click(Object sender, EventArgs e)
        {
            settingsForm frmSettings = new settingsForm(this);
            frmSettings.StartPosition = FormStartPosition.Manual;
            frmSettings.Left = this.Location.X + (this.Size.Width - frmSettings.Size.Width) / 2;
            frmSettings.Top = this.Location.Y + (this.Size.Height - frmSettings.Size.Height) / 2;
            frmSettings.ShowDialog(this);
        }

        private void sendFrontListCm_Click(Object sender, EventArgs e)
        {
            listBox1_DoubleClick(null, null);
        }

        private void remListCm_Click(Object sender, EventArgs e)
        {
            int sel = listBox1.SelectedIndex;
            if (sel >= 0)
            {
                listBox1.Items.Remove(listBox1.Items[sel]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Clipboard.ContainsText())
            {
                string cbText=Clipboard.GetText();
                int i;
                if (cbText != IgnoreString && (listBox1.Items.Count == 0 || cbText != listBox1.Items[listBox1.Items.Count - 1].ToString()))
                {
                    for (i = 0; listBox1.Items.Count > i && listBox1.Items[i].ToString() != cbText; i++) ;
                    if (i < listBox1.Items.Count)
                    {
                        listBox1.Items.Remove(listBox1.Items[i]);
                        listBox1.Items.Add(cbText);
                    }
                    else if (i < MaxCapacity)
                        listBox1.Items.Add(cbText);
                    else
                    {
                        for (int j = 0; MaxCapacity - 1 > j; j++)
                            listBox1.Items[j] = listBox1.Items[j + 1].ToString();
                        listBox1.Items[MaxCapacity - 1] = cbText;
                    }
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                textBox1.Text = cbText;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                Clipboard.SetText(listBox1.Items[listBox1.SelectedIndex].ToString());
            IgnoreString = Clipboard.GetText();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
            Opacity = myClipBoard.Properties.Settings.Default.formOpacity;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int sel = listBox1.SelectedIndex;
            if (sel + 1 != listBox1.Items.Count)
            {
                String tempStr = listBox1.Items[sel].ToString();
                listBox1.Items.Remove(listBox1.Items[sel]);
                listBox1.Items.Add(tempStr);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }
    }
}

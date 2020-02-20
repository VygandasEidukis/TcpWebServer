using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using WebService.Server.Models;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebService.UI
{
    public partial class Form1 : Form
    {
        private const int MAX_PORT_NUMBER = 65535;
        bool _serverRunning = false;
        Server.Models.Server server;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ServerSwitch_Click(object sender, EventArgs e)
        {
            if (!_serverRunning)
            {
                server = new Server.Models.Server(Int32.Parse(tb_Port.Text), tb_RootPath.Text);
                server.Start();
                _serverRunning = true;

                btn_ServerSwitch.Text = "Stop Server";

                SwitchUIEnable();
            }
            else
            {
                server.Dispose();
                server = null;
                _serverRunning = false;

                SwitchUIEnable();
            }
            SwitchUIEnable();
        }

        private void SwitchUIEnable()
        {
            tb_Port.Enabled = !_serverRunning;
            tb_RootPath.Enabled = !_serverRunning;

            btn_SelectRootPath.Enabled = !_serverRunning;
        }

        private void btn_SelectRootPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                tb_RootPath.Text = folderBrowser.SelectedPath;
            }
        }

        private void tb_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (Int32.Parse(tb_Port.Text) > MAX_PORT_NUMBER)
                tb_Port.Text = MAX_PORT_NUMBER.ToString();
        }
    }
}

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
using System.IO;

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
                ServerStarter();
            }
            else
            {
                server.Stop();
                _serverRunning = false;
            }
            SwitchUIEnable();
        }

        private async void ServerStarter()
        {
            Task serverTask = new Task(() => StartServer());
            serverTask.Start();
            await serverTask.ContinueWith((x) => SwitchUIEnable());
        }

        private void StartServer()
        {
            try
            {
                server = new Server.Models.Server(Int32.Parse(tb_Port.Text), tb_RootPath.Text);
                _serverRunning = true;
                SwitchUIEnable();
                server.Start();
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Bad root path");
                _serverRunning = false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _serverRunning = false;
            }
        }

        private void SwitchUIEnable()
        {
            tb_Port.Invoke((MethodInvoker)delegate
            {
                tb_Port.Enabled = !_serverRunning;
            });

            tb_RootPath.Invoke((MethodInvoker)delegate
            {
                tb_RootPath.Enabled = !_serverRunning;
            });

            btn_SelectRootPath.Invoke((MethodInvoker)delegate
            {
                btn_SelectRootPath.Enabled = !_serverRunning;
            });

            btn_ServerSwitch.Invoke((MethodInvoker)delegate
            {
                if (_serverRunning)
                    btn_ServerSwitch.Text = "Stop Server";
                if (!_serverRunning)
                    btn_ServerSwitch.Text = "Start Server";
            });
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

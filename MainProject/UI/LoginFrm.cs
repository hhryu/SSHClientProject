﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject.UI
{
    public partial class LoginFrm : Form
    {
        public event EventHandler<ConnectionArgs> SSHConnected;

        public bool Remembered { get; set; }
        public string Password { get; set; }

        public LoginFrm(bool rmb, string ip = null, string userName = null, string pw = null)
        {
            InitializeComponent();
            InitCtrls();

            if(rmb && ip != null && userName != null && pw != null)
            {
                this.txt_ip.Text = ip;
                this.txt_userName.Text = userName;
                this.txt_pw.Text = pw;
            }
        }

        private void InitCtrls()
        {
            this.pn_top.MouseDown += MoveFrm;
            this.txt_ip.KeyDown += btn_conn_Click;
            this.txt_port.KeyDown += btn_conn_Click;
            this.txt_userName.KeyDown += btn_conn_Click;
            this.txt_pw.KeyDown += btn_conn_Click;
            //this.chk_remember.CheckedChanged += (s, e) =>
            //{
            //    if (s is CheckBox chk)
            //        Remembered = chk.Checked;
            //};
        }


        private void MoveFrm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UIHelper.ReleaseCapture();
                UIHelper.SendMessage(Handle, UIHelper.WM_NCLBUTTONDOWN, UIHelper.HT_CAPTION, 0);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e) => this.Close();

        private void btn_conn_Click(object sender, EventArgs e)
        {
            if (e is KeyEventArgs kea)
            {
                if (kea.KeyCode != Keys.Enter)
                    return;
            }

            if (this.txt_ip.Text == string.Empty || txt_port.Text == string.Empty ||
                this.txt_userName.Text == string.Empty || txt_pw.Text == string.Empty)
            {
                return;
            }

            int port = -1;

            try
            {
                port = Int32.Parse(this.txt_port.Text);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"btn_conn_Click(): {ex.Message}");
                return;
            }

            var ip = this.txt_ip.Text;
            var userName = this.txt_userName.Text;
            var pw = this.txt_pw.Text;

            var cl = SSH.SshHelper.ConnectSSH(ip, port, userName, pw);

            if (!cl.IsConnected)
                return;

            Models.Client client = new Models.Client()
            {
                SshClient = cl,
                SftpClient = SSH.SshHelper.ConnectSFTP(ip, port, userName, pw),
            };

            this.Remembered = this.chk_remember.Checked;
            this.Password = this.txt_pw.Text;

            var args = new ConnectionArgs(client);
            SSHConnected?.Invoke(this, args);
            this.Close();
        }
    }

    public class ConnectionArgs : EventArgs
    {
        public ConnectionArgs(Models.Client client)
        {
            this.Client = client;
        }
        public Models.Client Client { get; }
    }
}

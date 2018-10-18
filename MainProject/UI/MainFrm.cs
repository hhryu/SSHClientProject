using MainProject.Controls;
using MainProject.Models;
using MainProject.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MainFrm : Form
    {
        List<Client> clients;

        Panel pn_btns;
        MultiPagePanel pn_consoles;
        BatchPage pn_batch;

        //int count = 0;
        string ip;
        string userName;
        string pw;

        public MainFrm()
        {
            InitializeComponent();
            this.pn_left.MouseDown += MoveFrm;
            this.pn_top.MouseDown += MoveFrm;
            this.pn_main.MouseDown += MoveFrm;
        }

        private void MoveFrm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UIHelper.ReleaseCapture();
                UIHelper.SendMessage(Handle, UIHelper.WM_NCLBUTTONDOWN, UIHelper.HT_CAPTION, 0);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_connection_Click(object sender, EventArgs e)
        {
            LoginFrm frm;
            if(this.ip == null || this.userName == null || this.pw == null)
                frm = new LoginFrm(false);
            else
                frm = new LoginFrm(true, this.ip, this.userName, this.pw);

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.SSHConnected += AddUser;
            frm.ShowDialog();
        }

        private void OpenPage(PageType type)
        {
            if (pn_main.Controls.Count < 1)
                return;

            switch (type)
            {
                case PageType.SSH:
                    foreach (var item in this.pn_main.Controls)
                    {
                        if (item is MultiPagePanel ctrl)
                        {
                            if (ctrl.Name == "pn_ssh")
                            {
                                ctrl.BringToFront();
                                ChangeMenuBtn(this.btn_ssh);
                                break;
                            }
                        }
                    }
                    break;

                //case PageType.SFTP:
                //    foreach (var item in this.pn_main.Controls)
                //    {
                //        if(item is MultiPagePanel ctrl)
                //        {
                //            if (ctrl.Name == "pn_sftp")
                //            {
                //                ctrl.BringToFront();
                //                ChangeMenuBtn(this.btn_sftp);
                //                break;
                //            }
                //        }
                //    }
                //    break;

                case PageType.Batch:
                    if (this.pn_batch == null)
                    {
                        this.pn_batch = new BatchPage(clients)
                        {
                            Name = "pn_batch",
                        };
                        this.pn_main.AddPage(this.pn_batch);
                        ChangeMenuBtn(this.btn_batch);
                    }
                    else
                    {
                        this.pn_batch.BringToFront();
                        ChangeMenuBtn(this.btn_batch);
                    }
                    break;

                default:
                    break;
            }
        }

        private void ChangeMenuBtn(Button btn)
        {
            foreach (var ctrl in this.pn_left.Controls)
            {
                if (ctrl is Button item)
                {
                    if (item == btn)
                        item.BackColor = Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
                    else
                        item.BackColor = Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
                }
            }
        }

        private void btn_ssh_Click(object sender, EventArgs e)
        {
            OpenPage(PageType.SSH);
        }

        //private void btn_sftp_Click(object sender, EventArgs e)
        //{
        //    OpenPage(PageType.SFTP);
        //}

        private void btn_batch_Click(object sender, EventArgs e)
        {
            if (clients == null)
                return;

            this.OpenPage(PageType.Batch);
        }

        private void AddSshUser(Client client)
        {
            MultiPagePanel userPanel = null;

            foreach (var item in this.pn_main.Controls)
            {
                if (item is MultiPagePanel ctrl)
                {
                    if (ctrl.Name == "pn_ssh")
                        userPanel = ctrl;
                }
            }

            if (userPanel == null)
                userPanel = AddSshUserPage();

            foreach (var item in userPanel.Controls)
            {
                if (item is Panel ctrl)
                {
                    if (ctrl.Name == "pn_btns")
                    {
                        client.TabHeader = new TabButton()
                        {
                            //Name = $"tab_{count}",
                            FlatStyle = FlatStyle.Flat,
                            Size = new Size(100, ctrl.Height),
                            BackColor = Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(38)))), ((int)(((byte)(59))))),
                            Dock = DockStyle.Left,
                            Font = new Font("D2Coding", 8F),
                            ForeColor = Color.White,
                            Text = $"{client.UserName}@{client.IP}",
                        };
                        client.TabHeader.FlatAppearance.BorderColor = Color.White;
                        client.TabHeader.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(132)))), ((int)(((byte)(142)))));
                        client.TabHeader.MouseDown += ChangeTabPage;
                        ctrl.Controls.Add(client.TabHeader);
                    }
                    else if (ctrl.Name == "pn_consoles")
                    {
                        string mark = string.Empty;
                        if (client.UserName == "root")
                            mark = "#";
                        else
                            mark = "$";

                        client.Console = new MyRichTextBox()
                        {
                            //Name = $"console_{count}",
                            Dock = DockStyle.Fill,
                            BackColor = Color.Black,
                            ForeColor = Color.White,
                            Font = new Font("Consolas", 11, FontStyle.Regular),
                            ID = $"[{client.UserName}@dev1 ~]{mark} ",
                            Client = client,
                        };

                        client.Console.KeyPress += ConsoleInputEvent;
                        client.Console.KeyDown += InputCancellation;

                        //NOTE: Restrict movement of cursor.
                        client.Console.SelectionChanged += (s, e1) =>
                        {
                            if (s is MyRichTextBox mrtb)
                                mrtb.SelectionStart = mrtb.TextLength;
                        };
                        client.Console.AppendText(client.Console.ID);
                        client.Console.MinSelection = client.Console.SelectionStart;
                        (ctrl as MultiPagePanel).AddPage(client.Console);
                    }
                }
            }
            this.pn_main.AddPage(userPanel);

            if (clients == null)
                clients = new List<Client>();

            client.ID = Guid.NewGuid().ToString();
            clients.Add(client);

            if (this.pn_batch != null)
                this.pn_batch.AddItem(clients);

            ChangeTabHeaderColor(client.TabHeader);
            //count++;
        }

        private void InputCancellation(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (this.pn_batch != null)
                {
                    var client = (sender as MyRichTextBox).Client;
                    this.pn_batch.CancelTask(client.ID);

                    if (sender is MyRichTextBox console)
                    {
                        console.AppendText("^C\n");
                        console.AppendText(console.ID);
                    }
                }
            }
        }

        private void ChangeTabHeaderColor(TabButton selectedBtn)
        {
            if (selectedBtn.Selected)
                return;

            Color originalBackColor = Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            Color selectedBackColor = Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));

            foreach (TabButton btn in this.pn_btns.Controls)
            {
                if (btn == selectedBtn)
                {
                    btn.BackColor = selectedBackColor;
                    btn.Selected = true;
                }
                else
                {
                    btn.BackColor = originalBackColor;
                    btn.Selected = false;
                }
            }
        }

        private void ChangeTabPage(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Middle)
                return;

            List<Client> removed = null;

            foreach (var client in clients)
            {
                if (client.TabHeader == sender)
                {
                    int pageIndex = pn_consoles.Controls.IndexOf(client.Console);

                    if (e.Button == MouseButtons.Left)
                    {
                        pn_consoles.CurrentPageIndex = pageIndex;
                        ChangeTabHeaderColor(client.TabHeader);
                    }
                    else if (e.Button == MouseButtons.Middle)
                    {
                        pn_consoles.Controls.RemoveAt(pageIndex);
                        pn_btns.Controls.Remove(client.TabHeader);

                        if (removed == null)
                            removed = new List<Client>();

                        removed.Add(client);

                        if (pn_btns.Controls.Count > 0 && client.TabHeader.Selected)
                        {
                            var selectedBtn = pn_btns.Controls[pn_btns.Controls.Count - 1] as TabButton;
                            ChangeTabHeaderColor(selectedBtn);

                            foreach (var cl in clients)
                            {
                                if (cl.TabHeader == selectedBtn)
                                    cl.Console.BringToFront();
                            }
                        }
                        else if (pn_btns.Controls.Count < 1)
                        {
                            var p = pn_btns.Parent.Parent;
                            p.Controls.Remove(pn_btns.Parent);

                            if (p.Controls.Count < 1)
                                btn_ssh.BackColor = Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
                        }
                    }
                }
            }

            if (removed != null)
            {
                foreach (var item in removed)
                {
                    this.clients.Remove(item);
                    //this.RefreshClientsInBatchPage(item);
                    this.pn_batch.RemoveItem(clients, item);
                }
            }
        }

        private void AddSftpUser()
        {
            MultiPagePanel userPanel = null;

            foreach (var item in this.pn_main.Controls)
            {
                if (item is MultiPagePanel ctrl)
                {
                    if (ctrl.Name == "pn_sftp")
                        userPanel = ctrl;
                }
            }

            if (userPanel == null)
                userPanel = AddSftpUserPage();

            this.pn_main.AddPage(userPanel);
        }

        private void AddUser(object sender, ConnectionArgs e)
        {
            if(sender is LoginFrm frm)
            {
                if (frm.Remembered)
                {
                    this.ip = e.Client.IP;
                    this.userName = e.Client.SshClient.ConnectionInfo.Username;
                    this.pw = frm.Password;
                }
            }

            AddSshUser(e.Client);
            //AddSftpUser(e.Client);
            btn_ssh.PerformClick();
        }

        private void ConsoleInputEvent(object sender, KeyPressEventArgs e)
        {
            if (sender is MyRichTextBox console)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    //줄 바꿈 막기 위함.
                    console.Text = console.Text.Substring(0, console.TextLength - 1);

                    string input = console.Lines[console.Lines.Length - 1];

                    string cmd = input.Substring(console.ID.Length);
                    var (msg, isSuccessful) = SSH.SshHelper.ExcuteCommand(console.Client.SshClient, cmd);

                    console.AppendText($"\n{msg}");
                    console.AppendText(console.ID);
                    console.MinSelection = console.SelectionStart;
                }
                else if (e.KeyChar == (char)Keys.Back)
                {
                    if (console.MinSelection > console.SelectionStart)
                        console.AppendText(" ");
                }
            }
        }

        private MultiPagePanel AddSshUserPage()
        {
            var page = new MultiPagePanel()
            {
                Name = "pn_ssh",
                Size = this.pn_main.Size,
            };

            pn_btns = new Panel()
            {
                Dock = DockStyle.Top,
                Location = new Point(0, 0),
                Name = "pn_btns",
                Size = new Size(781, 40),
                BackColor = Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(38)))), ((int)(((byte)(59))))),
                AutoScroll = true,
            };
            page.AddPage(pn_btns);

            var pn_separator = new Panel()
            {
                BackColor = Color.White,
                Dock = DockStyle.Top,
                Location = new Point(0, 40),
                Name = "pn_separator",
                Size = new Size(781, 3),
            };
            page.AddPage(pn_separator);

            pn_consoles = new MultiPagePanel()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 43),
                Name = "pn_consoles",
                Size = new Size(781, 567)
            };
            page.AddPage(pn_consoles);

            return page;
        }

        private MultiPagePanel AddSftpUserPage()
        {
            var page = new MultiPagePanel()
            {
                Name = "pn_sftp",
                Size = this.pn_main.Size,
                BackColor = Color.Purple
            };
            return page;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ips = new string[] { "192.168.152.233", "192.168.152.234", "192.168.152.235" };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    var ssh = SSH.SshHelper.ConnectSSH(ips[i], 22, "root", "@@fusiondev01");

                    var client = new Client()
                    {
                        SshClient = ssh,
                    };
                    var arg = new ConnectionArgs(client);
                    AddUser(this, arg);
                }
            }
        }
    }

    enum PageType
    {
        SSH,
        SFTP,
        Batch
    }
}

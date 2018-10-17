using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Models;
using System.Threading;
using System.IO;

namespace MainProject.Controls
{
    public partial class BatchPage : UserControl
    {
        DataTable dt;

        List<Client> clients;
        Dictionary<string, CancellationTokenSource> ctsList;

        bool isSingleMode = false;
        bool batchEnabled = false;

        private int successCount;
        private int failureCount;

        private void IncreaseCount(bool isSuccessful)
        {
            string txt = string.Empty;

            var lockObj = new object();
            lock (lockObj)
            {
                if (isSuccessful)
                    this.successCount++;
                else
                    this.failureCount++;


                if (this.successCount + this.failureCount < this.pgBar.Maximum)
                    txt = "진행중";
                else
                    txt = "완료";
            }
            this.UpdatePgbar(txt, isSuccessful);
        }

        string fileName = string.Empty;
        public string FileName
        {
            get => this.fileName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    batchEnabled = false;
                else
                    batchEnabled = true;

                fileName = value;
            }
        }

        public BatchPage(List<Client> cls)
        {
            InitializeComponent();

            this.rb_single.CheckedChanged += ChangeAddingMode;
            this.rb_multiple.CheckedChanged += ChangeAddingMode;

            InitClients(cls);

            this.gv_ips.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gv_ips.ForeColor = System.Drawing.Color.Black;
        }

        private void ChangeAddingMode(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                if (!rb.Checked)
                    return;

                switch (rb.Text)
                {
                    case "Single":
                        this.isSingleMode = true;
                        this.cb_end.Enabled = false;
                        break;

                    case "Multiple":
                        this.isSingleMode = false;
                        this.cb_end.Enabled = true;
                        break;

                    default:
                        break;
                }
            }
        }

        public void InitClients(List<Client> cls)
        {
            var list = cls;

            var firstSortResult = list.OrderBy(i => i.IP);
            var finalSortResult = firstSortResult.OrderBy(i => i.IP.Length);

            this.clients = finalSortResult.ToList();

            this.cb_start.DataSource = new BindingSource { DataSource = clients };
            this.cb_end.DataSource = new BindingSource { DataSource = clients };
            this.cb_end.SelectedIndex = this.cb_end.Items.Count - 1;

            this.cb_start.SelectedValueChanged += InspectRightRange;
            this.cb_end.SelectedValueChanged += InspectRightRange;

            if (this.cb_start.DataSource is BindingSource source)
            {
                if (source.Count < 2)
                    this.rb_single.Checked = true;
            }
        }

        public void AddItem(List<Client> cls)
        {
            this.InitClients(cls);
        }

        public void RemoveItem(List<Client> cls, Client cl)
        {
            this.InitClients(cls);

            DataRow row = null;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.ItemArray[0] == cl)
                    row = dr;
            }

            if (row != null)
                dt.Rows.Remove(row);
        }

        private void InspectRightRange(object sender, EventArgs e)
        {
            if (this.cb_start.SelectedIndex > this.cb_end.SelectedIndex)
            {
                MessageBox.Show("잘못된 범위 설정입니다.");
                this.cb_start.SelectedIndex = 0;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (this.cb_start.SelectedItem == null)
                return;

            if (dt == null)
            {
                dt = new DataTable();

                dt.Columns.Add("IP", typeof(Client));
                gv_ips.DataSource = dt;
                gv_ips.Columns.Add(new DataGridViewButtonColumn()
                {
                    HeaderText = "Delete",
                    FlatStyle = FlatStyle.Flat,
                    Text = "X",
                    UseColumnTextForButtonValue = true,
                });

                this.gv_ips.CellMouseClick += RemoveRow;
            }

            if (isSingleMode)
            {
                bool isNewItem = FilterDuplicatedItem((Client)this.cb_start.SelectedItem);

                if (isNewItem)
                    dt.Rows.Add(this.cb_start.SelectedItem);
            }
            else
            {
                int startIndex = cb_start.SelectedIndex;
                int endIndex = cb_end.SelectedIndex;

                foreach (var cl in this.clients)
                {
                    bool isNewItem = FilterDuplicatedItem(cl);
                    if (!isNewItem)
                        continue;

                    int candidate = this.clients.IndexOf(cl);

                    if (candidate < startIndex || candidate > endIndex)
                        continue;

                    dt.Rows.Add(cl);
                }
            }
        }

        private bool FilterDuplicatedItem(Client selectedItem)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row.ItemArray[0] is Client client)
                {
                    if (selectedItem == client)
                        return false;
                }
            }
            return true;
        }

        private void RemoveRow(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 1 || this.gv_ips.Rows.Count < 2)
                return;

            var result = MessageBox.Show("이 행을 삭제하시겠습니까?", "행 삭제", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                this.gv_ips.Rows.RemoveAt(e.RowIndex);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!batchEnabled || this.gv_ips.Rows.Count < 1)
                return;

            this.pgBar.Value = 0;
            this.lb_pgbar.Text = string.Empty;
            StartBatchJob();
        }

        private void StartBatchJob()
        {
            this.InitPgbar();
            foreach (DataGridViewRow row in this.gv_ips.Rows)
            {
                if (row.Cells[0].Value is Client client)
                {
                    var cts = new CancellationTokenSource();
                    var token = cts.Token;

                    var task = new Task(() =>
                    {
                        using (var sr = new StreamReader(fileName))
                        {
                            while (!sr.EndOfStream)
                            {
                                string cmd = sr.ReadLine();
                                this.WriteString(client, cmd, false);

                                string resultMsg = string.Empty;

                                resultMsg = SSH.SshHelper.ExcuteCommand(client.SshClient, cmd);
                                this.WriteString(client, resultMsg, true);

                                if (token.IsCancellationRequested)
                                {
                                    this.WriteString(client, "^C", true);
                                    this.IncreaseCount(false);
                                    return;
                                }
                            }
                            this.IncreaseCount(true);
                        }
                    }, token);

                    if (ctsList == null)
                        ctsList = new Dictionary<string, CancellationTokenSource>();

                    this.ctsList.Add(client.ID, cts);
                    task.Start();
                }
            }
        }


        public void CancelTask(string id)
        {
            if (ctsList != null)
                ctsList[id].Cancel();
        }

        delegate void PgbarUpdateDelegate(string txt, bool isCanceled);
        private void UpdatePgbar(string txt, bool isSuccessful)
        {
            if (this.pgBar.InvokeRequired)
            {
                var del = new PgbarUpdateDelegate(UpdatePgbar);
                this.Invoke(del, new object[] { txt, isSuccessful });
            }
            else
            {
                if (isSuccessful)
                    this.pgBar.PerformStep();

                int count = this.successCount + this.failureCount;

                if (count < this.pgBar.Maximum)
                    txt = "진행중";
                else
                {
                    txt = "완료";
                    ctsList = null;
                }

                this.lb_pgbar.Text = $"{this.pgBar.Value}/{this.pgBar.Maximum} {txt}";
            }
        }

        private void InitPgbar()
        {
            this.pgBar.Minimum = 0;
            this.pgBar.Maximum = this.gv_ips.Rows.Count - 1;
            this.pgBar.Step = 1;
        }

        delegate void ConsoleUpdateDelegate(Client client, string txt, bool isWritingID);
        private void WriteString(Client client, string txt, bool isWritingID)
        {

            if (client.Console.InvokeRequired)
            {
                var del = new ConsoleUpdateDelegate(WriteString);
                this.Invoke(del, new object[] { client, txt, isWritingID });
            }
            else
            {
                client.Console.AppendText(txt + "\n");

                if (isWritingID)
                    client.Console.AppendText(client.Console.ID);
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    batchEnabled = true;
                }
            }
        }
    }

    class ResultArgs : EventArgs
    {
        public string ResultMsg { get; }
        public Client Client { get; }

        public ResultArgs(Client cl, string msg)
        {
            this.Client = cl;
            this.ResultMsg = msg;
        }
    }
}

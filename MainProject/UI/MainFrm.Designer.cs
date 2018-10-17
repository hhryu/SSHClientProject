using MainProject.UI;

namespace UI
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pn_left = new System.Windows.Forms.Panel();
            this.btn_batch = new System.Windows.Forms.Button();
            this.btn_ssh = new System.Windows.Forms.Button();
            this.btn_connection = new System.Windows.Forms.Button();
            this.multiPagePanel1 = new System.Windows.Forms.Panel();
            this.multiPagePanel2 = new System.Windows.Forms.Panel();
            this.multiPagePanel3 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.pn_top = new System.Windows.Forms.Panel();
            this.pn_main = new MultiPagePanel();
            this.pn_left.SuspendLayout();
            this.pn_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_left
            // 
            this.pn_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.pn_left.Controls.Add(this.btn_batch);
            this.pn_left.Controls.Add(this.btn_ssh);
            this.pn_left.Controls.Add(this.btn_connection);
            this.pn_left.Controls.Add(this.multiPagePanel1);
            this.pn_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_left.Location = new System.Drawing.Point(0, 0);
            this.pn_left.Name = "pn_left";
            this.pn_left.Size = new System.Drawing.Size(160, 626);
            this.pn_left.TabIndex = 0;
            // 
            // btn_batch
            // 
            this.btn_batch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
            this.btn_batch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
            this.btn_batch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
            this.btn_batch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(54)))), ((int)(((byte)(82)))));
            this.btn_batch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_batch.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.btn_batch.ForeColor = System.Drawing.Color.White;
            this.btn_batch.Location = new System.Drawing.Point(0, 214);
            this.btn_batch.Name = "btn_batch";
            this.btn_batch.Size = new System.Drawing.Size(163, 47);
            this.btn_batch.TabIndex = 3;
            this.btn_batch.Text = "Batch";
            this.btn_batch.UseVisualStyleBackColor = false;
            this.btn_batch.Click += new System.EventHandler(this.btn_batch_Click);
            // 
            // btn_ssh
            // 
            this.btn_ssh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
            this.btn_ssh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
            this.btn_ssh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
            this.btn_ssh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(54)))), ((int)(((byte)(82)))));
            this.btn_ssh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ssh.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ssh.ForeColor = System.Drawing.Color.White;
            this.btn_ssh.Location = new System.Drawing.Point(0, 166);
            this.btn_ssh.Name = "btn_ssh";
            this.btn_ssh.Size = new System.Drawing.Size(163, 47);
            this.btn_ssh.TabIndex = 2;
            this.btn_ssh.Text = "Main";
            this.btn_ssh.UseVisualStyleBackColor = false;
            this.btn_ssh.Click += new System.EventHandler(this.btn_ssh_Click);
            // 
            // btn_connection
            // 
            this.btn_connection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
            this.btn_connection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
            this.btn_connection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(143)))));
            this.btn_connection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(54)))), ((int)(((byte)(82)))));
            this.btn_connection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_connection.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.btn_connection.ForeColor = System.Drawing.Color.White;
            this.btn_connection.Location = new System.Drawing.Point(0, 118);
            this.btn_connection.Name = "btn_connection";
            this.btn_connection.Size = new System.Drawing.Size(163, 47);
            this.btn_connection.TabIndex = 1;
            this.btn_connection.Text = "Connect";
            this.btn_connection.UseVisualStyleBackColor = false;
            this.btn_connection.Click += new System.EventHandler(this.btn_connection_Click);
            // 
            // multiPagePanel1
            // 
            this.multiPagePanel1.BackColor = System.Drawing.Color.White;
            this.multiPagePanel1.Location = new System.Drawing.Point(0, 34);
            this.multiPagePanel1.Name = "multiPagePanel1";
            this.multiPagePanel1.Size = new System.Drawing.Size(160, 3);
            this.multiPagePanel1.TabIndex = 0;
            // 
            // multiPagePanel2
            // 
            this.multiPagePanel2.BackColor = System.Drawing.Color.White;
            this.multiPagePanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.multiPagePanel2.Location = new System.Drawing.Point(160, 0);
            this.multiPagePanel2.Name = "multiPagePanel2";
            this.multiPagePanel2.Size = new System.Drawing.Size(3, 626);
            this.multiPagePanel2.TabIndex = 1;
            // 
            // multiPagePanel3
            // 
            this.multiPagePanel3.BackColor = System.Drawing.Color.White;
            this.multiPagePanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.multiPagePanel3.Location = new System.Drawing.Point(163, 34);
            this.multiPagePanel3.Name = "multiPagePanel3";
            this.multiPagePanel3.Size = new System.Drawing.Size(781, 3);
            this.multiPagePanel3.TabIndex = 2;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.btn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(223)))), ((int)(((byte)(241)))));
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(143)))), ((int)(((byte)(191)))));
            this.btn_exit.Location = new System.Drawing.Point(708, 0);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(73, 34);
            this.btn_exit.TabIndex = 14;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.pn_top.Controls.Add(this.btn_exit);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(163, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(781, 34);
            this.pn_top.TabIndex = 15;
            // 
            // pn_main
            // 
            this.pn_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(223)))), ((int)(((byte)(241)))));
            this.pn_main.CurrentPageIndex = 0;
            this.pn_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_main.Location = new System.Drawing.Point(163, 37);
            this.pn_main.Name = "pn_main";
            this.pn_main.Size = new System.Drawing.Size(781, 589);
            this.pn_main.TabIndex = 16;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(944, 626);
            this.Controls.Add(this.pn_main);
            this.Controls.Add(this.multiPagePanel3);
            this.Controls.Add(this.pn_top);
            this.Controls.Add(this.multiPagePanel2);
            this.Controls.Add(this.pn_left);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pn_left.ResumeLayout(false);
            this.pn_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel pn_left;
        private System.Windows.Forms.Panel multiPagePanel1;
        private System.Windows.Forms.Panel multiPagePanel2;
        private System.Windows.Forms.Panel multiPagePanel3;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_connection;
        private System.Windows.Forms.Button btn_ssh;
        private System.Windows.Forms.Panel pn_top;
        private MultiPagePanel pn_main;
        private System.Windows.Forms.Button btn_batch;
    }
}


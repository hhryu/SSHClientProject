namespace MainProject.UI
{
    partial class LoginFrm
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
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_pw = new UI.UnderLineTextBox();
            this.txt_userName = new UI.UnderLineTextBox();
            this.txt_port = new UI.UnderLineTextBox();
            this.txt_ip = new UI.UnderLineTextBox();
            this.chk_remember = new System.Windows.Forms.CheckBox();
            this.btn_conn = new System.Windows.Forms.Button();
            this.pn_top.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(143)))), ((int)(((byte)(191)))));
            this.pn_top.Controls.Add(this.btn_exit);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(456, 30);
            this.pn_top.TabIndex = 3;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(143)))), ((int)(((byte)(191)))));
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(143)))), ((int)(((byte)(191)))));
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(383, 0);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(73, 30);
            this.btn_exit.TabIndex = 15;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txt_pw);
            this.panel1.Controls.Add(this.txt_userName);
            this.panel1.Controls.Add(this.txt_port);
            this.panel1.Controls.Add(this.txt_ip);
            this.panel1.Controls.Add(this.chk_remember);
            this.panel1.Controls.Add(this.btn_conn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 315);
            this.panel1.TabIndex = 4;
            // 
            // txt_pw
            // 
            this.txt_pw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_pw.Font = new System.Drawing.Font("Georgia", 10F);
            this.txt_pw.ForeColor = System.Drawing.Color.Black;
            this.txt_pw.Location = new System.Drawing.Point(45, 172);
            this.txt_pw.Name = "txt_pw";
            this.txt_pw.Size = new System.Drawing.Size(367, 27);
            this.txt_pw.TabIndex = 14;
            this.txt_pw.UseSystemPasswordChar = true;
            this.txt_pw.Watermark = "Password";
            // 
            // txt_userName
            // 
            this.txt_userName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_userName.Font = new System.Drawing.Font("Georgia", 10F);
            this.txt_userName.ForeColor = System.Drawing.Color.Black;
            this.txt_userName.Location = new System.Drawing.Point(45, 109);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(367, 27);
            this.txt_userName.TabIndex = 13;
            this.txt_userName.Watermark = "User Name";
            // 
            // txt_port
            // 
            this.txt_port.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_port.Font = new System.Drawing.Font("Georgia", 10F);
            this.txt_port.ForeColor = System.Drawing.Color.Black;
            this.txt_port.Location = new System.Drawing.Point(332, 46);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(80, 27);
            this.txt_port.TabIndex = 12;
            this.txt_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_port.Watermark = "Port";
            // 
            // txt_ip
            // 
            this.txt_ip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ip.Font = new System.Drawing.Font("Georgia", 10F);
            this.txt_ip.ForeColor = System.Drawing.Color.Black;
            this.txt_ip.Location = new System.Drawing.Point(45, 46);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(270, 27);
            this.txt_ip.TabIndex = 11;
            this.txt_ip.Watermark = "IP Address";
            // 
            // chk_remember
            // 
            this.chk_remember.AutoSize = true;
            this.chk_remember.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.chk_remember.Font = new System.Drawing.Font("Georgia", 10F);
            this.chk_remember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.chk_remember.Location = new System.Drawing.Point(45, 241);
            this.chk_remember.Name = "chk_remember";
            this.chk_remember.Size = new System.Drawing.Size(125, 21);
            this.chk_remember.TabIndex = 9;
            this.chk_remember.Text = "Remember me?";
            this.chk_remember.UseVisualStyleBackColor = true;
            // 
            // btn_conn
            // 
            this.btn_conn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(80)))), ((int)(((byte)(125)))));
            this.btn_conn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(80)))), ((int)(((byte)(125)))));
            this.btn_conn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_conn.Font = new System.Drawing.Font("Georgia", 10F);
            this.btn_conn.ForeColor = System.Drawing.Color.White;
            this.btn_conn.Location = new System.Drawing.Point(322, 235);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(90, 33);
            this.btn_conn.TabIndex = 10;
            this.btn_conn.Text = "Connect";
            this.btn_conn.UseVisualStyleBackColor = false;
            this.btn_conn.Click += new System.EventHandler(this.btn_conn_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 345);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginFrm";
            this.Text = "Form1";
            this.pn_top.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel panel1;
        private UnderLineTextBox txt_pw;
        private UnderLineTextBox txt_userName;
        private UnderLineTextBox txt_port;
        private UnderLineTextBox txt_ip;
        private System.Windows.Forms.CheckBox chk_remember;
        private System.Windows.Forms.Button btn_conn;
    }
}
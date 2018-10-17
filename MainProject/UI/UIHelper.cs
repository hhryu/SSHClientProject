using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject.UI
{
    public static class UIHelper
    {
        #region Event moving no border form.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lparam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion


        #region SendMessage for the UnderlineTextBox.
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
        #endregion
    }

    public class UnderLineTextBox : TextBox
    {
        public UnderLineTextBox()
        {
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            AutoSize = false;
            //ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));

            Controls.Add(new Label()
            {
                Height = 2,
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
            });

            this.TextChanged += ChangeUnderlineColor;
        }

        private void ChangeUnderlineColor(object sender, EventArgs e)
        {
            Color color;

            if (string.IsNullOrEmpty(this.Text))
                color = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            else
                color = Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));


            foreach (var ctrl in this.Controls)
            {
                if (ctrl is Label label)
                    label.BackColor = color;
            }
        }

        private string text;

        [Localizable(true)]
        public string Watermark
        {
            get { return text; }
            set { text = value; UpdateText(); }
        }

        private void UpdateText()
        {
            if (this.IsHandleCreated && text != null)
            {
                UIHelper.SendMessage(this.Handle, 0x1501, (IntPtr)1, text);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateText();
        }
    }

    public class MultiPagePanel : Panel
    {
        private int currentPageIndex;

        public int CurrentPageIndex
        {
            get { return currentPageIndex; }
            set
            {
                if (value >= 0 && value < Controls.Count)
                {
                    currentPageIndex = value;
                    Controls[currentPageIndex].BringToFront();
                }
            }
        }

        public void AddPage(Control ctrl)
        {
            Controls.Add(ctrl);
            currentPageIndex++;
            Controls[Controls.Count - 1].BringToFront();
        }
    }

    public class MyRichTextBox : RichTextBox
    {
        public string ID { get; set; }

        public Models.Client Client { get; set; }

        public int MinSelection { get; set; }
    }

    public class TabButton : Button
    {
        public bool Selected { get; set; }
    }
}
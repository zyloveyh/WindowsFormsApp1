using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class logForm : Form
    {
        static object syncLocker = new object();

        private logForm()
        {
            InitializeComponent();
        }

        private static logForm _instance;

        public static logForm InstanceLogForm()
        {
            if (_instance == null)
                _instance = new logForm();
            return _instance;
        }
        private TextBox logView;

        private void logForm_Load(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control.GetType().Name.Equals("TextBox"))
                {
                    TextBox tmpView = (TextBox)control;
                    if (tmpView.Name.Equals("textBox1"))
                    {
                        logView = tmpView;

                    }
                }
            }
        }

        public void addLog(string str)
        {
            lock (syncLocker)
            {
                string finalStr = DateTime.Now.ToString() + "  " + str;
                logView.AppendText(finalStr);
                logView.AppendText(Environment.NewLine);
                logView.ScrollToCaret();
            }
        }
    }
}

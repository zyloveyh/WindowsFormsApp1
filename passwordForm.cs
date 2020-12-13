using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.util;
namespace WindowsFormsApp1
{
    public partial class passwordForm : Form
    {

        //设置本窗体单例显示
        public static passwordForm instance;

        public static passwordForm createForm()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new passwordForm();
            }
            return instance;
        }

        private Dictionary<string, string> macDict = new Dictionary<string, string>();

        public passwordForm()
        {
            //初始化的时候,加在电脑信息
            macDict.Add("电脑一", "244BFE96C3DE");

            InitializeComponent();
        }

        private void passwordForm_Load(object sender, EventArgs e)
        {
            foreach (var mac in macDict)
            {
                comboBox1.Items.Add(mac.Key);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(comboBox1.Text) || null == comboBox1.Text)
                {
                    return;
                }
                string macStr = macDict[comboBox1.Text];
                string pwd = LoginSecurity.createPassword(macStr);
                textBox1.Text = pwd;
            }
            catch
            {

            }

        }
    }
}

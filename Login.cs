﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox1.Text.Trim()=="") {
                    return;
                }
                if (LoginSecurity.checkPassword(textBox1.Text.Trim()))
                {
                    //密码校验成功
                    Form1 mainForm = new Form1();
                    mainForm.setLoginVisableFalse(this);
                    mainForm.Show();

                }
                else
                {
                    //密码校验失败
                    MessageBox.Show("密钥无效,或已经过时,请重新输入");
                }
            }
            catch
            {
                //密码校验失败
                MessageBox.Show("密钥无效输入错误,请重试");
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.data;
using WindowsFormsApp1.util;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Login login;


        private void Form1_Load(object sender, EventArgs e)
        {

            if (LoginSecurity.checkBossComputer())
            {
                //是管理员用的电脑
                button1.Visible = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Button allBtn = (System.Windows.Forms.Button)sender;
            if (allBtn.Text.Equals("全部执行"))
            {
                allBtn.Enabled = false;
                //点击了全部执行按钮,便禁用单条执行按钮
                overTurnBtnState(false);
                allBtn.Text = "停止";
                //开始执行线程

                List<QuestionaireEntity> questionList = QuestionaireData.result;

                foreach (var q in questionList)
                {
                    //设置终止线程状态为false
                    q.CloseThread = false;
                    //先判断线程集合中是否有这个线程
                    if (CreateController.threadDict.ContainsKey(q.SeriaNum))
                    {
                        //已经有此线程执行了,直接跳过
                        continue;
                    }
                    //新建刷题线程
                    Thread thread = new Thread(() => CreateController.exercise(this, q));
                    //加入到线程集合中
                    CreateController.threadDict.Add(q.SeriaNum, thread);
                    thread.Name = q.SeriaNum;
                    //启动线程
                    thread.Start();
                }
                allBtn.Enabled = true;

            }
            else
            {
                List<QuestionaireEntity> questionList = QuestionaireData.result;
                foreach (var q in questionList)
                {
                    //设置终止线程状态为false
                    q.CloseThread = true;
                }
                allBtn.Text = "正在停止...";

                /**
                allBtn.Enabled = false;
                //点击了停止 按钮,便停止刷单
                overTurnBtnState(true);
                allBtn.Text = "全部执行";
                //关闭所有的线程
                Dictionary<string, Thread>.ValueCollection threads = CreateController.threadDict.Values;
                foreach (var th in threads)
                {
                    th.Abort();
                    while (th.ThreadState != ThreadState.Aborted)
                    {
                        //当调用Abort方法后，如果thread线程的状态不为Aborted，主线程就一直在这里做循环，直到thread线程的状态变为Aborted为止  
                        Thread.Sleep(100);
                    }

                }
                **/

            }
        }

        public void setLoginVisableFalse(Login login)
        {
            this.login = login;
            login.Visible = false;
        }


        private void overTurnBtnState(Boolean state)
        {
            List<QuestionaireEntity> datas = QuestionaireData.result;
            List<string> serialList = new List<string>();
            foreach (var entity in datas)
            {
                serialList.Add(entity.SeriaNum);
            }
            foreach (var control in this.Controls)
            {
                if (control.GetType().Name.Equals("Button"))
                {
                    System.Windows.Forms.Button btn = (System.Windows.Forms.Button)control;
                    if (serialList.Contains(btn.Name))
                    {
                        //确认是生成出来的Button控件,修改enable 状态
                        if (state)
                        {
                            btn.Text = "停止";
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CreateController.threadDict.Keys.Count > 0)
            {
                MessageBox.Show("请先关闭所有刷题");
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logForm log = logForm.InstanceLogForm();
            log.Visible = !log.Visible;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (null != login)
            {
                login.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            passwordForm pwd = passwordForm.createForm();
            pwd.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //打开日志窗体
            logForm log = logForm.InstanceLogForm();
            log.Show();
            log.Visible = false;
            //设置数据
            CheckForIllegalCrossThreadCalls = false;
            List<QuestionaireEntity> dataList = QuestionaireData.getData();
            for (int i = 0; i < dataList.Count; i++)
            {
                CreateController.addController(10, (1 + i) * 35, this, dataList[i]);
            }
        }
    }
}

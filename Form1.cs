﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            List<QuestionaireEntity> dataList = QuestionaireData.getData();
            for (int i = 0; i < dataList.Count; i++)
            {
                CreateController.addController(10, (1 + i) * 35, this, dataList[i]);
            }

            //foreach (QuestionaireEntity entity in dataList)
            //{
            //     CreateController.addController
            // }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Button allBtn = (Button)sender;
            if (allBtn.Text.Equals("全部执行"))
            {
                allBtn.Enabled = false;
                //点击了全部执行按钮,便禁用单条执行按钮
                overTurnBtnState(false);
                allBtn.Text = "停止";
                //开始执行线程

                List<QuestionaireEntity> questionList = QuestionaireData.getData();

                foreach (var q in questionList)
                {
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
                //到此,表示线程是真的结束了
                CreateController.threadDict = new Dictionary<string, Thread>();
                allBtn.Enabled = true;
            }
        }



        private void overTurnBtnState(Boolean state)
        {
            List<QuestionaireEntity> datas = QuestionaireData.getData();
            List<string> serialList = new List<string>();
            foreach (var entity in datas)
            {
                serialList.Add(entity.SeriaNum);
            }
            foreach (var control in this.Controls)
            {
                if (control.GetType().Name.Equals("Button"))
                {
                    Button btn = (Button)control;
                    if (serialList.Contains(btn.Name))
                    {
                        //确认是生成出来的Button控件,修改enable 状态
                        btn.Enabled = state;
                        if (state)
                        {
                            btn.Text = "单条执行";
                        }
                    }
                }
            }
        }
    }
}

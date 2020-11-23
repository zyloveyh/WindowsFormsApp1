using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.data;
using System.Drawing;
using System.Threading;
using WindowsFormsApp1.entity;
using Newtonsoft.Json;
namespace WindowsFormsApp1.util
{
    class CreateController
    {

        //主窗体对象,用来修改启动的内容
        private static Form1 mainForm;
        //存储刷题的线程,以便后面来停止/暂停
        public static Dictionary<string, Thread> threadDict = new Dictionary<string, Thread>();

        public static Dictionary<string, int> successNum = new Dictionary<string, int>();

        //生成对应的空间
        public static void addController(int x, int y, Form1 form, QuestionaireEntity entity)
        {
            //主窗口赋值给变量
            mainForm = form;

            //序号控件
            Label seriaLable = new Label();
            seriaLable.Text = entity.SeriaNum;
            seriaLable.Size = new System.Drawing.Size(30, 15);
            seriaLable.Location = new System.Drawing.Point(10, y);
            form.Controls.Add(seriaLable);

            Label namelabel = new Label();
            namelabel.Text = entity.Name;
            namelabel.Size = new System.Drawing.Size(140, 15);
            namelabel.Location = new System.Drawing.Point(55, y);
            form.Controls.Add(namelabel);

            Label numlabel = new Label();
            numlabel.Text = entity.QuestionNum.ToString();
            numlabel.Size = new System.Drawing.Size(95, 15);
            numlabel.Location = new System.Drawing.Point(200, y);
            form.Controls.Add(numlabel);

            TextBox addressText = new TextBox();
            addressText.Text = entity.Address;
            addressText.Size = new System.Drawing.Size(195, 30);
            addressText.Multiline = true;
            addressText.Location = new System.Drawing.Point(300, y);
            addressText.BorderStyle = BorderStyle.None;

            form.Controls.Add(addressText);

            Label upNumLabel = new Label();
            upNumLabel.Text = entity.UpNum.ToString();
            upNumLabel.Size = new System.Drawing.Size(50, 15);
            upNumLabel.Location = new System.Drawing.Point(500, y);
            form.Controls.Add(upNumLabel);

            Button actionButton = new Button();
            actionButton.Name = entity.SeriaNum;
            actionButton.Text = "单条执行";
            actionButton.Location = new System.Drawing.Point(600, y);
            form.Controls.Add(actionButton);
            //button按钮添加事件
            actionButton.Click += new System.EventHandler(CreateController.btn_Click);

            Label successNumLabel = new Label();
            successNumLabel.Text = "完成数量: 0";
            //设置label名称,以便后续查询到
            successNumLabel.Name = "label_" + entity.SeriaNum;
            successNumLabel.AutoSize = true;
            successNumLabel.Location = new System.Drawing.Point(700, y);
            form.Controls.Add(successNumLabel);
        }



        public static void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == "单条执行")
            {
                //执行线程,开始刷题
                if (threadDict.ContainsKey(btn.Name))
                {
                    //已经有这么一个线程了
                    MessageBox.Show("此序号的刷题线程已经启动,请勿重复启动!");
                    return;
                }
                //获取需要的刷题信息
                List<QuestionaireEntity> questionList = QuestionaireData.getData();
                QuestionaireEntity entity = new QuestionaireEntity();
                foreach (var q in questionList)
                {
                    if (q.SeriaNum == btn.Name)
                    {
                        entity = q;
                        break;
                    }
                }
                //新建刷题线程
                Thread thread = new Thread(() => exercise(mainForm, entity));
                //加入到线程集合中
                threadDict.Add(btn.Name, thread);
                thread.Name = btn.Name;
                btn.Text = "停止";
                //线程要最后启动
                thread.Start();
            }
            else
            {
                //执行线程,结束刷题
                btn.Text = "单条执行";
                Thread th;
                threadDict.TryGetValue(btn.Name, out th);
                //线程集合中移除此线程

                if (th != null)
                {
                    //停止此线程
                    th.Abort();
                    while (th.ThreadState != ThreadState.Aborted)
                    {
                        //当调用Abort方法后，如果thread线程的状态不为Aborted，主线程就一直在这里做循环，直到thread线程的状态变为Aborted为止  
                        Thread.Sleep(100);
                    }
                    threadDict.Remove(btn.Name);
                }
            }
        }
        public static void exercise(Form1 mainForm, QuestionaireEntity entity)
        {
            int tempNum = 0;
            successNum.TryGetValue(entity.SeriaNum, out tempNum);

            while (tempNum < entity.UpNum)
            {
                //需要暂停20秒左右的时间,等待ip更新
                Thread.Sleep(2000);
                System.Diagnostics.Debug.WriteLine("开始调用接口");
                //todo 进行接口调用,判断是否调用成功,更新主界面数据,调用记录保存
                String resultStr = HttpUtil.HTTPJsonGet(getURL(entity));
                System.Diagnostics.Debug.WriteLine("接口返回: " + resultStr);

                //解析返回的结果
                JavaScriptObject re = JavaScriptConvert.DeserializeObject<JavaScriptObject>(resultStr);
                if (re == null)
                {
                    continue;
                }
                string msg = re["msg"].ToString();
                System.Diagnostics.Debug.WriteLine("code: " + re["code"].ToString());
                System.Diagnostics.Debug.WriteLine("msg: " + msg);
                if ("200".Equals(re["code"].ToString()))
                {
                    if (msg.Contains("已经填写过问卷"))
                    {
                        //已经填写过了
                    }
                    if (msg.Contains("问卷添加成功"))
                    {
                        //添加成功了
                        int num = 0;
                        if (successNum.ContainsKey(entity.SeriaNum))
                        {
                            //有这个线程的完成刷题的数量值
                            successNum.TryGetValue(entity.SeriaNum, out num);
                        }
                        else
                        {
                            //没有这个线程的完成刷题的数量值
                            successNum.Add(entity.SeriaNum, 0);
                        }
                        num++;
                        //新值加入到集合中
                        successNum.Remove(entity.SeriaNum);
                        successNum.Add(entity.SeriaNum, num);
                        //修改对应label的值
                        foreach (var control in mainForm.Controls)
                        {
                            if (control.GetType().Name.Equals("Label"))
                            {
                                Label lb = (Label)control;
                                string labelName = "label_" + entity.SeriaNum;
                                if (labelName.Equals(lb.Name))
                                {
                                    //找到了对应的label,开始修改值
                                    lb.Text = "完成数量: " + num;
                                    tempNum = num;
                                }
                            }
                        }

                    }

                }
            }

            //走到这里,刷单线程,完成了目标任务
            //修改按钮的显示
            foreach (var control in mainForm.Controls)
            {
                if (control.GetType().Name.Equals("Button"))
                {
                    Button tmpBtn = (Button)control;
                    if (entity.SeriaNum.Equals(tmpBtn.Name))
                    {
                        //找到了触发此线程的控件,在线程完成任务后,修改按钮状态
                        tmpBtn.Text = "单条执行";
                        //先维护好线程集合
                        threadDict.Remove(entity.SeriaNum);
                    }
                }
            }

        }

        private static string getURL(QuestionaireEntity entity)
        {
            string result = "";
            string csrf_test_name = "bb13c888c7da784789d130c081ca9d53";
            string url = entity.Address;
            url = url.Replace("m=index", "m=addSelOptions");
            string optioned = CreateAnswer.createAnswer(entity);
            result = url + "&optioned=" + optioned + "&csrf_test_name=" + csrf_test_name;
            return result;
        }

    }

}

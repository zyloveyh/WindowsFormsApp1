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
using System.Net;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.util
{
    class CreateController
    {
        static object syncLocker = new object();

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

            NumericUpDown upNumText = new NumericUpDown();
            upNumText.Maximum = 10000;
            upNumText.Name = "upNum_" + entity.SeriaNum;
            upNumText.Text = entity.UpNum.ToString();
            upNumText.Size = new System.Drawing.Size(50, 15);
            upNumText.Location = new System.Drawing.Point(500, y);
            form.Controls.Add(upNumText);
            //添加内容修改事件
            upNumText.ValueChanged += new System.EventHandler(upNumChange);


            NumericUpDown slotNum = new NumericUpDown();
            slotNum.Maximum = 10000;
            slotNum.Name = "slotNum_" + entity.SeriaNum;
            slotNum.Value = entity.SlotTime; ;
            slotNum.Size = new System.Drawing.Size(50, 25);
            slotNum.Location = new System.Drawing.Point(570, y);
            form.Controls.Add(slotNum);
            //添加内容修改事件
            slotNum.ValueChanged += new System.EventHandler(slotTimeChange);

            Button actionButton = new Button();
            actionButton.Name = entity.SeriaNum;
            actionButton.Text = "单条执行";
            actionButton.Location = new System.Drawing.Point(690, y);
            form.Controls.Add(actionButton);
            //button按钮添加事件
            actionButton.Click += new System.EventHandler(CreateController.btn_Click);

            Label successNumLabel = new Label();
            successNumLabel.Text = "完成数量: 0";
            //设置label名称,以便后续查询到
            successNumLabel.Name = "label_" + entity.SeriaNum;
            successNumLabel.AutoSize = true;
            successNumLabel.Location = new System.Drawing.Point(800, y);
            form.Controls.Add(successNumLabel);
        }

        public static void upNumChange(object sender, EventArgs e)
        {
            //上限数量改变事件
            NumericUpDown tb = (NumericUpDown)sender;
            try
            {
                int value = int.Parse(tb.Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("请输入有效数字!");
            }
            //加上锁 进行对QuestionaireData.result; 的修改
            lock (syncLocker)
            {
                logForm log = logForm.InstanceLogForm();
                List<QuestionaireEntity> questionList = QuestionaireData.result;
                QuestionaireEntity entity = new QuestionaireEntity();
                foreach (var q in questionList)
                {
                    if ("upNum_" + q.SeriaNum == tb.Name)
                    {
                        entity = q;
                        QuestionaireData.result.Remove(q);
                        break;
                    }
                }
                entity.UpNum = int.Parse(tb.Value.ToString());
                QuestionaireData.result.Add(entity);
                log.addLog("序号: " + entity.SeriaNum + "修改了刷题上限为: " + entity.UpNum);
            }

            System.Diagnostics.Debug.WriteLine("刷题数量上限修改为: " + tb.Value.ToString());
        }

        public static void slotTimeChange(object sender, EventArgs e)
        {

            //刷题间隔时间改变事件
            NumericUpDown slotNum = (NumericUpDown)sender;
            try
            {
                int value = int.Parse(slotNum.Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("请输入有效数字!");
            }
            //加上锁 进行对QuestionaireData.result; 的修改
            lock (syncLocker)
            {
                logForm log = logForm.InstanceLogForm();
                List<QuestionaireEntity> questionList = QuestionaireData.result;
                QuestionaireEntity entity = new QuestionaireEntity();
                foreach (var q in questionList)
                {
                    if ("slotNum_" + q.SeriaNum == slotNum.Name)
                    {
                        QuestionaireData.result.Remove(q);
                        entity = q;
                        break;
                    }
                }
                entity.SlotTime = int.Parse(slotNum.Value.ToString());
                QuestionaireData.result.Add(entity);
                log.addLog("序号: " + entity.SeriaNum + "修改了刷题间隔为: " + entity.SlotTime);
            }
            System.Diagnostics.Debug.WriteLine("刷题间隔时间修改为: " + slotNum.Value);
        }

        public static void btn_Click(object sender, EventArgs e)
        {
            logForm log = logForm.InstanceLogForm();
            Button btn = (Button)sender;
            //获取需要的刷题信息
            List<QuestionaireEntity> questionList = QuestionaireData.result;
            QuestionaireEntity entity = new QuestionaireEntity();
            foreach (var q in questionList)
            {
                if (q.SeriaNum == btn.Name)
                {
                    entity = q;
                    break;
                }
            }

            if (btn.Text == "单条执行")
            {
                //执行线程,开始刷题
                if (threadDict.ContainsKey(btn.Name))
                {
                    //已经有这么一个线程了
                    MessageBox.Show("此序号的刷题线程已经启动,请勿重复启动!");
                    return;
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
                    log.addLog(getLogStr(entity, " 手动暂停了此刷题"));
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
        public static void exercise(Form1 mainForm, QuestionaireEntity questEntity)
        {
            QuestionaireEntity entity = questEntity;
            logForm log = logForm.InstanceLogForm();
            log.addLog(getLogStr(entity, " 开始刷题"));

            int tempNum = 0;
            successNum.TryGetValue(entity.SeriaNum, out tempNum);

            while (tempNum < entity.UpNum)
            {
                System.Diagnostics.Debug.WriteLine("开始调用接口,调用时间间隔:" + (entity.SlotTime * 1000).ToString());

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

                        log.addLog(getLogStr(entity, " 刷题入库失败! 刷题结果: " + msg));
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
                        //添加日志
                        log.addLog(getLogStr(entity, " 刷题入库成功! 刷题结果: " + msg));
                    }
                }
                List<QuestionaireEntity> questionList = QuestionaireData.result;
                foreach (var q in questionList)
                {
                    if (q.SeriaNum == entity.SeriaNum)
                    {
                        entity = q;
                        break;
                    }
                }
                //需要暂停20秒左右的时间,等待ip更新
                Thread.Sleep(entity.SlotTime * 1000);
            }


            log.addLog(getLogStr(entity, " 刷题结束 "));
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

        /**
         * 设置打印的日志内容
         */
        private static string getLogStr(QuestionaireEntity entity, string msg)
        {
            string name = entity.Name;
            if (entity.Name.Length < 20)
            {
                for (int i = 0; i < (20 - entity.Name.Length); i++)
                {
                    name += "  ";
                }
            }
            string resultStr = "";
            resultStr = "序号: " + entity.SeriaNum + " 问卷名称: " + name + msg;
            return resultStr;
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

        public static string HttpGet()
        {
            Encoding encode = System.Text.Encoding.GetEncoding("GB2312");
            WebClient MyWebClient = new WebClient();
            MyWebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.84 Safari/537.36");
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData("http://www.net.cn/static/customercare/yourip.asp"); //从指定网站下载数据
            string pageHtml = encode.GetString(pageData);  //如果获取网站页面采用的是GB2312，则 使用这句
            return pageHtml;
        }

        public static string parseHtml(String pageHtml)
        {
            string ip = "";
            Match m = Regex.Match(pageHtml, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}");
            if (m.Success)
            {
                //MessageBox.Show(m.Value);
            }
            ip = pageHtml;
            return ip;
        }

    }

}

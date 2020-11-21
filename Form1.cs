using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                //点击了全部执行按钮,便禁用单条执行按钮
                overTurnBtnState();
                allBtn.Text = "停止";
            }
            else
            {
                //点击了停止 按钮,便停止刷单
                overTurnBtnState();
                allBtn.Text = "全部执行";
            }



        }



        private void overTurnBtnState()
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
                        btn.Enabled = !btn.Enabled;
                    }
                }
            }
        }
    }
}

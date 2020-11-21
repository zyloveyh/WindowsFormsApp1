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
    }
}

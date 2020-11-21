using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.data;
using System.Drawing;

namespace WindowsFormsApp1.util
{
    class CreateController
    {
        //生成对应的空间
        public static void addController(int x, int y, Form1 form, QuestionaireEntity entity)
        {
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

            Label successNumLabel = new Label();
            successNumLabel.Text = "完成数量: 0";
            successNumLabel.AutoSize = true;
            successNumLabel.Location = new System.Drawing.Point(700, y);
            form.Controls.Add(successNumLabel);
        }
    }
}

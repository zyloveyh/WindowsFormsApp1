using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.data
{
    class QuestionaireEntity
    {
        //序号
        private String seriaNum;
        //问卷名称
        private String name;
        //题目数量
        private int questionNum;
        //问卷地址
        private String address;
        //问卷答案范围
        private Dictionary<int, int> answerScope;
        //刷题上限,默认10条
        private int upNum =10;


        public string SeriaNum { get => seriaNum; set => seriaNum = value; }
        public string Name { get => name; set => name = value; }
        public int QuestionNum { get => questionNum; set => questionNum = value; }
        public string Address { get => address; set => address = value; }
        public Dictionary<int, int> AnswerScope { get => answerScope; set => answerScope = value; }
        public int UpNum { get => upNum; set => upNum = value; }
    }
}

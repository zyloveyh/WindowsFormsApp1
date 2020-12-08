using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.data
{
    class QuestionaireEntity
    {
        //必须唯一 用来当主键使用
        private String seriaNum;
        //对应excel表格中的序号
        private String kindNum;
        //问卷名称
        private String name;
        //问卷编号
        private String code;
        //题目数量
        private int questionNum;
        //问卷地址
        private String address;
        //问卷答案范围
        private Dictionary<int, int> answerScope;
        //刷题上限,默认10条
        private int upNum = 10;
        //刷题的时间间隔
        private int slotTime = 20;


        //手动结束此刷题的线程
        private Boolean closeThread = false;


        public QuestionaireEntity Copy()
        {
            return (QuestionaireEntity)this.MemberwiseClone();
        }
        public string SeriaNum { get => seriaNum; set => seriaNum = value; }
        public string Name { get => name; set => name = value; }
        public int QuestionNum { get => questionNum; set => questionNum = value; }
        public string Address { get => address; set => address = value; }
        public Dictionary<int, int> AnswerScope { get => answerScope; set => answerScope = value; }
        public int UpNum { get => upNum; set => upNum = value; }
        public int SlotTime { get => slotTime; set => slotTime = value; }
        public bool CloseThread { get => closeThread; set => closeThread = value; }
        public string Code { get => code; set => code = value; }
        public string KindNum { get => kindNum; set => kindNum = value; }
    }
}

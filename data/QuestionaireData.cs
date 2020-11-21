using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.data
{
    class QuestionaireData
    {
           public static List<QuestionaireEntity> getData()
        {
            
            List<QuestionaireEntity> result  = new List<QuestionaireEntity>();

            QuestionaireEntity entity1 = new QuestionaireEntity();
            QuestionaireEntity entity2 = new QuestionaireEntity();
            QuestionaireEntity entity3 = new QuestionaireEntity();
            QuestionaireEntity entity4 = new QuestionaireEntity();
            

            entity1.SeriaNum = "1";
            entity1.Name = "测试";
            entity1.QuestionNum = 11;
            entity1.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=5&eid=9&suid=25&puid=26";
            Dictionary<int, int> dict1 = new Dictionary<int, int>();
            dict1.Add(1, 2);
            dict1.Add(2, 3);
            dict1.Add(3, 3);
            dict1.Add(4, 3);
            dict1.Add(5, 3);
            dict1.Add(6, 4);
            dict1.Add(7, 4);
            dict1.Add(8, 4);
            dict1.Add(9, 4);
            dict1.Add(10, 5);
            dict1.Add(11, 5);
            entity1.AnswerScope = dict1;
            result.Add(entity1);

            entity2.SeriaNum = "2";
            entity2.Name = "骨科观念调查问卷";
            entity2.QuestionNum = 13;
            entity2.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=15&eid=16&suid=25&puid=15";
            Dictionary<int, int> dict2 = new Dictionary<int, int>();
            dict2.Add(1, 4);
            dict2.Add(2, 5);
            dict2.Add(3, 4);
            dict2.Add(4, 9);
            dict2.Add(5, 4);
            dict2.Add(6, 5);
            dict2.Add(7, 4);
            dict2.Add(8, 4);
            dict2.Add(9, 4);
            dict2.Add(10, 5);
            dict2.Add(11, 4);
            dict2.Add(12, 7);
            dict2.Add(13, 6);

            entity2.AnswerScope = dict2;
            result.Add(entity2);


            entity3.SeriaNum = "3";
            entity3.Name = "内分泌科观念调查问卷";
            entity3.QuestionNum = 13;
            entity3.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=16&eid=17&suid=25&puid=15";
            Dictionary<int, int> dict3 = new Dictionary<int, int>();
            dict3.Add(1, 4);
            dict3.Add(2, 5);
            dict3.Add(3, 4);
            dict3.Add(4, 9);
            dict3.Add(5, 4);
            dict3.Add(6, 5);
            dict3.Add(7, 4);
            dict3.Add(8, 6);
            dict3.Add(9, 4);
            dict3.Add(10, 5);
            dict3.Add(11, 4);
            dict3.Add(12, 7);
            dict3.Add(13, 6);
            entity3.AnswerScope = dict3;
            result.Add(entity3);


            entity4.SeriaNum = "4";
            entity4.Name = "高血压知识问卷";
            entity4.QuestionNum = 27;
            entity4.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=18&eid=18&suid=25&puid=15";
            Dictionary<int, int> dict4 = new Dictionary<int, int>();
            dict4.Add(1, 8);
            dict4.Add(2, 4);
            dict4.Add(3, 4);
            dict4.Add(4, 4);
            dict4.Add(5, 5);
            dict4.Add(6, 5);
            dict4.Add(7, 5);
            dict4.Add(8, 4);
            dict4.Add(9, 4);
            dict4.Add(10, 3);
            dict4.Add(11, 2);
            dict4.Add(12, 2);
            dict4.Add(13, 4);
            dict4.Add(14, 4);
            dict4.Add(15, 4);
            dict4.Add(16, 3);
            dict4.Add(17, 4);
            dict4.Add(18, 4);
            dict4.Add(19, 4);
            dict4.Add(20, 4);
            dict4.Add(21, 4);
            dict4.Add(22, 4);
            dict4.Add(23, 5);
            dict4.Add(24, 7);
            dict4.Add(25, 6);
            dict4.Add(26, 7);
            dict4.Add(27, 7);
            entity4.AnswerScope = dict4;
            result.Add(entity4);


            return result;
        }
    }
}

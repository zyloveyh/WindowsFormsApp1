using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.data
{
    class QuestionaireData
    {
        public static List<QuestionaireEntity> result = new List<QuestionaireEntity>();


        /**
         * 此方法只能被调用一次
         */
        public static List<QuestionaireEntity> getData()
        {
            if (result.Count > 0)
            {
                //result 有值,则返回这个值,避免多次调用出现bug
                return result;
            }

            QuestionaireEntity entity20_1 = new QuestionaireEntity();

            QuestionaireEntity entity21_1 = new QuestionaireEntity();

            /**
             * 医疗机构医疗器械使用情况调研问卷（一)
             */

            entity20_1.SeriaNum = "1";
            entity20_1.KindNum = "5";
            entity20_1.Name = "医疗机构医疗器械使用情况调研问卷（一)";
            entity20_1.Code = "20-1";
            entity20_1.QuestionNum = 11;
            entity20_1.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=20&eid=25&suid=25&puid=46";
            Dictionary<int, int> dict1 = new Dictionary<int, int>();
            dict1.Add(1, 2);
            dict1.Add(2, 2);
            dict1.Add(3, 2);
            dict1.Add(4, 4);
            dict1.Add(5, 3);
            dict1.Add(6, 3);
            dict1.Add(7, 3);
            dict1.Add(8, 2);
            dict1.Add(9, 3);
            dict1.Add(10, 3);
            dict1.Add(11, 4);
            entity20_1.AnswerScope = dict1;
            result.Add(entity20_1);

            QuestionaireEntity entity20_2 = entity20_1.Copy();
            entity20_2.SeriaNum = "2";
            entity20_2.Code = "20-2";
            entity20_2.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=20&eid=25&suid=25&puid=48";
            result.Add(entity20_2);

            QuestionaireEntity entity20_3 = entity20_1.Copy();
            entity20_3.SeriaNum = "3";
            entity20_3.Code = "20-3";
            entity20_3.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=20&eid=25&suid=25&puid=50";
            result.Add(entity20_3);

            QuestionaireEntity entity20_4 = entity20_1.Copy();
            entity20_4.SeriaNum = "4";
            entity20_4.Code = "20-4";
            entity20_4.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=20&eid=27&suid=13&puid=46";
            result.Add(entity20_4);

            QuestionaireEntity entity20_5 = entity20_1.Copy();
            entity20_5.SeriaNum = "5";
            entity20_5.Code = "20-5";
            entity20_5.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=20&eid=27&suid=13&puid=49";
            result.Add(entity20_5);

            QuestionaireEntity entity20_6 = entity20_1.Copy();
            entity20_6.SeriaNum = "6";
            entity20_6.Code = "20-6";
            entity20_6.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=20&eid=23&suid=7&puid=14";
            result.Add(entity20_6);

            QuestionaireEntity entity20_7 = entity20_1.Copy();
            entity20_7.SeriaNum = "7";
            entity20_7.Code = "20-7";
            entity20_7.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=20&eid=23&suid=7&puid=47";
            result.Add(entity20_7);

            QuestionaireEntity entity20_8 = entity20_1.Copy();
            entity20_8.SeriaNum = "8";
            entity20_8.Code = "20-8";
            entity20_8.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=20&eid=23&suid=7&puid=51";
            result.Add(entity20_8);

            QuestionaireEntity entity20_9 = entity20_1.Copy();
            entity20_9.SeriaNum = "9";
            entity20_9.Code = "20-9";
            entity20_9.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=21&eid=26&suid=25&puid=15";
            result.Add(entity20_9);

            QuestionaireEntity entity20_10 = entity20_1.Copy();
            entity20_10.SeriaNum = "10";
            entity20_10.Code = "20-10";
            entity20_10.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=21&eid=26&suid=25&puid=47";
            result.Add(entity20_10);

            QuestionaireEntity entity20_11 = entity20_1.Copy();
            entity20_11.SeriaNum = "11";
            entity20_11.Code = "20-11";
            entity20_11.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=21&eid=26&suid=25&puid=49";
            result.Add(entity20_11);


            /**
             * 医疗机构医疗器械使用情况调研问卷（二)
             */

            entity21_1.SeriaNum = "12";
            entity21_1.KindNum = "6";
            entity21_1.Name = "医疗机构医疗器械使用情况调研问卷（二)";
            entity21_1.Code = "21-1";
            entity21_1.QuestionNum = 36;
            entity21_1.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=21&eid=28&suid=13&puid=48";
            Dictionary<int, int> dict2 = new Dictionary<int, int>();
            dict2.Add(1, 4);
            dict2.Add(2, 3);
            dict2.Add(3, 3);
            dict2.Add(4, 3);
            dict2.Add(5, 3);
            dict2.Add(6, 3);
            dict2.Add(7, 5);
            dict2.Add(8, 5);
            dict2.Add(9, 4);
            dict2.Add(10, 3);
            dict2.Add(11, 3);
            dict2.Add(12, 4);
            dict2.Add(13, 4);
            dict2.Add(14, 4);
            dict2.Add(15, 5);
            dict2.Add(16, 4);
            dict2.Add(17, 4);
            dict2.Add(18, 4);
            dict2.Add(19, 4);
            dict2.Add(20, 5);
            dict2.Add(21, 5);
            dict2.Add(22, 5);
            dict2.Add(23, 5);
            dict2.Add(24, 3);
            dict2.Add(25, 3);
            dict2.Add(26, 3);
            dict2.Add(27, 5);
            dict2.Add(28, 3);
            dict2.Add(29, 3);
            dict2.Add(30, 4);
            dict2.Add(31, 4);
            dict2.Add(32, 7);
            dict2.Add(33, 5);
            dict2.Add(34, 5);
            dict2.Add(35, 5);
            dict2.Add(36, 4);
            entity21_1.AnswerScope = dict2;
            result.Add(entity21_1);

            QuestionaireEntity entity21_2 = entity21_1.Copy();
            entity21_2.SeriaNum = "13";
            entity21_2.Code = "21-2";
            entity21_2.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=21&eid=28&suid=13&puid=51";
            result.Add(entity21_2);

            QuestionaireEntity entity21_3 = entity21_1.Copy();
            entity21_3.SeriaNum = "14";
            entity21_3.Code = "21-3";
            entity21_3.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=21&eid=24&suid=7&puid=15";
            result.Add(entity21_3);


            QuestionaireEntity entity21_4 = entity21_1.Copy();
            entity21_4.SeriaNum = "15";
            entity21_4.Code = "21-4";
            entity21_4.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=21&eid=24&suid=7&puid=14";
            result.Add(entity21_4);

            QuestionaireEntity entity21_5 = entity21_1.Copy();
            entity21_5.SeriaNum = "16";
            entity21_5.Code = "21-5";
            entity21_5.Address = "http://www.masghkj.com/index.php?s=questionnaire&c=options&m=index&cid=21&eid=24&suid=7&puid=46";
            result.Add(entity21_5);





            /**
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

            **/

            return result;
        }
    }
}

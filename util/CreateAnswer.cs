using System;
using WindowsFormsApp1.data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1.util
{
    class CreateAnswer
    {
        public static string createAnswer(QuestionaireEntity entity)
        {
            string result = "";
            Random rd = new Random();
            Dictionary<int, int> answer = entity.AnswerScope;
            foreach (var item in answer)
            {
                int randomValue = rd.Next(1, item.Value + 1);
                result += randomValue.ToString() + ",";
            }
            System.Diagnostics.Debug.WriteLine("结果: " + result);
            return result;
        }
    }
}

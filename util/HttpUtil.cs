using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.util
{
    class HttpUtil
    {

        private static readonly Encoding ENCODING = Encoding.UTF8;
        /*
        public static string CommonHttpRequest(string data, string uri, string type)
        {

            //Web访问对象，构造请求的url地址
            string serviceUrl = uri;

            //构造http请求的对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            myRequest.Timeout = 10000;
            //转成网络流
            byte[] buf = ENCODING.GetBytes(data);
            //设置
            myRequest.Method = type;
            myRequest.ContentLength = buf.LongLength;
            myRequest.ContentType = "application/json";

            //将客户端IP加到头文件中
           
             //string sRealIp = GetHostAddress();
            //if (!string.IsNullOrEmpty(sRealIp))
            //{
             //   myRequest.Headers.Add("ClientIp", sRealIp);
            //}
             


            using (Stream reqstream = myRequest.GetRequestStream())
            {
                reqstream.Write(buf, 0, (int)buf.Length);
            }
            HttpWebResponse resp = myRequest.GetResponse() as HttpWebResponse;
            System.IO.StreamReader reader = new System.IO.StreamReader(resp.GetResponseStream(), ENCODING);
            string result = reader.ReadToEnd();
            reader.Close();
            resp.Close();
            return result;
        }
*/

        public static string HTTPJsonGet(string url)
        {
            /**
            string result = string.Empty;
            try
            {
                System.Diagnostics.Debug.WriteLine("开始调用接口: " + url);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.Method = "GET";
                HttpWebResponse resp = request.GetResponse() as HttpWebResponse;
                System.IO.StreamReader reader = new System.IO.StreamReader(resp.GetResponseStream(), ENCODING);
                result = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("HTTPJsonGet异常:" + ex.Message);

            }
            **/
            string result = "{\"code\":200,\"msg\":\"问卷添加成功，感谢您的参与！\",\"data\":[]}";
            return result;
        }

    }
}

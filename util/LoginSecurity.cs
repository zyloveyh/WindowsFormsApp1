using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApp1.util
{
    class LoginSecurity
    {
        private static String key = "12345678123456781234567812345678";
        //生成秘钥方法
        public static String createPassword(string mac)
        {
            //0.获取本地时间
            Console.WriteLine("本机电脑时间:" + DateTime.Now);
            //1.获取网络时间
            string dt = GetNetDateTime();
            Console.WriteLine("当前时间dt:" + dt);
            //2.网络时间加5分钟
            DateTime t2 = Convert.ToDateTime(dt).AddMinutes(5);
            Console.WriteLine("5分钟后的时间t2:" + t2);
            //3.时间加mac地址后加密 作为秘钥传递
            //String mac = GetMacAddress();
            String str = mac + "+" + t2.ToString();
            Console.WriteLine("加密前的密文是:" + str);
            //4.AES加密
            String password = AesEncrypt(str, key);
            Console.WriteLine("小工具秘钥是:" + password);
            return password;
        }

        //验证秘钥的方法
        public static bool checkPassword(String password)
        {
            String mw = AesDecrypt(password, key);
            Console.WriteLine("解密后的明文是:" + mw);

            String[] result = mw.Split('+');
            //获取本机Mac地址
            List<String> macList = GetMacAddress();
            //校验mac地址
            //设置mac验证是否正确的状态
            bool macSuccess = false;
            foreach (var mac in macList)
            {

                if (mac == result[0])
                {
                    macSuccess = true;
                }
            }
            //验证是否有这个mac地址,
            if (!macSuccess)
            {
                //到这里就说明没有mac地址
                return false;
            }
            String dateStr = GetNetDateTime();
            Console.WriteLine("用户端获取的网络时间是：" + dateStr);
            DateTime date = Convert.ToDateTime(dateStr);
            Console.WriteLine("用户电脑时间:" + date.ToString());
            //校验时间
            DateTime datePassword = Convert.ToDateTime(result[1]);
            Console.WriteLine("秘钥中时间:" + datePassword.ToString());
            if (DateTime.Compare(datePassword, date) != 1)
            {
                return false;
            }
            return true;
        }

        //获取网络时间
        public static string GetNetDateTime()
        {
            WebRequest request = null;
            WebResponse response = null;
            WebHeaderCollection headerCollection = null;
            string datetime = string.Empty;
            try
            {
                request = WebRequest.Create("https://www.baidu.com");
                request.Timeout = 1000;
                request.Credentials = CredentialCache.DefaultCredentials;
                response = (WebResponse)request.GetResponse();
                headerCollection = response.Headers;
                foreach (var h in headerCollection.AllKeys)
                { if (h == "Date") { datetime = headerCollection[h]; } }
                return datetime;
            }
            catch (Exception)
            {
                request = WebRequest.Create("https://www.baidu.com");
                request.Timeout = 1000;
                request.Credentials = CredentialCache.DefaultCredentials;
                response = (WebResponse)request.GetResponse();
                headerCollection = response.Headers;
                foreach (var h in headerCollection.AllKeys)
                { if (h == "Date") { datetime = headerCollection[h]; } }
                return datetime;
            }
            finally
            {
                if (request != null)
                { request.Abort(); }
                if (response != null)
                { response.Close(); }
                if (headerCollection != null)
                { headerCollection.Clear(); }
            }
        }

        //获取mac地址
        public static List<String> GetMacAddress()
        {
            List<String> macAddress = new List<string>();
            string physicalAddress = "";
            NetworkInterface[] nice = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adaper in nice)
            {
                if (adaper.Description == "en0")
                {
                    physicalAddress = adaper.GetPhysicalAddress().ToString();
                }
                else
                {
                    physicalAddress = adaper.GetPhysicalAddress().ToString();

                }
                if (physicalAddress != "")
                {
                    macAddress.Add(physicalAddress);
                };
            }
            return macAddress;
        }

        /// <summary>
        ///  AES 加密
        /// </summary>
        /// <param name="str">明文（待加密）</param>
        /// <param name="key">密文</param>
        /// <returns></returns>
        public static string AesEncrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        ///  AES 解密
        /// </summary>
        /// <param name="str">明文（待解密）</param>
        /// <param name="key">密文</param>
        /// <returns></returns>
        public static string AesDecrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Convert.FromBase64String(str);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }

        public static bool checkBossComputer()
        {
            List<String> macStr = LoginSecurity.GetMacAddress();

            if (macStr.Contains("000C293E00DC") ||macStr.Contains("E0B9A51D6A30") || macStr.Contains("00ACD1D81394") || macStr.Contains("00AC20D83586z"))
            {
                //是管理员用的电脑
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

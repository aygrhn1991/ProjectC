using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjectC.Extentions.Helpers
{
    public class PhoneValidateCode
    {
        
        public static string CreatePhoneValidateCode(int length)
        {
            string str = "1234567890";
            Random random = new Random();
            string code = string.Empty;
            for (int i = 0; i < length; i++)
            {
                int n = random.Next(0, 10);
                string s = str.Substring(n, 1);
                code += s;
            }
            return code;
        }
        public static string SendPhoneValidateCode_Post(string url, string param)
        {
            System.Text.Encoding myEncode = System.Text.Encoding.GetEncoding("UTF-8");
            byte[] postBytes = System.Text.Encoding.ASCII.GetBytes(param);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            req.ContentLength = postBytes.Length;
            try
            {
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(postBytes, 0, postBytes.Length);
                }
                using (WebResponse res = req.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(res.GetResponseStream(), myEncode))
                    {
                        string strResult = sr.ReadToEnd();
                        return strResult;
                    }
                }
            }
            catch (WebException ex)
            {
                return "无法连接到服务器\r\n错误信息：" + ex.Message;
            }
        }
        public static string SendPhoneValidateCode_Get(string url, string param)
        {
            string address = url + "?" + param;
            Uri uri = new Uri(address);
            WebRequest webReq = WebRequest.Create(uri);
            try
            {
                using (HttpWebResponse webResp = (HttpWebResponse)webReq.GetResponse())
                {
                    using (Stream respStream = webResp.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(respStream, System.Text.Encoding.GetEncoding("UTF-8")))
                        {
                            string strRes = objReader.ReadToEnd();
                            return strRes;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return "无法连接到服务器/r/n错误信息：" + ex.Message;
            }
        }
    }
}
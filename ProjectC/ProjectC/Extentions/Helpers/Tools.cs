using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjectC.Extentions.Helpers
{
    public class Tools
    {
        public static T JsonToObj<T>(T model, string str)
        {
            using (StringReader stringReader = new StringReader(str))
            {
                JsonSerializer serializer = new JsonSerializer();
                object obj = serializer.Deserialize(new JsonTextReader(stringReader), typeof(T));
                //T result = obj as T;
                T result = (T)obj;
                return result;
            }
        }
        public static string ObjToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
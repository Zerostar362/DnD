using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DnD.Model.System.ExtensionMethods
{
    public static class Extensions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static TValue? ConvertJson<TValue>(this string str)
        {
            return JsonConvert.DeserializeObject<TValue>(str);
        }

        public static object? ConvertJson(this string str)
        {
            return JsonConvert.DeserializeObject(str);
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Core.Common
{
    public static class JsonHelper
    {
        public static string ToJson(this object obj)
        {
            var converters = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };

            return JsonConvert.SerializeObject(obj, converters);
        }
    }
}
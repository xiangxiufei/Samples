using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Core
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(obj, Formatting.None, serializerSettings);
        }
    }
}
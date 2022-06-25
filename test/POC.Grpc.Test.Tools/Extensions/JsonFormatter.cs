using Newtonsoft.Json;

namespace POC.Grpc.Test.Tools.Extensions
{
    public static class JsonFormatter
    {
        public static string ToJson(this string json)
        {
            var obj = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
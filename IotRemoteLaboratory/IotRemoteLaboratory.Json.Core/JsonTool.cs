using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace IotRemoteLaboratory.Json.Core
{
    public static class JsonTool<T>
    {
        public static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented
        };

        public static void Serialize(object value, string path)
        {
            var json = JsonConvert.SerializeObject(value, settings);
            File.WriteAllText(path, json, System.Text.Encoding.UTF8);
        }

        public static T Deserialize(string path)
        {
            var data = File.ReadAllText(path, System.Text.Encoding.UTF8);
            return JsonConvert.DeserializeObject<T>(data, settings);
        }
    }
}


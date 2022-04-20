using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace REST_API_GET_POST.Utils
{
    class ParseJSON
    {
        public static Dictionary<string, string> GetConfigFile(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public static T GetDataFile<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T ModelFromJson<T>(string Json)
        {
            return JsonConvert.DeserializeObject<T>(Json);
        }
    }
}

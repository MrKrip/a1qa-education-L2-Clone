using Aquality.Selenium.Browsers;
using Newtonsoft.Json;

namespace SMART_VK_API.Util
{
    public static class ParseJSON
    {
        public static Dictionary<string, string> GetConfigFile(string path)
        {
            AqualityServices.Logger.Info($"Reading a configuration file");
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public static T GetDataFile<T>(string path)
        {
            AqualityServices.Logger.Info($"Reading a {path} file");
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T ModelFromJson<T>(string Json)
        {
            AqualityServices.Logger.Info($"Convert json to model");
            return JsonConvert.DeserializeObject<T>(Json);
        }
    }
}

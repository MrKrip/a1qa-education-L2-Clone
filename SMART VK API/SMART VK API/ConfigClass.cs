using SMART_VK_API.Util;

namespace SMART_VK_API
{
    public static class ConfigClass
    {
        public static readonly string DefaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly Dictionary<string, string> Config = ParseJSON.GetConfigFile(DefaultPath + @"\Resources\Config.json");
        public static readonly string ConfigPath = DefaultPath + @"\Resources\config.json";
        public static readonly string UserDataPath = DefaultPath + @"\Resources\User.json";
        public static readonly string PhotoPath = DefaultPath + @"\Resources\TestPhoto.jpg";
    }
}

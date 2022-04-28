using DBTests.Utils;
using System.Collections.Generic;
using System.IO;

namespace DBTests
{
    public static class ConfigClass
    {
        public static readonly string DefaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly Dictionary<string, string> Config = ParseJSON.GetConfigFile(DefaultPath + @"\Resources\Config.json");
    }
}

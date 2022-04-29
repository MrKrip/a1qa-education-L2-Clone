using DBTests.Utils;
using System.Collections.Generic;
using System.IO;

namespace DBTests
{
    public static class ConfigClass
    {
        public static readonly string DefaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly Dictionary<string, string> Config = ParseJSON.GetConfigFile(DefaultPath + @"\Resources\Config.json");
        public static readonly string MinTimeTestPath = DefaultPath + @"\Resources\MinTime.Json";
        public static readonly string TestCountPath = DefaultPath + @"\Resources\TestCount.Json";
        public static readonly string DateCondTestPath = DefaultPath + @"\Resources\DateCondTestPath.Json";
    }
}

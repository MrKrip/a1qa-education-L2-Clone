using REST_API_GET_POST.Utils;
using System.Collections.Generic;
using System.IO;

namespace REST_API_GET_POST
{
    public class ConfigClass
    {        
        public static readonly string DefaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly Dictionary<string, string> Config= ParseJSON.GetConfigFile(DefaultPath + @"\Resources\Config.json");
    }
}

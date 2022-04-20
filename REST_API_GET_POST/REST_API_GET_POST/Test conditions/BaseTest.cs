using NUnit.Framework;
using REST_API_GET_POST.Utils;
using System.Collections.Generic;

namespace REST_API_GET_POST.Test_conditions
{
    class BaseTest
    {
        protected Dictionary<string, string> Config;

        [SetUp]
        public void Setup()
        {
            Config = ParseJSON.GetConfigFile(ConfigClass.ConfigPath);
            ApiUtil.SetClient(Config["MainUrl"]);
        }
    }
}

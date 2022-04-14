using Aquality.Selenium.Browsers;
using NUnit.Framework;
using SMART_DataDriven_KPC.Util;
using System.Collections.Generic;

namespace SMART_DataDriven_KPC.Test_conditions
{
    public class BaseTest
    {
        protected Dictionary<string, string> Config;

        [SetUp]
        public void Setup()
        {
            Config = ParseJSON.GetConfigFile(ConfigClass.ConfigPath);
            AqualityServices.Browser.GoTo(Config["MainPageUrl"]);
        }

        [TearDown]
        public void CleanUp()
        {
            AqualityServices.Browser.Quit();
        }
    }
}

using Aquality.Selenium.Browsers;
using NUnit.Framework;
using SMART_VK_API.Util;

namespace SMART_VK_API.Test_conditions
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

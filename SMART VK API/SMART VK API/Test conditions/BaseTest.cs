using Aquality.Selenium.Browsers;
using NUnit.Framework;
using SMART_VK_API.Util;

namespace SMART_VK_API
{
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            ApiUtils.SetClient(ConfigClass.Config["ApiUrl"]);
            AqualityServices.Browser.GoTo(ConfigClass.Config["MainPageUrl"]);
        }

        [TearDown]
        public void CleanUp()
        {
            AqualityServices.Browser.Quit();
        }
    }
}

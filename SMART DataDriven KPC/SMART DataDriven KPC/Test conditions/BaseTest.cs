using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace SMART_DataDriven_KPC.Test_conditions
{
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            AqualityServices.Browser.GoTo(ConfigClass.MainUrl);
        }

        [TearDown]
        public void CleanUp()
        {
            AqualityServices.Browser.Quit();
        }
    }
}

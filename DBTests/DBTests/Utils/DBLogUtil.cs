using Aquality.Selenium.Browsers;
using DBTests.Models;
using System.Collections.Generic;

namespace DBTests.Utils
{
    public static class DBLogUtil
    {
        public static void MinWorkingLog(List<MinTimeTestModel> list)
        {
            AqualityServices.Logger.Info($"The minimum test execution time data table");
            AqualityServices.Logger.Info($"Project\t|Test\t|MinTime\t|");
            foreach (var test in list)
            {
                AqualityServices.Logger.Info($"{test.Project}\t|{test.Test}\t|{test.MinTime}\t|");
            }
        }

        public static void NumberOfUniqueLog(List<NumberOfUniqueTests> list)
        {
            AqualityServices.Logger.Info($"The number of unique tests on the projects data table");
            AqualityServices.Logger.Info($"Project\t|TestsCount\t|");
            foreach (var test in list)
            {
                AqualityServices.Logger.Info($"{test.Project}\t|{test.TestsCount}\t|");
            }
        }

        public static void DateConditionLog(List<DateConditionModel> list)
        {
            AqualityServices.Logger.Info($"The date conditions tests data table");
            AqualityServices.Logger.Info($"Project\t|Test\t|Date\t|");
            foreach (var test in list)
            {
                AqualityServices.Logger.Info($"{test.Project}\t|{test.Test}\t|{test.Date}\t|");
            }
        }

        public static void BrowserCountLog(List<BrowserCountTestModel> list)
        {
            AqualityServices.Logger.Info($"The browsers count tests data table");
            AqualityServices.Logger.Info($"Brosers\t|");
            foreach (var test in list)
            {
                AqualityServices.Logger.Info($"{test.Brosers}\t|");
            }
        }
    }
}

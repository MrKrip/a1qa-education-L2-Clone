using DBTests.DBRequests;
using DBTests.Models;
using DBTests.Test_conditions;
using DBTests.Utils;
using NUnit.Framework;
using System.Collections.Generic;

namespace DBTests
{
    public class Tests : BaseTest
    {

        [Test]
        public void MinWorkingTime()
        {
            var MinWorkingTimeResp = dBRequests.GetMinWorkingTime();
            var MinWorkingTime = ParseJSON.GetDataFile<List<MinTimeTestModel>>(ConfigClass.MinTimeTestPath);
            Assert.IsTrue(CompareUtil.IsListsAreEqual(MinWorkingTimeResp, MinWorkingTime), "The minimum test execution time does not match the test data");
        }

        [Test]
        public void NumberOfUniqueTests()
        {
            var NumberOfUniqueResp = dBRequests.GetNumberOfUniqueTests();
            var NumberOfUnique = ParseJSON.GetDataFile<List<NumberOfUniqueTests>>(ConfigClass.TestCountPath);
            Assert.IsTrue(CompareUtil.IsListsAreEqual(NumberOfUniqueResp, NumberOfUnique), "The number of unique tests on the projects does not match the test data");
        }
    }
}
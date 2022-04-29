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
            TestsDBRequests dBRequests = new TestsDBRequests();
            var MinWorkingTimeResp = dBRequests.GetMinWorkingTime();
            var MinWorkingTime = ParseJSON.GetDataFile<List<MinTimeTestModel>>(ConfigClass.MinTimeTestPath);
            Assert.IsTrue(CompareUtil.IsListsAreEqual(MinWorkingTimeResp,MinWorkingTime), "Minimum run time for tests with test data");
        }
    }
}
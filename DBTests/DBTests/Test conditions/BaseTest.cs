using DBTests.DBRequests;
using NUnit.Framework;

namespace DBTests.Test_conditions
{
    public class BaseTest
    {
        protected TestsDBRequests dBRequests;
        [SetUp]
        public void Setup()
        {
            dBRequests = new TestsDBRequests();
        }
    }
}

using NUnit.Framework;
using REST_API_GET_POST.Utils;

namespace REST_API_GET_POST.Test_conditions
{
    public class BaseTest
    {

        [SetUp]
        public void Setup()
        {          
            ApiUtil.SetClient(ConfigClass.Config["MainUrl"]);
        }
    }
}

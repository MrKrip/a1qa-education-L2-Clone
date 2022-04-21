using NUnit.Framework;
using REST_API_GET_POST.ApiRequests;
using REST_API_GET_POST.Models;
using REST_API_GET_POST.Test_conditions;

namespace REST_API_GET_POST
{
    public class Tests : BaseTest
    {

        [Test]
        public void Test1()
        {
            ApiRequest apiRequest = new ApiRequest();
            PostModel post = new PostModel() { body = "123456",userId=1,id=101, title="sadfgnhmj,klkjhgfdsaxdfgrtf" };
            apiRequest.SendPost(post);
            Assert.Pass();
        }
    }
}
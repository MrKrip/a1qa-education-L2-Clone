using NUnit.Framework;
using SMART_VK_API.ApiRequests;
using SMART_VK_API.Models;
using SMART_VK_API.Pages;
using SMART_VK_API.Test_conditions;
using SMART_VK_API.Util;

namespace SMART_VK_API
{
    public class Tests : BaseTest
    {

        [Test]
        public void Test1()
        {
            UserModel user = ParseJSON.GetDataFile<UserModel>(ConfigClass.UserDataPath);
            WallPostModel wallPost = new WallPostModel() { access_token = user.Token, v = "5.131" };

            VkRequests vkRequests = new VkRequests();

            SignInPage signIn = new SignInPage();
            SideBar sideBar = new SideBar();
            ProfilePage profile = new ProfilePage();

            signIn.SignIn(user);
            sideBar.OpenMyPage();

            (var PostId, var StatusCode) = vkRequests.WallPost(wallPost);
            bool PostExist = profile.IsPostExist(user.Id, PostId);
            Assert.Pass();
        }
    }
}
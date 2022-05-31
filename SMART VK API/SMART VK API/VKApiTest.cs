using NUnit.Framework;
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

            SignInPage SignIn = new SignInPage();
            SideBar sideBar = new SideBar();
            
            SignIn.SignIn(user);
            sideBar.OpenMyPage();
            Assert.Pass();
        }
    }
}
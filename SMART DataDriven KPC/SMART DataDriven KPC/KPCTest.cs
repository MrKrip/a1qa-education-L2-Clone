using Ganss.Excel;
using NUnit.Framework;
using SMART_DataDriven_KPC.Models;
using SMART_DataDriven_KPC.Pages;
using SMART_DataDriven_KPC.Test_conditions;
using System.Collections.Generic;

namespace SMART_DataDriven_KPC
{
    public class Tests : BaseTest
    {

        [Test]
        [TestCaseSource("TestMails")]
        public void Test1(UserAccountModel model)
        {
            SignInPage signIn = new SignInPage();
            HeaderMenu headerMenu = new HeaderMenu();
            DownloadsPage downloadsPage = new DownloadsPage();

            signIn.SignIn(model);
            Assert.AreEqual(model.UserName, headerMenu.GetUserName(), "User nme are not equal");
            headerMenu.GoToDownloads();
            downloadsPage.PrepareToSendSelf(model);
            downloadsPage.GetEmailFromSendSelf();
            downloadsPage.SendSelf();
        }

        public static IEnumerable<UserAccountModel> TestMails()
        {
            var Mails = new ExcelMapper(ConfigClass.TestMails).Fetch<UserAccountModel>();
            foreach (var mail in Mails)
            {
                yield return mail;
            }
        }
    }
}
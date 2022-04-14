using AE.Net.Mail;
using Aquality.Selenium.Browsers;
using Ganss.Excel;
using NUnit.Framework;
using SMART_DataDriven_KPC.Models;
using SMART_DataDriven_KPC.Pages;
using SMART_DataDriven_KPC.Test_conditions;
using SMART_DataDriven_KPC.Util;
using System.Collections.Generic;
using System.Text;

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

            AqualityServices.Logger.Info("Checking if the Sign In page is open");
            Assert.IsTrue(signIn.State.IsDisplayed, "Sign In page is not open");
            AqualityServices.Logger.Info("Login to account");
            signIn.SignIn(model.UserName,model.Password);
            AqualityServices.Logger.Info("Waiting for when header is displayed");
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => headerMenu.State.IsDisplayed), "Header is not load");
            AqualityServices.Logger.Info("Checking if test User Name are equal to website User Name");
            Assert.AreEqual(model.UserName, headerMenu.GetUserName(), "User name are not equal");
            AqualityServices.Logger.Info("Go to the downloads page");
            headerMenu.GoToDownloads();
            AqualityServices.Logger.Info("Checking if the Downloads page is open");
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => downloadsPage.State.IsDisplayed), "Downloads page is not open");
            AqualityServices.Logger.Info("Choosing an OS");
            downloadsPage.ChooseOS(model.OS);
            AqualityServices.Logger.Info("Choosing an Product");
            downloadsPage.ChooseProduct(model.Product);
            AqualityServices.Logger.Info("Sending self email");
            downloadsPage.SendSelf();
            AqualityServices.Logger.Info("Checking if email is correct");
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => EmailUtil.EmailCheck(model.UserName, model.Password, model.Product)), "Didn't receive an email with a valid link");
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
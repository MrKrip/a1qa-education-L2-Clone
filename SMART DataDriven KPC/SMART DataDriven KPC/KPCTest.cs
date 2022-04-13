using AE.Net.Mail;
using Aquality.Selenium.Browsers;
using Ganss.Excel;
using NUnit.Framework;
using SMART_DataDriven_KPC.Models;
using SMART_DataDriven_KPC.Pages;
using SMART_DataDriven_KPC.Test_conditions;
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

            Assert.IsTrue(signIn.State.IsDisplayed, "Sign In page is not open");
            signIn.SignIn(model);
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => headerMenu.State.IsDisplayed), "Header is not load");
            Assert.AreEqual(model.UserName, headerMenu.GetUserName(), "User name are not equal");
            headerMenu.GoToDownloads();
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => downloadsPage.State.IsDisplayed), "Downloads page is not open");
            downloadsPage.PrepareToSendSelf(model);
            downloadsPage.GetEmailFromSendSelf();
            downloadsPage.SendSelf();
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => EmailCheck(model)), "Didn't receive an email with a valid link");
        }

        public static IEnumerable<UserAccountModel> TestMails()
        {
            var Mails = new ExcelMapper(ConfigClass.TestMails).Fetch<UserAccountModel>();
            foreach (var mail in Mails)
            {
                yield return mail;
            }
        }

        public static bool EmailCheck(UserAccountModel model)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ImapClient IC = new ImapClient("imap.gmail.com", model.UserName, model.Password, AuthMethods.Login, 993, true);
            IC.SelectMailbox("INBOX");
            var Email = IC.GetMessage(IC.GetMessageCount() - 1);
            return Email.Body.Contains(model.Product) && Email.Body.Contains("https://my.kaspersky.com/MyLicenses?startDownload=https");
        }
    }
}
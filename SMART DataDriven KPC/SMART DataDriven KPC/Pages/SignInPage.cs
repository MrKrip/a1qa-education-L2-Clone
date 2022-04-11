using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using SMART_DataDriven_KPC.Models;

namespace SMART_DataDriven_KPC.Pages
{
    public class SignInPage : Form
    {
        private IElement EmailTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[contains(@name,'email')]"), "Email text box");
        private IElement PasswordTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[contains(@name,'password')]"), "Password text box");
        private IElement SignInButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@data-omniture-cta-name='Sign in']"), "Sign in button");

        public SignInPage() : base(By.XPath("//*[contains(@class,'welcome-main')]"), "SignIn Page")
        {

        }

        public void SignIn(UserAccountModel model)
        {
            EmailTextBox.SendKeys(model.UserName);
            PasswordTextBox.SendKeys(model.Password);
            SignInButton.Click();
        }
    }
}

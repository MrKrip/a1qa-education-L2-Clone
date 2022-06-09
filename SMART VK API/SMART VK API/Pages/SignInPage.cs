using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using SMART_VK_API.Models;

namespace SMART_VK_API.Pages
{
    public class SignInPage : Form
    {
        private IElement SignInButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//Button[contains(@class,'signInButton')]"), "Sign in button");
        private IElement LoginInput = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@name='login']"), "Login input");
        private IElement LoginSubmitButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//form[contains(@class,'vkc__EnterLogin__content')]//button[@type='submit']"), "Login submit button");
        private IElement PasswordInput = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@name='password']"), "Password input");
        private IElement PasswordSubmitButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//form[contains(@class,'vkc__EnterPasswordNoUserInfo__content')]//button[@type='submit']"), "Password submit button");

        public SignInPage() : base(By.Id("index_login"), "SignIn Page")
        {

        }

        public void SignIn(UserModel user)
        {
            SignInButton.Click();
            LoginInput.SendKeys(user.Login);
            LoginSubmitButton.Click();
            PasswordInput.SendKeys(user.Password);
            PasswordSubmitButton.Click();
        }
    }
}

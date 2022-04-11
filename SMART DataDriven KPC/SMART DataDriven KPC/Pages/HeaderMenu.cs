using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;


namespace SMART_DataDriven_KPC.Pages
{
    public class HeaderMenu : Form
    {
        private IElement DownloadsLink = AqualityServices.Get<IElementFactory>().GetLink(By.XPath("//*[@data-at-menu='Downloads']"), "Downloads link");
        private IElement UserNameLabel = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//button[@data-at-selector='accountMenuTrigger']//span"), "User name label");

        public HeaderMenu() : base(By.Id("site-header"), "Category Menu")
        {

        }

        public string GetUserName()
        {
            return UserNameLabel.GetText();
        }

        public void GoToDownloads()
        {
            DownloadsLink.Click();
        }
    }
}

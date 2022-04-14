using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using SMART_DataDriven_KPC.Models;

namespace SMART_DataDriven_KPC.Pages
{
    public class DownloadsPage : Form
    {
        private IElement SendButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@data-at-selector='installerSendSelfBtn']"), "Send button");
        private IElement SendTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@data-at-selector='emailInput']"), "Send text box");

        public DownloadsPage() : base(By.Id("trialSoft"), "Downloads Page")
        {

        }

        public void ChooseOS(string OS)
        {
            IElement OsFilter = AqualityServices.Get<IElementFactory>().GetButton(By.XPath($"//div[contains(@class,'osFilter') and div[contains(.,'{OS}')]]"), "OS filter button");
            OsFilter.Click();
        }

        public void ChooseProduct(string Product)
        {
            IElement SendToMyselfButton = AqualityServices.Get<IElementFactory>()
                .GetButton(By.XPath($"//div[@data-at-selector='downloadApplicationCard' and div[contains(.,'{Product}')]]//button[@data-at-selector='appInfoSendToEmail']"), "Send to myself button");
            SendToMyselfButton.Click();
        }


        public void SendSelf()
        {
            SendButton.Click();
        }
    }
}

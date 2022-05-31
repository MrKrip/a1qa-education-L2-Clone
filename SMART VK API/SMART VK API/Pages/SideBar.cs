using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SMART_VK_API.Pages
{
    public class SideBar : Form
    {
        private IElement MyPageLink = AqualityServices.Get<IElementFactory>().GetLink(By.XPath("//*[@id='side_bar']//a[contains(@href,'/id')]"), "My page side bar link");

        public SideBar() : base(By.Id("side_bar"), "Side bar menu")
        {

        }

        public void OpenMyPage()
        {
            MyPageLink.Click();
        }
    }
}

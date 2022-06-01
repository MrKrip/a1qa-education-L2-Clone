using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_VK_API.Pages
{
    public class ProfilePage : Form
    {
        private IElement PostField = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id("post_field"), "Post field");

        public ProfilePage():base(By.Id("profile"),"Profile page")
        {

        }

        public bool IsCurrentUserProfile()
        {
            return PostField.State.IsExist;
        }

        public bool IsPostExist(int UserId,int PostId)
        {
            IElement Post = AqualityServices.Get<IElementFactory>().GetLabel(By.Id($"post{UserId}_{PostId}"), $"Post {PostId} from {UserId} user");
            return Post.State.WaitForExist();
        }
    }
}

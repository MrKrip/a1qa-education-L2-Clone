using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using SMART_VK_API.Models;
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

        public ProfilePage() : base(By.Id("profile"), "Profile page")
        {

        }

        public bool IsCurrentUserProfile()
        {
            return PostField.State.IsExist;
        }

        public bool IsPostExist(int UserId, int PostId)
        {
            IElement Post = AqualityServices.Get<IElementFactory>().GetLabel(By.Id($"post{UserId}_{PostId}"), $"Post {PostId} from {UserId} user");
            return Post.State.WaitForExist();
        }

        public (bool, bool) IsPostEdit(int UserId, int PostId, int PhotoId, string message)
        {
            IElement Post = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath($"//*[@id='post{UserId}_{PostId}']//*[contains(@class,'wall_post_text')]"), $"Post {PostId} from {UserId} user");
            IElement Photo = AqualityServices.Get<IElementFactory>().GetLink(By.XPath($"//*[@id='post{UserId}_{PostId}']//*[contains(@href,'photo{UserId}_{PhotoId}')]"), $"Photo {PhotoId} in {PostId} post");
            Post.State.WaitForDisplayed();
            return (Photo.State.WaitForExist(), message != Post.Text.ToString());
        }

        public bool IsCommentAdded(CommentModel Comment, int PostId, int UserId)
        {
            IElement ShowNewCommentButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath($"//*[@id='replies{UserId}_{PostId}']//a"), "Show new comment button");
            IElement NewComment = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath($"//*[@id='replies{UserId}_{PostId}']//*[@id='post{UserId}_{Comment.comment_id}']"), "");
            ShowNewCommentButton.State.WaitForClickable();
            ShowNewCommentButton.Click();
            return NewComment.State.WaitForExist();
        }
    }
}

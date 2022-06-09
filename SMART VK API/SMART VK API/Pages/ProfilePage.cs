using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using SMART_VK_API.Models;

namespace SMART_VK_API.Pages
{
    public class ProfilePage : Form
    {
        private ITextBox PostField = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id("post_field"), "Post field");
        private IButton ShowNewCommentButton(int UserId, int PostId) => AqualityServices.Get<IElementFactory>().GetButton(By.XPath($"//*[@id='replies{UserId}_{PostId}']//a"), "Show new comment button");
        private ILabel Post(int UserId, int PostId) => AqualityServices.Get<IElementFactory>().GetLabel(By.Id($"post{UserId}_{PostId}"), $"Post {PostId} from {UserId} user");
        private ILabel PostText(int UserId, int PostId) => AqualityServices.Get<IElementFactory>().GetLabel(By.XPath($"//*[@id='post{UserId}_{PostId}']//*[contains(@class,'wall_post_text')]"), $"Post {PostId} from {UserId} user");
        private ILink PostPhoto(int UserId, int PostId, int PhotoId) => AqualityServices.Get<IElementFactory>().GetLink(By.XPath($"//*[@id='post{UserId}_{PostId}']//*[contains(@href,'photo{UserId}_{PhotoId}')]"), $"Photo {PhotoId} in {PostId} post");
        private ILabel NewComment(int UserId, int PostId, CommentModel Comment) => AqualityServices.Get<IElementFactory>().GetLabel(By.XPath($"//*[@id='replies{UserId}_{PostId}']//*[@id='post{UserId}_{Comment.comment_id}']"), "");
        private IButton LikeButton(int UserId, int PostId) => AqualityServices.Get<IElementFactory>().GetButton(By.XPath($"//*[@id='post{UserId}_{PostId}']//div[contains(@class,'PostButtonReactionsContainer')]"), $"Like button for post{UserId}_{PostId}");

        public ProfilePage() : base(By.Id("profile"), "Profile page")
        {

        }

        public bool IsCurrentUserProfile()
        {
            return PostField.State.IsExist;
        }

        public bool IsPostExist(int UserId, int PostId)
        {
            return Post(UserId, PostId).State.WaitForExist();
        }

        public bool IsPostNotExist(int UserId, int PostId)
        {
            return Post(UserId, PostId).State.WaitForNotDisplayed();
        }

        public (bool, bool) IsPostEdit(int UserId, int PostId, int PhotoId, string message)
        {
            PostText(UserId, PostId).State.WaitForDisplayed();
            return (PostPhoto(UserId, PostId, PhotoId).State.WaitForExist(), message != PostText(UserId, PostId).Text.ToString());
        }

        public bool IsCommentAdded(CommentModel Comment, int PostId, int UserId)
        {
            ShowNewCommentButton(UserId, PostId).State.WaitForClickable();
            ShowNewCommentButton(UserId, PostId).Click();
            return NewComment(UserId, PostId, Comment).State.WaitForExist();
        }

        public void AddLikeToPost(int PostId, int UserId)
        {
            LikeButton(UserId, PostId).Click();
        }
    }
}

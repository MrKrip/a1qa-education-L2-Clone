using Aquality.Selenium.Browsers;
using NUnit.Framework;
using SMART_VK_API.ApiRequests;
using SMART_VK_API.Models;
using SMART_VK_API.Pages;
using SMART_VK_API.Test_conditions;
using SMART_VK_API.Util;

namespace SMART_VK_API
{
    public class Tests : BaseTest
    {

        [Test]
        public void Test1()
        {
            UserModel user = ParseJSON.GetDataFile<UserModel>(ConfigClass.UserDataPath);
            WallPostModel wallPost = new WallPostModel() { access_token = user.Token, v = ConfigClass.Config["ApiVersion"] };

            VkRequests vkRequests = new VkRequests();

            SignInPage signIn = new SignInPage();
            SideBar sideBar = new SideBar();
            ProfilePage profile = new ProfilePage();

            AqualityServices.Logger.Info($"Authorization");
            signIn.SignIn(user);

            AqualityServices.Logger.Info($"Opening {user.Id} profile page");
            sideBar.OpenMyPage();

            AqualityServices.Logger.Info($"Creating post with randomly generated text");
            (var PostId, var StatusCode) = vkRequests.WallPost(ref wallPost);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");

            AqualityServices.Logger.Info($"Checking if there is a post on the wall");
            bool PostExist = profile.IsPostExist(user.Id, PostId);
            Assert.IsTrue(PostExist, "Post is not exist");

            AqualityServices.Logger.Info($"Getting upload server for photo");
            (var UploadServer, StatusCode) = vkRequests.GetUploadServer(user);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");

            AqualityServices.Logger.Info($"Upload photo");
            (var PhotoInfo, StatusCode) = vkRequests.UploadPhoto(UploadServer);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");

            AqualityServices.Logger.Info($"Saving photo");
            (var SaveFotoResp, StatusCode) = vkRequests.SavePhoto(user, PhotoInfo);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");

            AqualityServices.Logger.Info($"Editing post");
            (var PostIdSecond, StatusCode) = vkRequests.WallEdit(PostId, user, SaveFotoResp.response[0]);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            Assert.AreEqual(PostId, PostIdSecond, "Posts id are not equals");

            AqualityServices.Logger.Info($"Cheking if post edited");
            (var PhotoExist, var MessageChange) = profile.IsPostEdit(user.Id, PostIdSecond, SaveFotoResp.response[0].id, wallPost.message);
            Assert.IsTrue(PhotoExist,"Photo not added to post");
            Assert.IsTrue(MessageChange, "Messane not changed");

            AqualityServices.Logger.Info($"Creating comment");
            (var Comment, StatusCode) = vkRequests.CreateComment(PostId, user);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");

            AqualityServices.Logger.Info($"Cheking if comment created");
            var ComentAdded = profile.IsCommentAdded(Comment, PostIdSecond, user.Id);
            Assert.IsTrue(ComentAdded, "Comment not added");

            AqualityServices.Logger.Info($"Adding like to {PostId} post");
            profile.AddLikeToPost(PostIdSecond, user.Id);

            AqualityServices.Logger.Info($"Cheking if like added");
            (var Liked, StatusCode) = vkRequests.IsLiked(PostIdSecond, user);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            Assert.AreEqual(1, Liked.liked, "The post has no like");

            AqualityServices.Logger.Info($"Cheking if like added");
            (var Deleted, StatusCode) = vkRequests.DeletePost(PostIdSecond, user);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            Assert.AreEqual(1, Deleted, "Post not deleted");

            AqualityServices.Logger.Info($"Cheking if post exist");
            PostExist = profile.IsPostNotExist(user.Id, PostId);
            Assert.IsTrue(PostExist,"Post still exist");
        }
    }
}
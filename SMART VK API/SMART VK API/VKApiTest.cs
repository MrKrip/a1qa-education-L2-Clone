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

            signIn.SignIn(user);
            sideBar.OpenMyPage();

            (var PostId, var StatusCode) = vkRequests.WallPost(ref wallPost);
            bool PostExist = profile.IsPostExist(user.Id, PostId);

            (var UploadServer, StatusCode) = vkRequests.GetUploadServer(user);
            (var PhotoInfo, StatusCode) = vkRequests.UploadPhoto(UploadServer);
            (var SaveFotoResp, StatusCode) = vkRequests.SavePhoto(user, PhotoInfo);
            (var PostIdSecond, StatusCode) = vkRequests.WallEdit(PostId, user, SaveFotoResp.response[0]);

            (var PhotoExist, var MessageChange) = profile.IsPostEdit(user.Id, PostIdSecond, SaveFotoResp.response[0].id, wallPost.message);
            (var Comment, StatusCode) = vkRequests.CreateComment(PostId, user);

            var ComentAdded = profile.IsCommentAdded(Comment, PostIdSecond, user.Id);
            profile.AddLikeToPost(PostIdSecond, user.Id);

            (var Liked, StatusCode) = vkRequests.IsLiked(PostIdSecond, user);
            (var Deleted, StatusCode) = vkRequests.DeletePost(PostIdSecond, user);
            PostExist = profile.IsPostExist(user.Id, PostId);
            Assert.Pass();
        }
    }
}
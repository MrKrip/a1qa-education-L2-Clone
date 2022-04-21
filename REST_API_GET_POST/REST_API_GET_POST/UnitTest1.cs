using Aquality.Selenium.Browsers;
using NUnit.Framework;
using REST_API_GET_POST.ApiRequests;
using REST_API_GET_POST.Models;
using REST_API_GET_POST.Test_conditions;
using REST_API_GET_POST.Utils;
using System.Collections.Generic;

namespace REST_API_GET_POST
{
    public class Tests : BaseTest
    {

        [Test]
        public void Test1()
        {
            ApiRequest apiRequest = new ApiRequest();
            (var ListOfAllPotsResp, var PostsStatusCode) = apiRequest.GetAllPostsRequest();
            var ListOfAllPots = ParseJSON.GetDataFile<List<PostModel>>(ConfigClass.AllPostsPath);
            AqualityServices.Logger.Info($"Checking 'All Posts' GET response status code");
            Assert.AreEqual(PostsStatusCode, "OK", "Status code is not 200.");
            Assert.IsTrue(CompareUtil.IsListsOfPostsAreEqual(ListOfAllPots, ListOfAllPotsResp), "List from 'All posts' GET request returns wrong result");
            Assert.IsTrue(CompareUtil.IsListOfPostsAreSorted(ListOfAllPotsResp), "Posts are not sorted ascending (by id).");

            (var DefinitePost, var PostStatusCode) = apiRequest.GetDefinitePostRequest();
            var PostExample = ParseJSON.GetDataFile<PostModel>(ConfigClass.DefinitePostPath);
            AqualityServices.Logger.Info($"Checking 'Definite post' GET response status code");
            Assert.AreEqual(PostStatusCode, "OK", "Status code is not 200.");
            AqualityServices.Logger.Info($"Checking the message id from the GET response 'Definite post'");
            Assert.AreEqual(PostExample.id, DefinitePost.id, "ID doesn't match");
            AqualityServices.Logger.Info($"Checking the message userId from the GET response 'Definite post'");
            Assert.AreEqual(PostExample.userId, DefinitePost.userId, "UserID doesn't match");
            AqualityServices.Logger.Info($"Checking if the message title from the GET response 'Definite post' is not empty");
            Assert.AreNotEqual(DefinitePost.title, string.Empty, "Title is empty");
            AqualityServices.Logger.Info($"Checking if the message body from the GET response 'Definite post' is not empty");
            Assert.AreNotEqual(DefinitePost.body, string.Empty, "Body is empty");

            (var NonExistentPost, var NonExistentPostStatusCode) = apiRequest.GetNonExistentPostRequest();
            AqualityServices.Logger.Info($"Checking 'Non-Existent post' GET response status code");
            Assert.AreEqual(NonExistentPostStatusCode, "NotFound", "Status code is not 404.");
            Assert.IsTrue(NonExistentPost.IsEmpty(), "Response body is not empty.");

            var NewPost = ParseJSON.GetDataFile<PostModel>(ConfigClass.NewPostPath);
            (var NewPostResponse, var NewPostStatusCode) = apiRequest.SendPostRequest(NewPost);
            AqualityServices.Logger.Info($"Checking 'New post' POST response status code");
            Assert.AreEqual(NewPostStatusCode, "Created", "Status code is not 201.");
            Assert.IsTrue(NewPost.ArePostsEqual(NewPostResponse), "Post information is not correct");

            var DefiniteUser = ParseJSON.GetDataFile<UserModel>(ConfigClass.DefiniteUserPath);
            (var AllUsers, var AllUsersStatusCode) = apiRequest.GetAllUersRequest();
            AqualityServices.Logger.Info($"Checking 'All Users' GET response status code");
            Assert.AreEqual(AllUsersStatusCode, "OK", "Status code is not 200.");
            Assert.IsTrue(CompareUtil.IsUserConsistInList(AllUsers, DefiniteUser), "Definite User is not contains in All Users response list");

            (var DefiniteUserResponde, var DefiniteUserStatusCode) = apiRequest.GetDefiniteUserRequest();
            AqualityServices.Logger.Info($"Checking 'Definite User' GET response status code");
            Assert.AreEqual(DefiniteUserStatusCode, "OK", "Status code is not 200.");
            Assert.IsTrue(DefiniteUser.AreUsersEqual(DefiniteUserResponde), "DefiniteUser doesn't match with DefiniteUser from respond");
        }
    }
}
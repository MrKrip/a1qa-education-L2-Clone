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
            var assertsAccumulator = new AssertsAccumulator();
            ApiRequest apiRequest = new ApiRequest();


            (var ListOfAllPotsResp, var PostsStatusCode) = apiRequest.GetAllPostsRequest();
            var ListOfAllPots = ParseJSON.GetDataFile<List<PostModel>>(ConfigClass.AllPostsPath);
            AqualityServices.Logger.Info($"Checking 'All Posts' GET response status code");
            assertsAccumulator.Accumulate(() => Assert.AreEqual(PostsStatusCode, "OK", "Status code is not 200."));
            assertsAccumulator.Accumulate(() => Assert.IsTrue(CompareUtil.IsListsOfPostsAreEqual(ListOfAllPots, ListOfAllPotsResp), "List from 'All posts' GET request returns wrong result"));
            assertsAccumulator.Accumulate(() => Assert.IsTrue(CompareUtil.IsListOfPostsAreSorted(ListOfAllPotsResp), "Posts are not sorted ascending (by id)."));

            (var DefinitePost, var PostStatusCode) = apiRequest.GetDefinitePostRequest(99);
            var PostExample = ParseJSON.GetDataFile<PostModel>(ConfigClass.DefinitePostPath);
            AqualityServices.Logger.Info($"Checking 'Definite post' GET response status code");
            assertsAccumulator.Accumulate(() => Assert.AreEqual(PostStatusCode, "OK", "Status code is not 200."));
            AqualityServices.Logger.Info($"Checking the message id from the GET response 'Definite post'");
            assertsAccumulator.Accumulate(() => Assert.AreEqual(PostExample.id, DefinitePost.id, "ID doesn't match"));
            AqualityServices.Logger.Info($"Checking the message userId from the GET response 'Definite post'");
            assertsAccumulator.Accumulate(() => Assert.AreEqual(PostExample.userId, DefinitePost.userId, "UserID doesn't match"));
            AqualityServices.Logger.Info($"Checking if the message title from the GET response 'Definite post' is not empty");
            assertsAccumulator.Accumulate(() => Assert.AreNotEqual(DefinitePost.title, string.Empty, "Title is empty"));
            AqualityServices.Logger.Info($"Checking if the message body from the GET response 'Definite post' is not empty");
            assertsAccumulator.Accumulate(() => Assert.AreNotEqual(DefinitePost.body, string.Empty, "Body is empty"));


            (var NonExistentPost, var NonExistentPostStatusCode) = apiRequest.GetDefinitePostRequest(150);
            AqualityServices.Logger.Info($"Checking 'Non-Existent post' GET response status code");
            assertsAccumulator.Accumulate(() => Assert.AreEqual(NonExistentPostStatusCode, "NotFound", "Status code is not 404."));
            assertsAccumulator.Accumulate(() => Assert.IsTrue(NonExistentPost.IsEmpty(), "Response body is not empty."));

            var NewPost = ParseJSON.GetDataFile<PostModel>(ConfigClass.NewPostPath);
            (var NewPostResponse, var NewPostStatusCode) = apiRequest.SendPostRequest(NewPost);
            AqualityServices.Logger.Info($"Checking 'New post' POST response status code");
            assertsAccumulator.Accumulate(() => Assert.AreEqual(NewPostStatusCode, "Created", "Status code is not 201."));
            assertsAccumulator.Accumulate(() => Assert.IsTrue(NewPost.Equals(NewPostResponse), "Post information is not correct"));

            var DefiniteUser = ParseJSON.GetDataFile<UserModel>(ConfigClass.DefiniteUserPath);
            (var AllUsers, var AllUsersStatusCode) = apiRequest.GetAllUersRequest();
            AqualityServices.Logger.Info($"Checking 'All Users' GET response status code");
            assertsAccumulator.Accumulate(() => Assert.AreEqual(AllUsersStatusCode, "OK", "Status code is not 200."));
            assertsAccumulator.Accumulate(() => Assert.IsTrue(CompareUtil.IsUserConsistInList(AllUsers, DefiniteUser), "Definite User is not contains in All Users response list"));


            (var DefiniteUserResponde, var DefiniteUserStatusCode) = apiRequest.GetDefiniteUserRequest(5);
            AqualityServices.Logger.Info($"Checking 'Definite User' GET response status code");
            assertsAccumulator.Accumulate(() => Assert.AreEqual(DefiniteUserStatusCode, "OK", "Status code is not 200."));
            assertsAccumulator.Accumulate(() => Assert.IsTrue(DefiniteUser.Equals(DefiniteUserResponde), "DefiniteUser doesn't match with DefiniteUser from respond"));
        }
    }
}
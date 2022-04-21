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
            Assert.AreEqual(PostsStatusCode, "OK", "Status code is not 200.");
            Assert.IsTrue(CompareUtil.IsListsOfPostsAreEqual(ListOfAllPots, ListOfAllPotsResp), "List from 'All posts' GET request returns wrong result");
            Assert.IsTrue(CompareUtil.IsListOfPostsAreSorted(ListOfAllPotsResp), "Posts are not sorted ascending (by id).");

            (var DefinitePost, var PostStatusCode) = apiRequest.GetDefinitePostRequest();
            var PostExample = ParseJSON.GetDataFile<PostModel>(ConfigClass.DefinitePostPath);
            Assert.AreEqual(PostStatusCode, "OK", "Status code is not 200.");
            Assert.AreEqual(PostExample.id, DefinitePost.id, "ID doesn't match");
            Assert.AreEqual(PostExample.userId, DefinitePost.userId, "UserID doesn't match");
            Assert.AreNotEqual(DefinitePost.title, string.Empty, "Title is empty");
            Assert.AreNotEqual(DefinitePost.body, string.Empty, "Body is empty");

            (var NonExistentPost, var NonExistentPostStatusCode) = apiRequest.GetNonExistentPostRequest();
            Assert.AreEqual(NonExistentPostStatusCode, "NotFound", "Status code is not 404.");
            Assert.IsTrue(NonExistentPost.IsEmpty(), "Response body is not empty.");

            var NewPost = ParseJSON.GetDataFile<PostModel>(ConfigClass.NewPostPath);
            (var NewPostResponse, var NewPostStatusCode) = apiRequest.SendPostRequest(NewPost);
            Assert.AreEqual(NewPostStatusCode, "Created", "Status code is not 201.");
            Assert.IsTrue(NewPost.ArePostsEqual(NewPostResponse), "Post information is not correct");

            var DefiniteUser= ParseJSON.GetDataFile<UserModel>(ConfigClass.DefiniteUserPath);
            (var AllUsers, var AllUsersStatusCode) = apiRequest.GetAllUersRequest();
            Assert.AreEqual(AllUsersStatusCode, "OK", "Status code is not 200.");
            Assert.IsTrue(CompareUtil.IsUserConsistInList(AllUsers,DefiniteUser), "Definite User is not contains in All Users response list");

            (var DefiniteUserResponde, var DefiniteUserStatusCode) = apiRequest.GetDefiniteUserRequest();
            Assert.AreEqual(DefiniteUserStatusCode, "OK", "Status code is not 200.");
            Assert.IsTrue(DefiniteUser.AreUsersEqual(DefiniteUserResponde), "DefiniteUser doesn't match with DefiniteUser from respond");
        }
    }
}
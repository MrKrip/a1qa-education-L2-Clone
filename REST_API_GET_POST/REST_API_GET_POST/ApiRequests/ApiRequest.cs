using REST_API_GET_POST.Models;
using REST_API_GET_POST.Utils;
using System.Collections.Generic;

namespace REST_API_GET_POST.ApiRequests
{
    public class ApiRequest
    {
        public (List<PostModel>, string) GetAllPostsRequest()
        {
            (var ListOfAllPost, var StatusCode) = ApiUtil.GetRequest<List<PostModel>>(ConfigClass.Config["AllPosts"]);
            return (ListOfAllPost, StatusCode);
        }

        public (PostModel, string) GetDefinitePostRequest(int id)
        {
            (var DefinitePost, var StatusCode) = ApiUtil.GetRequest<PostModel>(ConfigClass.Config["AllPosts"]+$"/{id}");
            return (DefinitePost, StatusCode);
        }


        public (PostModel, string) SendPostRequest(PostModel post)
        {
            (var SendPost, var StatusCode) = ApiUtil.PostRequest<PostModel>(ConfigClass.Config["SendPost"], post);
            return (SendPost, StatusCode);
        }

        public (List<UserModel>, string) GetAllUersRequest()
        {
            (var ListOfAllUsers, var StatusCode) = ApiUtil.GetRequest<List<UserModel>>(ConfigClass.Config["AllUsers"]);
            return (ListOfAllUsers, StatusCode);
        }

        public (UserModel,string) GetDefiniteUserRequest(int id)
        {
            (var DefiniteUser, var StatusCode) = ApiUtil.GetRequest<UserModel>(ConfigClass.Config["AllUsers"]+$"/{id}");
            return (DefiniteUser, StatusCode);
        }
}
}

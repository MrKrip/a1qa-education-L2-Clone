using REST_API_GET_POST.Models;
using REST_API_GET_POST.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_API_GET_POST.ApiRequests
{
    public class ApiRequest
    {
        public (List<PostModel>, string) GetAllPostsRequest()
        {
            (var ListOfAllPost, var StatusCode) = ApiUtil.GetRequest<List<PostModel>>(ConfigClass.Config["AllPosts"]);
            return (ListOfAllPost, StatusCode);
        }

        public (PostModel, string) GetUserDefiniteRequest()
        {
            (var DefinitePost, var StatusCode) = ApiUtil.GetRequest<PostModel>(ConfigClass.Config["DefinitePost"]);
            return (DefinitePost, StatusCode);
        }

        public (PostModel, string) GetNonExistentPost()
        {
            (var NonExistentPost, var StatusCode) = ApiUtil.GetRequest<PostModel>(ConfigClass.Config["Non-existentPost"]);
            return (NonExistentPost, StatusCode);
        }

        public (PostModel, string) SendPost(PostModel post)
        {
            (var SendPost, var StatusCode) = ApiUtil.PostRequest<PostModel>(ConfigClass.Config["SendPost"],post);
            return (SendPost, StatusCode);
        }


    }
}

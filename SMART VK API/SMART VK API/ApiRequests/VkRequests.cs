using SMART_VK_API.Models;
using SMART_VK_API.Util;

namespace SMART_VK_API.ApiRequests
{
    public class VkRequests
    {
        public (int, string) WallPost(ref WallPostModel model)
        {
            model.message = TextGenerator.GenerteText();
            (var Response, var StatusCode) = ApiUtils.PostRequest<RespModel<WallPostRespModel>>($"{ConfigClass.Config["WallPost"]}?message={model.message}&access_token={model.access_token}&v={model.v}");
            return (Response.response.post_id, StatusCode);
        }

        public (RespModel<WallUplServRespModel>, string) GetUploadServer(UserModel user)
        {
            (var Response, var StatusCode) = ApiUtils.PostRequest<RespModel<WallUplServRespModel>>($"{ConfigClass.Config["UplServer"]}?group_id={user.Id}&access_token={user.Token}&v={ConfigClass.Config["ApiVersion"]}");
            return (Response, StatusCode);
        }

        public (UploadPhotoModel, string) UploadPhoto(RespModel<WallUplServRespModel> model)
        {
            (var Response, var StatusCode) = ApiUtils.PostRequest<UploadPhotoModel>(model.response.upload_url, ConfigClass.Config["PhotoParameterName"], ConfigClass.PhotoPath, ConfigClass.Config["PhotoContentType"]);
            return (Response, StatusCode);
        }

        public (RespModel<List<SavePhotoModel>>, string) SavePhoto(UserModel user, UploadPhotoModel photo)
        {
            (var Response, var StatusCode) = ApiUtils.PostRequest<RespModel<List<SavePhotoModel>>>($"{ConfigClass.Config["SavePhoto"]}?user_id={user.Id}&group_id={user.Id}&photo={photo.photo}&server={photo.server}&hash={photo.hash}&access_token={user.Token}&v={ConfigClass.Config["ApiVersion"]}");
            return (Response, StatusCode);
        }

        public (int, string) WallEdit(int postId, UserModel user, SavePhotoModel photo)
        {
            (var Response, var StatusCode) = ApiUtils.PostRequest<RespModel<WallPostRespModel>>($"{ConfigClass.Config["WallEdit"]}?post_id={postId}&message={TextGenerator.GenerteText()}&attachments=photo{user.Id}_{photo.id}&access_token={user.Token}&v={ConfigClass.Config["ApiVersion"]}");
            return (Response.response.post_id, StatusCode);
        }

        public (CommentModel, string) CreateComment(int postId, UserModel user)
        {
            (var Response, var StatusCode) = ApiUtils.PostRequest<RespModel<CommentModel>>($"{ConfigClass.Config["CreateComment"]}?post_id={postId}&message={TextGenerator.GenerteText()}&access_token={user.Token}&v={ConfigClass.Config["ApiVersion"]}");
            return (Response.response, StatusCode);
        }

        public (LikeModel,string) IsLiked(int postId, UserModel user)
        {
            (var Response, var StatusCode) = ApiUtils.PostRequest<RespModel<LikeModel>>($"{ConfigClass.Config["IsLiked"]}?type=post&item_id={postId}&access_token={user.Token}&v={ConfigClass.Config["ApiVersion"]}");
            return (Response.response, StatusCode);
        }

        public (int,string) DeletePost(int postId,UserModel user)
        {
            (var Response, var StatusCode) = ApiUtils.PostRequest<RespModel<int>>($"{ConfigClass.Config["PostDelete"]}?post_id={postId}&access_token={user.Token}&v={ConfigClass.Config["ApiVersion"]}");
            return (Response.response, StatusCode);
        }
    }
}

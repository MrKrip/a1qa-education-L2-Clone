using SMART_VK_API.Models;
using SMART_VK_API.Util;

namespace SMART_VK_API.ApiRequests
{
    public class VkRequests
    {
        public (int, string) WallPost(WallPostModel model)
        {            
            model.message = TextGenerator.GenerteText();
            (var Response, var StatusCode) = ApiUtils.PostRequest<WallRespModel>($"/wall.post?message={model.message}&access_token={model.access_token}&v={model.v}");
            return (Response.response.post_id, StatusCode);
        }
    }
}

using Aquality.Selenium.Browsers;

namespace REST_API_GET_POST.Models
{
    public class PostModel
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public bool ArePostsEqual(PostModel post)
        {
            AqualityServices.Logger.Info($"Posts match check");
            return (id == post.id) && (userId == post.userId) && (title == post.title) && (body == post.body);
        }

        public bool IsEmpty()
        {
            AqualityServices.Logger.Info($"Checking if post is empty");
            return body == null && title == null && id == 0 && userId == 0;
        }
    }
}

using Aquality.Selenium.Browsers;
using System;

namespace REST_API_GET_POST.Models
{
    public class PostModel : IEquatable<PostModel>
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PostModel);
        }

        public bool Equals(PostModel other)
        {
            AqualityServices.Logger.Info($"Posts match check");
            return other != null &&
                   userId == other.userId &&
                   id == other.id &&
                   title == other.title &&
                   body == other.body;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(userId, id, title, body);
        }

        public bool IsEmpty()
        {
            AqualityServices.Logger.Info($"Checking if post is empty");
            return body == null && title == null && id == 0 && userId == 0;
        }
    }
}

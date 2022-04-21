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
            return (id == post.id) && (userId == post.userId) && (title == post.title) && (body == post.body);
        }

        public bool IsEmpty()
        {
            return body == null && title == null && id == 0 && userId == 0;
        }
    }
}

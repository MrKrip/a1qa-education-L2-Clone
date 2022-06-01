namespace SMART_VK_API.Models
{
    public class WallPostModel
    {
        public string? message { get; set; }
        public string access_token { get; set; } = null!;
        public string v { get; set; } = null!;
    }
}

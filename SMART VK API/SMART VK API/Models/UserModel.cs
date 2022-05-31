namespace SMART_VK_API.Models
{
    public class UserModel
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Token { get; set; }
    }
}

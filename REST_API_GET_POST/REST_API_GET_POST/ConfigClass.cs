using REST_API_GET_POST.Utils;
using System.Collections.Generic;
using System.IO;

namespace REST_API_GET_POST
{
    public class ConfigClass
    {
        public static readonly string DefaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly Dictionary<string, string> Config = ParseJSON.GetConfigFile(DefaultPath + @"\Resources\Config.json");
        public static readonly string AllPostsPath = DefaultPath + @"\Resources\AllPosts.json";
        public static readonly string AllUsersPath = DefaultPath + @"\Resources\AllUsers.json";
        public static readonly string DefinitePostPath = DefaultPath + @"\Resources\DefinitePost.json";
        public static readonly string DefiniteUserPath = DefaultPath + @"\Resources\DefiniteUser.json";
        public static readonly string NewPostPath = DefaultPath + @"\Resources\NewPost.json";
    }
}

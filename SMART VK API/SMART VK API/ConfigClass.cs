namespace SMART_VK_API
{
    public static class ConfigClass
    {
        public static readonly string DefaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly string ConfigPath = DefaultPath + @"\Resources\config.json";
        public static readonly string UserDataPath = DefaultPath + @"\Resources\User.json";
    }
}

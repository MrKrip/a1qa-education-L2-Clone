using System.IO;

namespace SMART_DataDriven_KPC
{
    public static class ConfigClass
    {
        public static readonly string DefaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly string TestMails = DefaultPath + @"\Resources\TestMails.xlsx";
        public static readonly string ConfigPath= DefaultPath + @"\Resources\config.json";
    }
}

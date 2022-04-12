using System.IO;

namespace SMART_DataDriven_KPC
{
    public static class ConfigClass
    {
        public const string MainUrl = "https://my.kaspersky.com/";
        public static readonly string DefaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly string TestMails = DefaultPath + @"\Resources\TestMails.xlsx";
    }
}

using AE.Net.Mail;
using System.Text;

namespace SMART_DataDriven_KPC.Util
{
    class EmailUtil
    {
        public static bool EmailCheck(string UserName,string Password,string Product)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ImapClient IC = new ImapClient("imap.gmail.com", UserName, Password, AuthMethods.Login, 993, true);
            IC.SelectMailbox("INBOX");
            var Email = IC.GetMessage(IC.GetMessageCount() - 1);
            return Email.Body.Contains(Product) && Email.Body.Contains("https://my.kaspersky.com/MyLicenses?startDownload=https");
        }
    }
}

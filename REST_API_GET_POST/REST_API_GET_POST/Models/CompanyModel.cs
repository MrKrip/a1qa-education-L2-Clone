using Aquality.Selenium.Browsers;

namespace REST_API_GET_POST.Models
{
    public class CompanyModel
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }

        public bool AreCompanysEqual(CompanyModel company)
        {
            AqualityServices.Logger.Info($"Company match check");
            return name == company.name && catchPhrase == company.catchPhrase && bs == company.bs;
        }
    }
}

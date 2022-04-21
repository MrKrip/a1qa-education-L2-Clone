using Aquality.Selenium.Browsers;

namespace REST_API_GET_POST.Models
{
    public class UserModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public AddressModel address{get;set;}
        public string phone { get; set; }
        public string website { get; set; }
        public CompanyModel company { get; set; }

        public bool AreUsersEqual(UserModel user)
        {
            AqualityServices.Logger.Info($"Users match check");
            return address.AreAddressEqual(user.address) && company.AreCompanysEqual(user.company) && id == user.id && username == user.username && email == user.email && phone == user.phone && website == user.website;
        }
    }
}

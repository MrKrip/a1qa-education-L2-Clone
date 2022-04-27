using Aquality.Selenium.Browsers;
using System;

namespace REST_API_GET_POST.Models
{
    public class UserModel : IEquatable<UserModel>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public AddressModel address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public CompanyModel company { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as UserModel);
        }

        public bool Equals(UserModel other)
        {
            AqualityServices.Logger.Info($"Users match check");
            return other != null &&
                   id == other.id &&
                   name == other.name &&
                   username == other.username &&
                   email == other.email &&
                   address.Equals(other.address) &&
                   phone == other.phone &&
                   website == other.website &&
                   company.Equals(other.company);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, name, username, email, address, phone, website, company);
        }
    }
}

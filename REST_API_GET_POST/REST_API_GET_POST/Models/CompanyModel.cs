using Aquality.Selenium.Browsers;
using System;

namespace REST_API_GET_POST.Models
{
    public class CompanyModel : IEquatable<CompanyModel>
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as CompanyModel);
        }

        public bool Equals(CompanyModel other)
        {
            AqualityServices.Logger.Info($"Company match check");
            return other != null &&
                   name == other.name &&
                   catchPhrase == other.catchPhrase &&
                   bs == other.bs;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, catchPhrase, bs);
        }
    }
}

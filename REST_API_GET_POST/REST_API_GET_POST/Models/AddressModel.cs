using Aquality.Selenium.Browsers;
using System;
using System.Collections.Generic;

namespace REST_API_GET_POST.Models
{
    public class AddressModel : IEquatable<AddressModel>
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public GeoModel geo { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AddressModel);
        }

        public bool Equals(AddressModel other)
        {
            AqualityServices.Logger.Info($"Address match check");
            return other != null &&
                   street == other.street &&
                   suite == other.suite &&
                   city == other.city &&
                   zipcode == other.zipcode &&
                   geo.Equals(other.geo);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(street, suite, city, zipcode, geo);
        }
    }
}

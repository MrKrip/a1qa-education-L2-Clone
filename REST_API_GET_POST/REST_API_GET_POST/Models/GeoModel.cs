using Aquality.Selenium.Browsers;
using System;

namespace REST_API_GET_POST.Models
{
    public class GeoModel : IEquatable<GeoModel>
    {
        public string lat { get; set; }
        public string lng { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as GeoModel);
        }

        public bool Equals(GeoModel other)
        {
            AqualityServices.Logger.Info($"Geo match check");
            return other != null &&
                   lat == other.lat &&
                   lng == other.lng;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(lat, lng);
        }
    }
}

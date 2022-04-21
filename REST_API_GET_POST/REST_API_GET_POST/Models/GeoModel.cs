using Aquality.Selenium.Browsers;

namespace REST_API_GET_POST.Models
{
    public class GeoModel
    {
        public string lat { get; set; }
        public string lng { get; set; }

        public bool AreGeoEqual(GeoModel geo)
        {
            AqualityServices.Logger.Info($"Geo match check");
            return lat == geo.lat && lng == geo.lng;
        }
    }
}

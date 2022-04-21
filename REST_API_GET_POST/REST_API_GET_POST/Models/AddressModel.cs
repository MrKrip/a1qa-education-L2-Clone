using Aquality.Selenium.Browsers;

namespace REST_API_GET_POST.Models
{
    public class AddressModel
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public GeoModel geo { get; set; }

        public bool AreAddressEqual(AddressModel address)
        {
            AqualityServices.Logger.Info($"Address match check");
            return geo.AreGeoEqual(address.geo) && street == address.street && suite == address.suite && city == address.city && zipcode == address.zipcode;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_API_GET_POST.Models
{
    public class AdressModel
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public GeoModel geo { get; set; }
    }
}

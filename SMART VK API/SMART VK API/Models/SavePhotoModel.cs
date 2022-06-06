using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_VK_API.Models
{
    public class SavePhotoModel
    {
        public int id { get; set; }
        public int album_id { get; set; }
        public int owner_id { get; set; }
        public string text { get; set; }
        public int date { get; set; }
        public List<SizeModel> sizes { get; set; }
        public string access_key { get; set; }
        public bool has_tags { get; set; }
    }
}

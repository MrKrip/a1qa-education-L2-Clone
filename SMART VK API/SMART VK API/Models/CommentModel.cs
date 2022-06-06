using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_VK_API.Models
{
    public class CommentModel
    {
        public int comment_id { get; set; }
        public List<int> parent_stack { get; set; }
    }
}

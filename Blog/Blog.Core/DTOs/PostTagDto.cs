using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class PostTagDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}

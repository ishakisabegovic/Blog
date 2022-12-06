using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class PostTag : BaseEntity
    {
        public Post Post { get; set; }
        [Required]
        public int PostId { get; set; }
        public Tag Tag { get; set; }
        [Required]
        public int TagId { get; set; }
    }
}

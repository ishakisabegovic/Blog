using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Post : BaseEntity
    {
        public string? Slug { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum length for the title is 50 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length for description is 100 characters")]
        public string Description { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Maximum length for body is 200 characters")]
        public string Body { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        //public Post()
        //{
        //    this.Slug = Title?.ToLower().Replace(" ", "-").Replace(@"[^\w\s]","");
        //}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Tag : BaseEntity
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Maximum length for tag title is 30 characters.")]
        public string Title { get; set; }
        public virtual ICollection<PostTag>? PostTags { get; set; }
    }
}

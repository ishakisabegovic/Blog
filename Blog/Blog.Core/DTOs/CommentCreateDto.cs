using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    [Display(Name = "comment")]
    public class CommentCreateDto
    {
        [Required]
        [MaxLength(50, ErrorMessage ="Maximum length for comment body is 50 characters.")]
        public string Body { get; set; }
    }
}

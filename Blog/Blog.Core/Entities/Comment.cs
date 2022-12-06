using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Maximum length for body is 200 characters.")]
        public string Body { get; set; }

        
        public virtual Post Post { get; set; }
        public int PostId {  get; set; }    
    }
}

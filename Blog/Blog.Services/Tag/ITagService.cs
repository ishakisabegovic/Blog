using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Tag
{
    public interface ITagService
    {
        IEnumerable<Core.DTOs.TagDto> GetAllTags();
    }
}

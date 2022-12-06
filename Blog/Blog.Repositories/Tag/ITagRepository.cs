using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories.Tag
{
    public interface ITagRepository
    {
        IEnumerable<Core.Entities.Tag> GetAllTags();
        Core.Entities.Tag GetTag(string title);
        public void Add(Core.Entities.Tag tag);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories.PostTag
{
    public  interface IPostTagRepository
    {
        void CreatePostTag(Core.Entities.PostTag postTag);
    }
}

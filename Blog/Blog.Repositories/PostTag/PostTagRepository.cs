using Blog.Repositories.Base;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Infrastructure.Database;

namespace Blog.Repositories.PostTag
{
    public class PostTagRepository : BaseRepository<Core.Entities.PostTag>, IPostTagRepository
    {
        public PostTagRepository(AppDbContext context) : base(context)
        {
        }

        public void CreatePostTag(Core.Entities.PostTag postTag) => Create(postTag);
        
    }
}

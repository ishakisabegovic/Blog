using Blog.Core.Entities;
using Blog.Infrastructure.Database;
using Blog.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories.Tag
{
    public class TagRepository : BaseRepository<Core.Entities.Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Core.Entities.Tag>> GetAllTags() =>
            await GetAll()
            .Include(x => x.PostTags)
            .ThenInclude(x => x.Post)
            .ToListAsync();

        public async Task<Core.Entities.Tag> GetTag(string title) =>
            await GetByCondition(x => x.Title == title)
            .Include(x => x.PostTags)
            .ThenInclude(x => x.Post)
            .SingleOrDefaultAsync();

        public void Add(Core.Entities.Tag tag) => Create(tag);

        

    }
}

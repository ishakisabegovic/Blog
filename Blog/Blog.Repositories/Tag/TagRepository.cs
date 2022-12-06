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

        public IEnumerable<Core.Entities.Tag> GetAllTags() =>
            GetAll()
            .Include(x => x.PostTags)
            .ThenInclude(x => x.Post)
            .ToList();

        public Core.Entities.Tag GetTag(string title) =>
            GetByCondition(x => x.Title == title)
            .Include(x => x.PostTags)
            .ThenInclude(x => x.Post)
            .SingleOrDefault();

        public void Add(Core.Entities.Tag tag) => Create(tag);

        

    }
}

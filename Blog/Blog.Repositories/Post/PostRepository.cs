
using Blog.Core.Entities;
using Blog.Infrastructure.Database;
using Blog.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories.Post
{
    public class PostRepository : BaseRepository<Core.Entities.Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Core.Entities.Post>> GetAllPosts() => 
            await GetAll()
            .Include(x=>x.PostTags)
            .ThenInclude(x=>x.Tag)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
        
        public  Core.Entities.Post GetPost(string slug) =>
              GetByCondition(x=>x.Slug == slug)            
            .Include(x=>x.PostTags)
            .ThenInclude(x=>x.Tag)
            .ThenInclude(x => x.Title)
            .SingleOrDefault();

        public async  Task<IEnumerable<Core.Entities.Post>> GetPostsByCondition(
            Expression<Func<Core.Entities.Post, bool>> expression) 
            => await GetByCondition(expression).OrderByDescending(x=>x.CreatedAt).ToListAsync();

        public void CreatePost(Core.Entities.Post post) => Create(post);
        public void UpdatePost(Core.Entities.Post post) => Update(post);
        public void DeletePost(Core.Entities.Post post) => Delete(post);
        
    }
}

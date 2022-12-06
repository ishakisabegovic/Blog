
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

        public IEnumerable<Core.Entities.Post> GetAllPosts() => 
            GetAll()
            .Include(x=>x.PostTags)
            .ThenInclude(x=>x.Tag)
            .ToList();

        public Core.Entities.Post GetPost(string slug) =>
            GetByCondition(x=>x.Slug == slug)            
            .Include(x=>x.PostTags)
            .ThenInclude(x=>x.Tag)
            .SingleOrDefault();

        public IEnumerable<Core.Entities.Post> GetPostsByCondition(
            Expression<Func<Core.Entities.Post, bool>> expression) 
            => GetByCondition(expression).ToList();

        public void CreatePost(Core.Entities.Post post) => Create(post);
        public void UpdatePost(Core.Entities.Post post) => Update(post);
        public void DeletePost(Core.Entities.Post post) => Delete(post);
        
    }
}

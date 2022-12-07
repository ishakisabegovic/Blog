using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories.Post
{
    public interface IPostRepository
    {
        Task<IEnumerable<Core.Entities.Post>> GetAllPosts();

        Task<IEnumerable<Core.Entities.Post>> GetPostsByCondition(
            Expression<Func<Core.Entities.Post, bool>> expression);

        Core.Entities.Post GetPost(string slug);

        void CreatePost(Core.Entities.Post post);
        void UpdatePost(Core.Entities.Post post);
        void DeletePost(Core.Entities.Post post);
    }
}

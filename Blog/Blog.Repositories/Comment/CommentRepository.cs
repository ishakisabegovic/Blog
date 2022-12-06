using Blog.Core.DTOs;
using Blog.Infrastructure.Database;
using Blog.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories.Comment
{
    public class CommentRepository : BaseRepository<Core.Entities.Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateCommentForPost(Core.Entities.Comment comment) => Create(comment);

        public void DeleteCommentFromPost(Core.Entities.Comment comment) => Delete(comment);        

        public IEnumerable<Core.Entities.Comment> GetCommentsFromPost(int postId) => GetByCondition(x => x.PostId == postId).ToList();
        

    }
}

using Blog.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories.Comment
{
    public interface ICommentRepository
    {
        IEnumerable<Core.Entities.Comment> GetCommentsFromPost(int postId);
        void CreateCommentForPost(Core.Entities.Comment comment);
        void DeleteCommentFromPost(Core.Entities.Comment comment);
    }
}

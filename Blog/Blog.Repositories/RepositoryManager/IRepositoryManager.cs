using Blog.Repositories.Comment;
using Blog.Repositories.Post;
using Blog.Repositories.PostTag;
using Blog.Repositories.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories.RepositoryManager
{
    public interface IRepositoryManager
    {
        IPostRepository Post { get; }   
        ITagRepository Tag { get; }
        IPostTagRepository PostTag { get; }
        ICommentRepository Comment { get; }       
        Task Save();
    }
}

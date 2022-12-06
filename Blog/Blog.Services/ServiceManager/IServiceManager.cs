using Blog.Services.Comment;
using Blog.Services.Post;
using Blog.Services.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.ServiceManager
{
    public interface IServiceManager
    {
        IPostService PostService { get; }
        ITagService TagService { get; }
        ICommentService CommentService { get; }
       
    }
}

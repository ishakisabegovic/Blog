using AutoMapper;
using Blog.Repositories.RepositoryManager;
using Blog.Services.Comment;
using Blog.Services.Logger;
using Blog.Services.Post;
using Blog.Services.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.ServiceManager
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPostService> _postService;
        private readonly Lazy<ITagService> _tagService;       
        private readonly Lazy<ICommentService> _commentService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _postService = new Lazy<IPostService>(() => new PostService(repository, logger, mapper));
            _tagService = new Lazy<ITagService>(() => new TagService(repository, logger, mapper));           
            _commentService = new Lazy<ICommentService>(() => new CommentService(repository, logger, mapper));

        }
        public IPostService PostService => _postService.Value;
        public ITagService TagService => _tagService.Value;        
        public ICommentService CommentService => _commentService.Value;
    }
}

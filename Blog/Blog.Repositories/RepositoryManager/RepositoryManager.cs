using Blog.Infrastructure.Database;
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
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;       
        private readonly Lazy<IPostRepository> _postRepository;
        private readonly Lazy<ITagRepository> _tagRepository;
        private readonly Lazy<IPostTagRepository> _postTagRepository;
        private readonly Lazy<ICommentRepository> _commentRepository;


        public RepositoryManager(AppDbContext context)
        {
            _context = context;
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(context));
            _tagRepository = new Lazy<ITagRepository>(() => new TagRepository(context));
            _postTagRepository = new Lazy<IPostTagRepository>(() => new PostTagRepository(context));
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(context));

        }
        public IPostRepository Post => _postRepository.Value;

        public ITagRepository Tag => _tagRepository.Value;

        public IPostTagRepository PostTag => _postTagRepository.Value;
        public ICommentRepository Comment => _commentRepository.Value;
        
        public void Save() => _context.SaveChanges();
        
    }
}

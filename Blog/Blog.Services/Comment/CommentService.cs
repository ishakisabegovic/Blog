using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Entities.Exceptions;
using Blog.Repositories.RepositoryManager;
using Blog.Services.Logger;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CommentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateCommentForPost(string slug, CommentCreateDto commentDto)
        {
            var post = _repository.Post.GetPost(slug);
            var comment = new Core.Entities.Comment
            {
                Body = commentDto.Body,
                PostId = post.Id
            };
            _repository.Comment.CreateCommentForPost(comment);
            await _repository.Save();
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task DeleteCommentFromPost(string slug, int commentId)
        {
            var post = _repository.Post.GetPost(slug);
            if (post is null) throw new PostNotFoundException(slug);
            var comment =  _repository.Comment.GetCommentsFromPost(post.Id).FirstOrDefault(x => x.Id == commentId);
            if (comment is null) throw new CommentNotFoundException(commentId);
            _repository.Comment.DeleteCommentFromPost(comment);
            await _repository.Save();
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsFromPost(string slug)
        {
            var post = _repository.Post.GetPost(slug);
            if (post is null) throw new PostNotFoundException(slug);
            var comments = _repository.Comment.GetCommentsFromPost(post.Id);
            var commentsMapped = _mapper.Map<IEnumerable<CommentDto>>(comments);
            return commentsMapped;
        }
    }
}

using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Entities.Exceptions;
using Blog.Repositories.RepositoryManager;
using Blog.Services.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Post
{
    public sealed class PostService : IPostService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PostService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }       

        public async Task<Core.DTOs.PostListDto> GetAllPosts(string? tagFilter)
        {                           
                var posts = await _repository.Post.GetAllPosts();

                if (tagFilter != "" && tagFilter != null)
                posts = posts.Where(x => x.PostTags.Any(m => m.Tag.Title.ToLower().Contains(tagFilter.ToLower())));
                            
                var postsDto = _mapper.Map<List<Core.DTOs.PostDto>>(posts);

                var postsToReturn = new PostListDto(postsDto, postsDto.Count());  
                
                return postsToReturn;
        }

        public async Task<PostDto> GetPostBySlug(string slug)
        {            
                var post = _repository.Post.GetPost(slug);

                if (post == null)
                     throw new PostNotFoundException(slug);

                var postDto = _mapper.Map<PostDto>(post);
                return postDto;

        }

        public async Task<PostDto> CreatePost(PostCreateDto post)
        {
            var posts = await _repository.Post.GetPostsByCondition(x=>x.Title==post.Title);
            if (posts.Count() == 0)
            {
                var postEntity = new Core.Entities.Post()
                {
                    Title = post.Title,
                    Description = post.Description,
                    Body = post.Body,
                    Slug = post.Title?.ToLower().Replace(" ", "-").Replace(@"[^\w\s]", "")
                };

                _repository.Post.CreatePost(postEntity);
                _repository.Save();



                var newTags = new List<Core.Entities.Tag>();

                foreach (var tag in post.PostTags)
                {
                    var tagFromDB = await _repository.Tag.GetTag(tag);
                    if (tagFromDB == null)
                    {
                        var newTag = new Core.Entities.Tag()
                        {
                            Title = tag
                        };
                        _repository.Tag.Add(newTag);
                        newTags.Add(newTag);

                    }
                    else newTags.Add(tagFromDB);

                }

                if(post.PostTags.Count() > 0)
                _repository.Save();

                foreach (var tag in newTags)
                {
                    _repository.PostTag.CreatePostTag(new Core.Entities.PostTag
                    {
                        PostId = postEntity.Id,
                        TagId = tag.Id

                    });
                }

                if(newTags.Count() > 0)
                _repository.Save();

                var postToReturn = _mapper.Map<PostDto>(postEntity);
                return postToReturn;
            }

            else
            {
                throw new TitleBadRequestException(post.Title);
            }

        }

        public async Task<PostDto> UpdatePost(string slug, PostUpdateDto postDto)
        {
            var post =  _repository.Post.GetPost(slug);
            if (post is null) throw new PostNotFoundException(slug);

            //_mapper.Map(postDto, post);

            if (postDto.Title != null)
            {
                post.Title = postDto.Title;
                post.Slug = postDto.Title.ToLower().Replace(" ", "-").Replace(@"[^\w\s]", "");
            }

            if(postDto.Description != null)  post.Description = postDto.Description;
            if(postDto.Body != null) post.Body = postDto.Body;

            post.UpdatedAt = DateTime.Now;

            _repository.Post.UpdatePost(post);           
            await _repository.Save();

            return _mapper.Map<PostDto>(post);
        }

        public async Task DeletePost(string slug)
        {
            var post = _repository.Post.GetPost(slug);
            if (post is null) 
                throw new PostNotFoundException(slug);
            _repository.Post.DeletePost(post);
            await _repository.Save();
        }
    }
}

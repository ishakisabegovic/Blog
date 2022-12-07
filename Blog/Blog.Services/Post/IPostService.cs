using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Post
{
    public interface IPostService
    {
        Task<Core.DTOs.PostListDto> GetAllPosts(string tagFilter);

        Task<Core.DTOs.PostDto> GetPostBySlug(string slug);

        Task<Core.DTOs.PostDto> CreatePost(Core.DTOs.PostCreateDto post);
        Task<Core.DTOs.PostDto> UpdatePost(string slug, Core.DTOs.PostUpdateDto postDto);
        Task DeletePost(string slug);
    }
}

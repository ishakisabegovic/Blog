using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Post
{
    public interface IPostService
    {
        IEnumerable<Core.DTOs.PostDto> GetAllPosts();

        Core.DTOs.PostDto GetPostBySlug(string slug);

        Core.DTOs.PostDto CreatePost(Core.DTOs.PostCreateDto post);
        Core.DTOs.PostDto UpdatePost(string slug, Core.DTOs.PostUpdateDto postDto);
        void DeletePost(string slug);
    }
}

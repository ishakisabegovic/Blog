using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class PostListDto
    {
        public List<PostDto> BlogPosts { get; set; }
        public int PostsCount { get; set; }

        public PostListDto(List<PostDto> blogPosts, int postsCount)
        {
            BlogPosts = blogPosts;
            PostsCount = postsCount;
        }
    }
}

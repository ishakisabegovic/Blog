using Blog.Core.DTOs;
using Blog.Services.ServiceManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PostsController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _service.PostService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{slug}")]
        public IActionResult GetPost(string slug)
        {
            var postToReturn = _service.PostService.GetPostBySlug(slug);
            return Ok(postToReturn);
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody] PostCreateDto postDto)
        {
            if (postDto is null)
                return BadRequest("Post object is null.");
            var postToReturn = _service.PostService.CreatePost(postDto);
            return Ok(postToReturn);
        }

        [HttpPut("{slug}")]
        public IActionResult UpdatePost(string slug, [FromBody] PostUpdateDto postDto)
        {
            if (postDto is null)
                return BadRequest("Post object is null.");
            var postToReturn = _service.PostService.UpdatePost(slug, postDto);
            return Ok(postToReturn);
        }

        [HttpDelete("{slug}")]
        public IActionResult DeletePost(string slug)
        {
            _service.PostService.DeletePost(slug);
            return NoContent();
        }

        [HttpPost("{slug}/comments")]
        public IActionResult AddCommentToPost(string slug, [FromBody] CommentCreateDto commentDto)
        {
            if (commentDto is null) 
                return BadRequest("Comment object is null.");
            var commentToReturn = _service.CommentService.CreateCommentForPost(slug, commentDto);
            return Ok(commentToReturn);

        }

        [HttpGet("{slug}/comments")]
        public IActionResult GetCommentsFromPost(string slug)
        {
            var comments = _service.CommentService.GetCommentsFromPost(slug);
            if (comments is null)
                return BadRequest("There are no comments for this post");
            return Ok(comments);
        }

        [HttpDelete("{slug}/comments/{commentId}")]
        public IActionResult DeleteCommentFromPost(string slug, int commentId)
        {
            _service.CommentService.DeleteCommentFromPost(slug, commentId);
            return NoContent();
        }
    }
}

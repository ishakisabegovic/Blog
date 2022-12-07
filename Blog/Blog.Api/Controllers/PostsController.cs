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
        public async Task<IActionResult> GetPosts([FromQuery] string? tagFilter)
        {
            var posts = await _service.PostService.GetAllPosts(tagFilter);           
            return Ok(posts);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetPost(string slug)
        {
            var postToReturn = await _service.PostService.GetPostBySlug(slug);
            return Ok(postToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostCreateDto postDto)
        {
            if (postDto is null)
                return BadRequest("Post object is null.");
            if (!ModelState.IsValid) 
                return UnprocessableEntity(ModelState);
            var postToReturn = await _service.PostService.CreatePost(postDto);
            return Ok(postToReturn);
        }

        [HttpPut("{slug}")]
        public async Task<IActionResult> UpdatePost(string slug, [FromBody] PostUpdateDto postDto)
        {
            if (postDto is null)
                return BadRequest("Post object is null.");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var postToReturn = await _service.PostService.UpdatePost(slug, postDto);
            return Ok(postToReturn);
        }

        [HttpDelete("{slug}")]
        public IActionResult DeletePost(string slug)
        {
            _service.PostService.DeletePost(slug);
            return NoContent();
        }

        [HttpPost("{slug}/comments")]
        public async Task<IActionResult> AddCommentToPost(string slug, [FromBody] CommentCreateDto commentDto)
        {
            if (commentDto is null) 
                return BadRequest("Comment object is null.");
            if (!ModelState.IsValid) return
                    UnprocessableEntity(ModelState);
            var commentToReturn = await _service.CommentService.CreateCommentForPost(slug, commentDto);
            return Ok(commentToReturn);

        }

        [HttpGet("{slug}/comments")]
        public async Task<IActionResult> GetCommentsFromPost(string slug)
        {
            var comments = await _service.CommentService.GetCommentsFromPost(slug);
            if (comments is null)
                return BadRequest("There are no comments for this post");
            return Ok(comments);
        }

        [HttpDelete("{slug}/comments/{commentId}")]
        public async Task<IActionResult> DeleteCommentFromPost(string slug, int commentId)
        {
            await _service.CommentService.DeleteCommentFromPost(slug, commentId);
            return NoContent();
        }
    }
}

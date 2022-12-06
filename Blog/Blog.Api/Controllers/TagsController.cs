using Blog.Services.ServiceManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TagsController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetTags()
        {
            var tagsToReturn = _service.TagService.GetAllTags();
            if (tagsToReturn == null) return BadRequest("There are no tags in the database.");
            return Ok(tagsToReturn);
        }
    }
}

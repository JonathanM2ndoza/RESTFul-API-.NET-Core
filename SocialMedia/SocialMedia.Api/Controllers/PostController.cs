using Microsoft.AspNetCore.Mvc;
using SocialMedia.Infrastructure.Repositories.Posts;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPosts() {
            var post = new PostRepository().GetPosts();
            return Ok(post);
        }
    }
}

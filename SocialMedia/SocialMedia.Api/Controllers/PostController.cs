using Microsoft.AspNetCore.Mvc;
using SocialMedia.Domain.Interfaces.Input.Posts;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IGetPostsInput _getPostsInput;

        public PostController(IGetPostsInput getPostsInput)
        {
            _getPostsInput = getPostsInput;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _getPostsInput.GetPosts());
        }
    }
}

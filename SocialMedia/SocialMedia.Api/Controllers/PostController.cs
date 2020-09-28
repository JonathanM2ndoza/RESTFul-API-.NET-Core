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
        private readonly IGetPostInput _getPostInput;

        public PostController(IGetPostsInput getPostsInput, IGetPostInput getPostInput)
        {
            _getPostsInput = getPostsInput;
            _getPostInput = getPostInput;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _getPostsInput.GetPosts());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPost(int Id)
        {
            return Ok(await _getPostInput.GetPost(Id));
        }
    }
}

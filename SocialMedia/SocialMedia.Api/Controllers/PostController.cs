using Microsoft.AspNetCore.Mvc;
using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Models.Posts;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IGetPostsInput _getPostsInput;
        private readonly IGetPostInput _getPostInput;
        private readonly ICreatePostInput _createPostInput;

        public PostController(IGetPostsInput getPostsInput, IGetPostInput getPostInput, ICreatePostInput createPostInput)
        {
            _getPostsInput = getPostsInput;
            _getPostInput = getPostInput;
            _createPostInput = createPostInput;
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

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            await _createPostInput.CreatePost(post);
            return Ok(post);
        }
    }
}

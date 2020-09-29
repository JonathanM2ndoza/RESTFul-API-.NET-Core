using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Domain.DTOs.Posts;
using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Models.Posts;
using System.Collections.Generic;
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

        private readonly IMapper _mapper;

        public PostController(IGetPostsInput getPostsInput, IGetPostInput getPostInput, ICreatePostInput createPostInput, IMapper mapper)
        {
            _getPostsInput = getPostsInput;
            _getPostInput = getPostInput;
            _createPostInput = createPostInput;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(_mapper.Map<IEnumerable<PostDto>>(await _getPostsInput.GetPosts()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPost(int Id)
        {
            return Ok(_mapper.Map<PostDto>(await _getPostInput.GetPost(Id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDto postDto)
        {
            await _createPostInput.CreatePost(_mapper.Map<Post>(postDto));
            return Ok(new ApiResponse<PostDto>(postDto));
        }
    }
}

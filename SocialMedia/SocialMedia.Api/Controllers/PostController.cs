using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Domain.DTOs.Posts;
using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Domain.Models.QueryFilters;
using System.Collections.Generic;
using System.Net;
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
        private readonly IUpdatePostInput _updatePostInput;
        private readonly IDeletePostInput _deletePostInput;

        private readonly IMapper _mapper;

        public PostController(IGetPostsInput getPostsInput, IGetPostInput getPostInput,
                              ICreatePostInput createPostInput, IUpdatePostInput updatePostInput,
                              IDeletePostInput deletePostInput, IMapper mapper)
        {
            _getPostsInput = getPostsInput;
            _getPostInput = getPostInput;
            _createPostInput = createPostInput;
            _updatePostInput = updatePostInput;
            _deletePostInput = deletePostInput;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetPosts))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PostDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPosts([FromQuery] PostQueryFilter postQueryFilter)
        {
            IEnumerable<PostDto> postDtos = _mapper.Map<IEnumerable<PostDto>>(_getPostsInput.GetPosts(postQueryFilter));
            ApiResponse<IEnumerable<PostDto>> apiResponse = new ApiResponse<IEnumerable<PostDto>>(postDtos);
            return Ok(apiResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            PostDto postDto = _mapper.Map<PostDto>(await _getPostInput.GetPost(id));
            ApiResponse<PostDto> apiResponse = new ApiResponse<PostDto>(postDto);
            return Ok(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDto postDto)
        {
            Post post = _mapper.Map<Post>(postDto);

            await _createPostInput.CreatePost(post);

            postDto = _mapper.Map<PostDto>(post);
            ApiResponse<PostDto> apiResponse = new ApiResponse<PostDto>(postDto);
            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostDto postDto)
        {
            Post post = _mapper.Map<Post>(postDto);
            post.Id = id;
            bool result = await _updatePostInput.UpdatePost(post);
            ApiResponse<bool> apiResponse = new ApiResponse<bool>(result);
            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            bool result = await _deletePostInput.DeletePost(id);
            ApiResponse<bool> apiResponse = new ApiResponse<bool>(result);
            return Ok(apiResponse);
        }
    }
}

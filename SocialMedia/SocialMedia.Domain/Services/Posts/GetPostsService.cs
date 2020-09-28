using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Services.Posts
{
    public class GetPostsService : IGetPostsInput
    {
        private readonly IGetPostsOutput _getPostsOutput;

        public GetPostsService(IGetPostsOutput getPostsOutput)
        {
            _getPostsOutput = getPostsOutput;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _getPostsOutput.GetPosts();
        }
    }
}

using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Services.Posts
{
    public class GetPostService : IGetPostInput
    {
        private readonly IGetPostOutput _getPostOutput;

        public GetPostService(IGetPostOutput getPostOutput)
        {
            _getPostOutput = getPostOutput;
        }
        public async Task<Post> GetPost(int id)
        {
            return await _getPostOutput.GetPost(id);
        }
    }
}

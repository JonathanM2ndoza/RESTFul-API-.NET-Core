using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Services.Posts
{
    public class CreatePostService : ICreatePostInput
    {
        private readonly ICreatePostOutput _createPostOutput;

        public CreatePostService(ICreatePostOutput createPostOutput)
        {
            _createPostOutput = createPostOutput;
        }

        public async Task CreatePost(Post post)
        {
            await _createPostOutput.CreatePost(post);
        }
    }
}

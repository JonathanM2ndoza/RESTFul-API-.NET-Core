using SocialMedia.Domain.Exceptions;
using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Interfaces.Output.Users;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Domain.Models.Users;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Services.Posts
{
    public class CreatePostService : ICreatePostInput
    {
        private readonly ICreatePostOutput _createPostOutput;
        private readonly IGetUserOutput _getUserOutput;

        public CreatePostService(ICreatePostOutput createPostOutput, IGetUserOutput getUserOutput)
        {
            _createPostOutput = createPostOutput;
            _getUserOutput = getUserOutput;
        }

        public async Task CreatePost(Post post)
        {
            User user = await _getUserOutput.GetUser(post.UserId);
            if (user == null) {
                throw new BusinessException("User doesn't exist");
            }

            await _createPostOutput.CreatePost(post);
        }
    }
}

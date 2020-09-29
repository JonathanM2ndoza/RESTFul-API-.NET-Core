using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Services.Posts
{
    public class UpdatePostService : IUpdatePostInput
    {
        private readonly IUpdatePostOutput _updatePostOutput;
        private readonly IGetPostInput _getPostInput;

        public UpdatePostService(IUpdatePostOutput updatePostOutput, IGetPostInput getPostInput)
        {
            _updatePostOutput = updatePostOutput;
            _getPostInput = getPostInput;
        }

        public async Task<bool> UpdatePost(Post post)
        {
            Post currentPost = await _getPostInput.GetPost(post.Id);
            if (currentPost != null)
            {
                currentPost.Image = post.Image;
                currentPost.Description = post.Description;

                await _updatePostOutput.UpdatePost(currentPost);
                return true;
            }
            return false;
        }
    }
}

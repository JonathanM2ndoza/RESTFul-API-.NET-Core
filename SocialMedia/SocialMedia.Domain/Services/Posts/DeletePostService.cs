using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Services.Posts
{
    public class DeletePostService : IDeletePostInput
    {
        private readonly IDeletePostOutput _deletePostOutput;

        public DeletePostService(IDeletePostOutput deletePostOutput)
        {
            _deletePostOutput = deletePostOutput;
        }

        public async Task<bool> DeletePost(int id)
        {
            return await _deletePostOutput.DeletePost(id);
        }
    }
}

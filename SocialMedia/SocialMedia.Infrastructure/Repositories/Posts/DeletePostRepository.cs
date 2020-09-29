using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Data;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class DeletePostRepository : IDeletePostOutput
    {

        private readonly SocialMediaContext _socialMediaContext;

        public DeletePostRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }

        public async Task<bool> DeletePost(int id)
        {
            Post post = await _socialMediaContext.Posts.FindAsync(id);
            if (post != null)
            {
                _socialMediaContext.Remove(post);
                await _socialMediaContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

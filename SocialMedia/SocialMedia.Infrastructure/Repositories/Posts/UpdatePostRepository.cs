using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Data;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class UpdatePostRepository : IUpdatePostOutput
    {
        private readonly SocialMediaContext _socialMediaContext;

        public UpdatePostRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }

        public async Task UpdatePost(Post post)
        {
            await _socialMediaContext.SaveChangesAsync();
        }
    }
}

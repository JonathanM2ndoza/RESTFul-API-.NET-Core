using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Data;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class GetPostRepository : IGetPostOutput
    {

        private readonly SocialMediaContext _socialMediaContext;

        public GetPostRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _socialMediaContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Data;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class CreatePostRepository : ICreatePostOutput
    {
        private readonly SocialMediaContext _socialMediaContext;

        public CreatePostRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }

        public async Task CreatePost(Post post)
        {
            _socialMediaContext.Posts.Add(post);
            await _socialMediaContext.SaveChangesAsync();
        }
    }
}

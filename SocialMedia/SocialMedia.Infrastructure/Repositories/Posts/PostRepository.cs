using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class PostRepository : BaseRepository<Post>
    {
        public PostRepository(SocialMediaContext context) : base(context) { }

        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            return await _entities.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}

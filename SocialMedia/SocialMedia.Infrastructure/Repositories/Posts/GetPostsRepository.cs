using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class GetPostsRepository : IGetPostsOutput
    {
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post
            {
                PostId = x,
                Description = $"Descripcion{x}",
                Date = DateTime.Now,
                Image = $"http://test.images/{x}",
                UserId = x * 2
            });

            await Task.Delay(10);
            return posts;
        }
    }
}

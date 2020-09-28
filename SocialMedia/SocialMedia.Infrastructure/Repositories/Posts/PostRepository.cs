using SocialMedia.Domain.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class PostRepository
    {
        public IEnumerable<Post> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post
            {
                PostId = x,
                Description = $"Descripcion{x}",
                Date = DateTime.Now,
                Image = $"http://test.images/{x}",
                UserId = x * 2
            });

            return posts;
        }
    }
}

using SocialMedia.Domain.Models.Posts;
using System.Collections.Generic;

namespace SocialMedia.Domain.Interfaces.Output.Posts
{
    public interface IGetPostsOutput
    {
        IEnumerable<Post> GetPosts();
    }
}

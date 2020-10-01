using SocialMedia.Domain.Models.Posts;
using System.Collections.Generic;

namespace SocialMedia.Domain.Interfaces.Input.Posts
{
    public interface IGetPostsInput
    {
        IEnumerable<Post> GetPosts();
    }
}

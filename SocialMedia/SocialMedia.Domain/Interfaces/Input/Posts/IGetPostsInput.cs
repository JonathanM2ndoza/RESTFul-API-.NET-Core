using SocialMedia.Domain.Models.Posts;
using SocialMedia.Domain.Models.QueryFilters;
using System.Collections.Generic;

namespace SocialMedia.Domain.Interfaces.Input.Posts
{
    public interface IGetPostsInput
    {
        IEnumerable<Post> GetPosts(PostQueryFilter postQueryFilter);
    }
}

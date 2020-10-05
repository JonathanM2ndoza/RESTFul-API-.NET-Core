using SocialMedia.Domain.Models.Custom;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Domain.Models.QueryFilters;
using System.Collections.Generic;

namespace SocialMedia.Domain.Interfaces.Input.Posts
{
    public interface IGetPostsInput
    {
        PagedList<Post> GetPosts(PostQueryFilter postQueryFilter);
    }
}

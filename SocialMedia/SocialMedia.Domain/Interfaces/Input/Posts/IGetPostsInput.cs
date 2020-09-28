using SocialMedia.Domain.Models.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Input.Posts
{
    public interface IGetPostsInput
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}

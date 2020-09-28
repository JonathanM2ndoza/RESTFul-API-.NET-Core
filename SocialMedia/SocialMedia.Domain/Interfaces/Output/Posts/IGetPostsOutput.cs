using SocialMedia.Domain.Models.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Output.Posts
{
    public interface IGetPostsOutput
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}

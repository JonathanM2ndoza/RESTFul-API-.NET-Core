using SocialMedia.Domain.Models.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Output.Posts
{
    public interface IGetPostsByUserOutput
    {
        Task<IEnumerable<Post>> GetPostsByUser(int userId);
    }
}

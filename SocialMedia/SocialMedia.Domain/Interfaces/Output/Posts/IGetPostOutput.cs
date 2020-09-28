using SocialMedia.Domain.Models.Posts;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Output.Posts
{
    public interface IGetPostOutput
    {
        Task<Post> GetPost(int Id);
    }
}

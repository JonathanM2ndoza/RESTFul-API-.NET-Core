using SocialMedia.Domain.Models.Posts;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Input.Posts
{
    public interface ICreatePostInput
    {
        Task CreatePost(Post post);
    }
}

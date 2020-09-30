using SocialMedia.Domain.Models.Users;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Output.Users
{
    public interface IGetUserOutput
    {
        Task<User> GetUser(int id);
    }
}

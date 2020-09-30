using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Interfaces.Output.Users;
using SocialMedia.Domain.Models.Users;
using SocialMedia.Infrastructure.Data;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Users
{
    public class GetUserRepository : IGetUserOutput
    {
        private readonly SocialMediaContext _socialMediaContext;

        public GetUserRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }

        public async Task<User> GetUser(int id)
        {
            return await _socialMediaContext.Users.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

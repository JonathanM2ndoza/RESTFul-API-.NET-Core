using SocialMedia.Domain.Interfaces.Output.Users;
using SocialMedia.Domain.Models.Users;
using SocialMedia.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Users
{
    public class GetUserRepository : IGetUserOutput
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUser(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }
    }
}

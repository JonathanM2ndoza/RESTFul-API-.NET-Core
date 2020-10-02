using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class GetPostsByUserRepository : IGetPostsByUserOutput
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPostsByUserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            return await _unitOfWork.PostRepository.GetPostsByUser(userId);

        }
    }
}

using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class UpdatePostRepository : IUpdatePostOutput
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePostRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

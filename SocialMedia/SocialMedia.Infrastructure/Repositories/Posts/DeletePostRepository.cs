using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class DeletePostRepository : IDeletePostOutput
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeletePost(int id)
        {
            Post post = await _unitOfWork.PostRepository.GetById(id);
            if (post != null)
            {
                _unitOfWork.PostRepository.Delete(post);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class CreatePostRepository : ICreatePostOutput
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePostRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreatePost(Post post)
        {
            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

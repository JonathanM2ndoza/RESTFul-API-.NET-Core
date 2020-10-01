using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class GetPostsRepository : IGetPostsOutput
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPostsRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _unitOfWork.PostRepository.GetAll();
        }
    }
}

using SocialMedia.Domain.Models.Comments;
using SocialMedia.Domain.Models.Users;
using SocialMedia.Infrastructure.Repositories.Posts;
using System;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        PostRepository PostRepository { get; }

        IRepository<User> UserRepository { get; }

        IRepository<Comment> CommentRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}

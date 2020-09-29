using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Input.Posts
{
    public interface IDeletePostInput
    {
        Task<bool> DeletePost(int id);
    }
}

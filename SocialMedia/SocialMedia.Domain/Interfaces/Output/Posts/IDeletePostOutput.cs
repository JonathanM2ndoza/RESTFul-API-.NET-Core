using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Output.Posts
{
    public interface IDeletePostOutput
    {
        Task<bool> DeletePost(int id);
    }
}

using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Domain.Models.QueryFilters;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Domain.Services.Posts
{
    public class GetPostsService : IGetPostsInput
    {
        private readonly IGetPostsOutput _getPostsOutput;

        public GetPostsService(IGetPostsOutput getPostsOutput)
        {
            _getPostsOutput = getPostsOutput;
        }
        public IEnumerable<Post> GetPosts(PostQueryFilter postQueryFilter)
        {
            IEnumerable<Post> posts = _getPostsOutput.GetPosts();

            if (postQueryFilter.UserId != null)
            {
                posts = posts.Where(x => x.UserId == postQueryFilter.UserId);
            }

            if (postQueryFilter.Date != null)
            {
                posts = posts.Where(x => x.Date.ToShortDateString() == postQueryFilter.Date?.ToShortDateString());
            }

            if (postQueryFilter.Description != null)
            {
                posts = posts.Where(x => x.Description.ToLower().Contains(postQueryFilter.Description.ToLower()));
            }

            return posts;
        }
    }
}

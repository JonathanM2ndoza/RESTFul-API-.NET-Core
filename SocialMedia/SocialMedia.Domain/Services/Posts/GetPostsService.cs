using Microsoft.Extensions.Options;
using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Custom;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Domain.Models.QueryFilters;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Domain.Services.Posts
{
    public class GetPostsService : IGetPostsInput
    {
        private readonly IGetPostsOutput _getPostsOutput;
        private readonly PaginationOptions _paginationOptions;

        public GetPostsService(IGetPostsOutput getPostsOutput, IOptions<PaginationOptions> options)
        {
            _getPostsOutput = getPostsOutput;
            _paginationOptions = options.Value;
        }
        public PagedList<Post> GetPosts(PostQueryFilter postQueryFilter)
        {
            IEnumerable<Post> posts = _getPostsOutput.GetPosts();

            postQueryFilter.PageNumber = postQueryFilter.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : postQueryFilter.PageNumber;
            postQueryFilter.PageSize = postQueryFilter.PageSize == 0 ? _paginationOptions.DefaultPageSize : postQueryFilter.PageSize;

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

            return PagedList<Post>.Create(posts, postQueryFilter.PageNumber, postQueryFilter.PageSize);
        }
    }
}

using SocialMedia.Domain.Models.QueryFilters;
using System;

namespace SocialMedia.Infrastructure.Repositories.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}

﻿using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Posts
{
    public class GetPostsRepository : IGetPostsOutput
    {
        private readonly SocialMediaContext _socialMediaContext;

        public GetPostsRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _socialMediaContext.Posts.ToListAsync();
        }
    }
}

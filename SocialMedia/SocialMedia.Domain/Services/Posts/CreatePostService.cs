using SocialMedia.Domain.Exceptions;
using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Interfaces.Output.Users;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Services.Posts
{
    public class CreatePostService : ICreatePostInput
    {
        private readonly ICreatePostOutput _createPostOutput;
        private readonly IGetUserOutput _getUserOutput;
        private readonly IGetPostsByUserOutput _getPostsByUserOutput;
        public CreatePostService(ICreatePostOutput createPostOutput, IGetUserOutput getUserOutput, IGetPostsByUserOutput getPostsByUserOutput)
        {
            _createPostOutput = createPostOutput;
            _getUserOutput = getUserOutput;
            _getPostsByUserOutput = getPostsByUserOutput;
        }

        public async Task CreatePost(Post post)
        {
            // Business Logic
            User user = await _getUserOutput.GetUser(post.UserId);
            if (user == null) {
                throw new BusinessException("User doesn't exist");
            }

            IEnumerable<Post> userPost = await _getPostsByUserOutput.GetPostsByUser(post.UserId);
            if (userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(x => x.Date).FirstOrDefault();
                if ((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BusinessException("You are not able to publish the post");
                }
            }

            await _createPostOutput.CreatePost(post);
        }
    }
}

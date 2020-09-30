using SocialMedia.Domain.Models.Custom;
using SocialMedia.Domain.Models.Posts;
using SocialMedia.Domain.Models.Users;
using System;

namespace SocialMedia.Domain.Models.Comments
{
    public partial class Comment : BaseModel
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}

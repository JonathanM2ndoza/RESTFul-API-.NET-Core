﻿using SocialMedia.Domain.Models.Comments;
using SocialMedia.Domain.Models.Custom;
using SocialMedia.Domain.Models.Posts;
using System;
using System.Collections.Generic;

namespace SocialMedia.Domain.Models.Users
{
    public partial class User : BaseModel
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}

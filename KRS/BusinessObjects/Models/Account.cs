using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Account
    {
        public Account()
        {
            ClassUsers = new HashSet<ClassUser>();
            Discussions = new HashSet<Discussion>();
            Knowledges = new HashSet<Knowledge>();
            Progresses = new HashSet<Progress>();
            Settings = new HashSet<Setting>();
            Subjects = new HashSet<Subject>();
        }

        public int AccountId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? IsVerify { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ProgressId { get; set; }
        public bool? Status { get; set; }
        public string? ProfilePicture { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<ClassUser> ClassUsers { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<Knowledge> Knowledges { get; set; }
        public virtual ICollection<Progress> Progresses { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}

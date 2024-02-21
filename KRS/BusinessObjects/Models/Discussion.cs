using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Discussion
    {
        public int DiscussionId { get; set; }
        public int? SubjectId { get; set; }
        public int? UserId { get; set; }
        public int? ParentId { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual Account? User { get; set; }
    }
}

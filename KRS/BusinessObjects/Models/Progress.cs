using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Progress
    {
        public int ProgressId { get; set; }
        public int? SubjectId { get; set; }
        public int? UserId { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual Account? User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class ClassUser
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }
        public bool? IsTeacher { get; set; }
        public bool? IsActive { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual Account User { get; set; } = null!;
    }
}

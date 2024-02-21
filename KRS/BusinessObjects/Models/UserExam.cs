using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class UserExam
    {
        public int? UserId { get; set; }
        public int? ExamId { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual Account? User { get; set; }
    }
}

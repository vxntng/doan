using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class UserQuestion
    {
        public int? UserId { get; set; }
        public int? ExamId { get; set; }
        public int? KnowledgeId { get; set; }
        public string? UserAnswer { get; set; }
        public bool? IsCorrect { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual Knowledge? Knowledge { get; set; }
        public virtual Account? User { get; set; }
    }
}

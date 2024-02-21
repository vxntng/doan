using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class ExamQuestion
    {
        public int? ExamId { get; set; }
        public int? KnowledgeId { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual Knowledge? Knowledge { get; set; }
    }
}

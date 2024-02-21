using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class ExamConfig
    {
        public int ExamConfigId { get; set; }
        public int? ExamId { get; set; }
        public int? LessonId { get; set; }
        public int? QuestionCount { get; set; }
        public int? DomainId { get; set; }

        public virtual Domain? Domain { get; set; }
        public virtual Exam? Exam { get; set; }
        public virtual Lesson? Lesson { get; set; }
    }
}

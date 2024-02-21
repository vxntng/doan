using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            ExamConfigs = new HashSet<ExamConfig>();
            Knowledges = new HashSet<Knowledge>();
        }

        public int LessonId { get; set; }
        public int? SubjectId { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<ExamConfig> ExamConfigs { get; set; }
        public virtual ICollection<Knowledge> Knowledges { get; set; }
    }
}

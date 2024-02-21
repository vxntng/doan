using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Exam
    {
        public Exam()
        {
            ExamConfigs = new HashSet<ExamConfig>();
        }

        public int ExamId { get; set; }
        public int? ClassId { get; set; }
        public string? ExamName { get; set; }
        public string? Description { get; set; }
        public bool? IsPractice { get; set; }

        public virtual Class? Class { get; set; }
        public virtual ICollection<ExamConfig> ExamConfigs { get; set; }
    }
}

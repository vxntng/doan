using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Domain
    {
        public Domain()
        {
            ExamConfigs = new HashSet<ExamConfig>();
            Knowledges = new HashSet<Knowledge>();
        }

        public int DomainId { get; set; }
        public int? TypeId { get; set; }

        public virtual DomainType? Type { get; set; }
        public virtual ICollection<ExamConfig> ExamConfigs { get; set; }
        public virtual ICollection<Knowledge> Knowledges { get; set; }
    }
}

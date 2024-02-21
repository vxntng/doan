using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Discussions = new HashSet<Discussion>();
            DomainTypes = new HashSet<DomainType>();
            Knowledges = new HashSet<Knowledge>();
            Lessons = new HashSet<Lesson>();
            Progresses = new HashSet<Progress>();
        }

        public int SubjectId { get; set; }
        public int? CategoryId { get; set; }
        public string? SubjectName { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<DomainType> DomainTypes { get; set; }
        public virtual ICollection<Knowledge> Knowledges { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Progress> Progresses { get; set; }
    }
}

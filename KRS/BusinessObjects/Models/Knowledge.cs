using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Knowledge
    {
        public Knowledge()
        {
            AnswerOptions = new HashSet<AnswerOption>();
        }

        public int KnowledgeId { get; set; }
        public int? SubjectId { get; set; }
        public int? LessonId { get; set; }
        public int? DomainId { get; set; }
        public string? Knowledge1 { get; set; }
        public string? Explanation { get; set; }
        public string? Answer { get; set; }
        public int? UserId { get; set; }
        public bool? IsVerified { get; set; }

        public virtual Domain? Domain { get; set; }
        public virtual Lesson? Lesson { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Account? User { get; set; }
        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }
    }
}

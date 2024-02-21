using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class AnswerOption
    {
        public int AnswerOptionId { get; set; }
        public int? KnowledgeId { get; set; }
        public string? AnswerOption1 { get; set; }
        public bool? IsKey { get; set; }

        public virtual Knowledge? Knowledge { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class DomainType
    {
        public DomainType()
        {
            Domains = new HashSet<Domain>();
        }

        public int TypeId { get; set; }
        public int? SubjectId { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual ICollection<Domain> Domains { get; set; }
    }
}

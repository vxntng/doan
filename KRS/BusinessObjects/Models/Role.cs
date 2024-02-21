using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
            Classes = new HashSet<Class>();
            Permissions = new HashSet<Permission>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}

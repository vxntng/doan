using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassUsers = new HashSet<ClassUser>();
            Exams = new HashSet<Exam>();
            Lessons = new HashSet<Lesson>();
        }

        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public int? SubjectId { get; set; }
        public int? RoleId { get; set; }
        public int? Capacity { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? SemesterId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<ClassUser> ClassUsers { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}

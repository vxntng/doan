using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models
{
    public partial class KRSDbContext : DbContext
    {
        public KRSDbContext()
        {
        }

        public KRSDbContext(DbContextOptions<KRSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AnswerOption> AnswerOptions { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<ClassUser> ClassUsers { get; set; } = null!;
        public virtual DbSet<Discussion> Discussions { get; set; } = null!;
        public virtual DbSet<Domain> Domains { get; set; } = null!;
        public virtual DbSet<DomainType> DomainTypes { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<ExamConfig> ExamConfigs { get; set; } = null!;
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; } = null!;
        public virtual DbSet<Knowledge> Knowledges { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Progress> Progresses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<UserExam> UserExams { get; set; } = null!;
        public virtual DbSet<UserQuestion> UserQuestions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<AnswerOption>(entity =>
            {
                entity.ToTable("AnswerOption");

                entity.Property(e => e.AnswerOption1).HasColumnName("AnswerOption");

                entity.Property(e => e.IsKey).HasColumnName("isKey");

                entity.HasOne(d => d.Knowledge)
                    .WithMany(p => p.AnswerOptions)
                    .HasForeignKey(d => d.KnowledgeId)
                    .HasConstraintName("FK__AnswerOpt__Knowl__5812160E");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Class__RoleId__59063A47");
            });

            modelBuilder.Entity<ClassUser>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.UserId })
                    .HasName("PK__ClassUse__1A61AB04CF2FD73B");

                entity.ToTable("ClassUser");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassUsers)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassUser__Class__59FA5E80");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ClassUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassUser__UserI__4AB81AF0");
            });

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.ToTable("Discussion");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Discussio__Subje__5BE2A6F2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Discussio__UserI__4CA06362");
            });

            modelBuilder.Entity<Domain>(entity =>
            {
                entity.ToTable("Domain");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Domains)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__Domain__TypeId__5DCAEF64");
            });

            modelBuilder.Entity<DomainType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__DomainTy__516F03B56B55366D");

                entity.ToTable("DomainType");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.DomainTypes)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__DomainTyp__Subje__5EBF139D");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ExamName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsPractice).HasColumnName("isPractice");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Exam__ClassId__5FB337D6");
            });

            modelBuilder.Entity<ExamConfig>(entity =>
            {
                entity.ToTable("ExamConfig");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.ExamConfigs)
                    .HasForeignKey(d => d.DomainId)
                    .HasConstraintName("FK__ExamConfi__Domai__60A75C0F");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamConfigs)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__ExamConfi__ExamI__619B8048");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.ExamConfigs)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__ExamConfi__Lesso__628FA481");
            });

            modelBuilder.Entity<ExamQuestion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ExamQuestion");

                entity.HasOne(d => d.Exam)
                    .WithMany()
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__ExamQuest__ExamI__6383C8BA");

                entity.HasOne(d => d.Knowledge)
                    .WithMany()
                    .HasForeignKey(d => d.KnowledgeId)
                    .HasConstraintName("FK__ExamQuest__Knowl__6477ECF3");
            });

            modelBuilder.Entity<Knowledge>(entity =>
            {
                entity.ToTable("Knowledge");

                entity.Property(e => e.IsVerified).HasColumnName("isVerified");

                entity.Property(e => e.Knowledge1).HasColumnName("Knowledge");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.Knowledges)
                    .HasForeignKey(d => d.DomainId)
                    .HasConstraintName("FK__Knowledge__Domai__656C112C");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Knowledges)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__Knowledge__Lesso__66603565");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Knowledges)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Knowledge__Subje__6754599E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Knowledges)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Knowledge__UserI__5812160E");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Lesson__ClassId__693CA210");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Lesson__SubjectI__6A30C649");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PageId })
                    .HasName("PK__Permissi__D6AC950A349B1427");

                entity.ToTable("Permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__RoleI__6B24EA82");
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.ToTable("Progress");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Progresses)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Progress__Subjec__6C190EBB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Progresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Progress__UserId__5CD6CB2B");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");

                entity.Property(e => e.SettingName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SettingValue)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Setting__Account__5DCAEF64");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Subject__Account__5EBF139D");
            });

            modelBuilder.Entity<UserExam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserExam");

                entity.HasOne(d => d.Exam)
                    .WithMany()
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__UserExam__ExamId__6FE99F9F");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserExam__UserId__60A75C0F");
            });

            modelBuilder.Entity<UserQuestion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserQuestion");

                entity.Property(e => e.IsCorrect).HasColumnName("isCorrect");

                entity.HasOne(d => d.Exam)
                    .WithMany()
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__UserQuest__ExamI__71D1E811");

                entity.HasOne(d => d.Knowledge)
                    .WithMany()
                    .HasForeignKey(d => d.KnowledgeId)
                    .HasConstraintName("FK__UserQuest__Knowl__72C60C4A");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserQuest__UserI__6383C8BA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

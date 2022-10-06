using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class OC_DBContext : DbContext
    {
        public OC_DBContext()
        {
        }

        public OC_DBContext(DbContextOptions<OC_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountTypes> AccountTypes { get; set; }
        public virtual DbSet<AuditLogger> AuditLogger { get; set; }
        public virtual DbSet<Certificates> Certificates { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseModes> CourseModes { get; set; }
        public virtual DbSet<CoursePrices> CoursePrices { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<MediaTypes> MediaTypes { get; set; }
        public virtual DbSet<ModuleCategories> ModuleCategories { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<QuestionCategory> QuestionCategory { get; set; }
        public virtual DbSet<QuestionOption> QuestionOption { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
        public virtual DbSet<TopicContent> TopicContent { get; set; }
        public virtual DbSet<Topics> Topics { get; set; }
        public virtual DbSet<UserAnswers> UserAnswers { get; set; }
        public virtual DbSet<UserCart> UserCart { get; set; }
        public virtual DbSet<UserCourse> UserCourse { get; set; }
        public virtual DbSet<UserScores> UserScores { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server = DESKTOP-CE92CDI\\SQLEXPRESS; Database = OC_DB; Persist Security Info = True; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTypes>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId);

                entity.Property(e => e.AccountTypeId)
                    .HasColumnName("AccountTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<AuditLogger>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MetaData)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.AuditLogger)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuditLogger_Sessions");
            });

            modelBuilder.Entity<Certificates>(entity =>
            {
                entity.HasKey(e => e.CertificateId);

                entity.Property(e => e.CertificateId)
                    .HasColumnName("CertificateID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CertificateNo)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CourseModeId).HasColumnName("CourseModeID");

                entity.Property(e => e.CourseTitle)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.CourseMode)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.CourseModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_CourseModes");
            });

            modelBuilder.Entity<CourseModes>(entity =>
            {
                entity.HasKey(e => e.CourseModeId);

                entity.Property(e => e.CourseModeId)
                    .HasColumnName("CourseModeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseMode)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CoursePrices>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CoursePrices)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursePrices_Course");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.Property(e => e.MediaId)
                    .HasColumnName("MediaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.MediaTypeId).HasColumnName("MediaTypeID");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Media_MediaTypes1");
            });

            modelBuilder.Entity<MediaTypes>(entity =>
            {
                entity.HasKey(e => e.MediaTypeId);

                entity.Property(e => e.MediaTypeId)
                    .HasColumnName("MediaTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MediaType)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModuleCategories>(entity =>
            {
                entity.HasKey(e => e.ModuleCategoryId);

                entity.Property(e => e.ModuleCategoryId)
                    .HasColumnName("ModuleCategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ModuleCategory)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.Property(e => e.ModuleId)
                    .HasColumnName("ModuleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.Property(e => e.ModuleCategoryId).HasColumnName("ModuleCategoryID");

                entity.Property(e => e.ModuleDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ModuleTitle)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Modules)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modules_Course");

                entity.HasOne(d => d.ModuleCategory)
                    .WithMany(p => p.Modules)
                    .HasForeignKey(d => d.ModuleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modules_ModuleCategories");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.OptionId)
                    .HasColumnName("OptionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Option1)
                    .IsRequired()
                    .HasColumnName("Option")
                    .IsUnicode(false);

                entity.Property(e => e.QuesitonId).HasColumnName("QuesitonID");

                entity.HasOne(d => d.Quesiton)
                    .WithMany(p => p.Option)
                    .HasForeignKey(d => d.QuesitonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Option_Questions");
            });

            modelBuilder.Entity<QuestionCategory>(entity =>
            {
                entity.Property(e => e.QuestionCategoryId)
                    .HasColumnName("QuestionCategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuesitonCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestionOption>(entity =>
            {
                entity.HasKey(e => e.QuesitonOptionId);

                entity.Property(e => e.QuesitonOptionId)
                    .HasColumnName("QuesitonOptionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OptionId).HasColumnName("OptionID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.QuestionOption)
                    .HasForeignKey(d => d.OptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionOption_Option");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionOption)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionOption_Questions");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.QuestionId)
                    .HasColumnName("QuestionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Question)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.QuestionCategoryId).HasColumnName("QuestionCategoryID");

                entity.Property(e => e.TopicId).HasColumnName("TopicID");

                entity.HasOne(d => d.QuestionCategory)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_QuestionCategory");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_Topics");
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasKey(e => e.SessionId);

                entity.Property(e => e.SessionId)
                    .HasColumnName("SessionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CurrentTopicId).HasColumnName("CurrentTopicID");

                entity.Property(e => e.SessionStartTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CurrentTopic)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.CurrentTopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sessions_Topics");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sessions_Users");
            });

            modelBuilder.Entity<Subscriptions>(entity =>
            {
                entity.HasKey(e => e.SubscriptionTypeId);

                entity.Property(e => e.SubscriptionTypeId)
                    .HasColumnName("SubscriptionTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SubscriptionPlan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubscriptionPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<TopicContent>(entity =>
            {
                entity.HasKey(e => e.ContentId);

                entity.Property(e => e.ContentId)
                    .HasColumnName("ContentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.TopicContent1)
                    .IsRequired()
                    .HasColumnName("TopicContent")
                    .IsUnicode(false);

                entity.Property(e => e.TopicId).HasColumnName("TopicID");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.TopicContent)
                    .HasForeignKey(d => d.MediaId)
                    .HasConstraintName("FK_TopicContent_Media");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicContent)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopicContent_Topics");
            });

            modelBuilder.Entity<Topics>(entity =>
            {
                entity.HasKey(e => e.TopicId);

                entity.Property(e => e.TopicId)
                    .HasColumnName("TopicID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.TopicDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TopicTitle)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Topics_Modules");
            });

            modelBuilder.Entity<UserAnswers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OptionId).HasColumnName("OptionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.OptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAnswers_Option");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAnswers_Users");
            });

            modelBuilder.Entity<UserCart>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateRemoved).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.UserCart)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCart_Course");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCart_Users");
            });

            modelBuilder.Entity<UserCourse>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CertificateId).HasColumnName("CertificateID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateCompleted).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Certificate)
                    .WithMany(p => p.UserCourse)
                    .HasForeignKey(d => d.CertificateId)
                    .HasConstraintName("FK_UserCourse_Certificates");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.UserCourse)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCourse_Course");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCourse)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCourse_Users");
            });

            modelBuilder.Entity<UserScores>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateTaken).HasColumnType("datetime");

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.UserScores)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserScores_Sessions");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountTypeId).HasColumnName("AccountTypeID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SubscriptionTypeId).HasColumnName("SubscriptionTypeID");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_AccountTypes");

                entity.HasOne(d => d.SubscriptionType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.SubscriptionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Subscriptions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

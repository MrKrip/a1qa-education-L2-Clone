using Microsoft.EntityFrameworkCore;

namespace DBTests
{
    public partial class union_reportingContext : DbContext
    {
        public union_reportingContext()
        {
        }

        public union_reportingContext(DbContextOptions<union_reportingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiKey> ApiKeys { get; set; } = null!;
        public virtual DbSet<Attachment> Attachments { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<DevInfo> DevInfos { get; set; } = null!;
        public virtual DbSet<FailReason> FailReasons { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<RelFailReasonTest> RelFailReasonTests { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<Token> Tokens { get; set; } = null!;
        public virtual DbSet<Variant> Variants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConfigClass.Config["ConnectionString"], Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<ApiKey>(entity =>
            {
                entity.ToTable("api_key");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Key)
                    .HasMaxLength(255)
                    .HasColumnName("key")
                    .HasComment("API key which available for writing test info");

                entity.Property(e => e.KeyInfo)
                    .HasMaxLength(10000)
                    .HasColumnName("key_info")
                    .HasComment("Key info (external resource name project name, whatever)");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("attachment");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.TestId, "test_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasComment("Content in base64");

                entity.Property(e => e.ContentType)
                    .HasMaxLength(255)
                    .HasColumnName("content_type")
                    .HasComment("Content type (255 symbols)");

                entity.Property(e => e.TestId)
                    .HasColumnName("test_id")
                    .HasComment("Test ID (test.id)");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("attachment_ibfk_1");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Login, "author_login_u")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .HasColumnName("email")
                    .HasComment("Author email");

                entity.Property(e => e.Login)
                    .HasMaxLength(1000)
                    .HasColumnName("login")
                    .HasComment("Author login");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name")
                    .HasComment("Author name");
            });

            modelBuilder.Entity<DevInfo>(entity =>
            {
                entity.ToTable("dev_info");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.TestId, "test_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DevTime)
                    .HasColumnName("dev_time")
                    .HasComment("Test development time");

                entity.Property(e => e.TestId)
                    .HasColumnName("test_id")
                    .HasComment("Test ID (test.id)");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.DevInfos)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dev_info_ibfk_1");
            });

            modelBuilder.Entity<FailReason>(entity =>
            {
                entity.ToTable("fail_reason");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Name, "fail_reason_name_u")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsGlobal)
                    .HasColumnName("is_global")
                    .HasComment("Is current reason global for all projects?");

                entity.Property(e => e.IsSession)
                    .HasColumnName("is_session")
                    .HasComment("Is current reason available for session?");

                entity.Property(e => e.IsStatsIgnored)
                    .HasColumnName("is_stats_ignored")
                    .HasComment("Is current reason will be ignored in statistic count?");

                entity.Property(e => e.IsTest)
                    .HasColumnName("is_test")
                    .HasComment("Is current reason available for test?");

                entity.Property(e => e.IsUnchangeable)
                    .HasColumnName("is_unchangeable")
                    .HasComment("Is current reason cant be changed to other reason?");

                entity.Property(e => e.IsUnremovable)
                    .HasColumnName("is_unremovable")
                    .HasComment("Is current reason cant be deleted?");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name")
                    .HasComment("Fail reason name (1000 symbols)");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.TestId, "test_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasComment("Logs of current test");

                entity.Property(e => e.IsException)
                    .HasColumnName("is_exception")
                    .HasComment("Is current log test exception?");

                entity.Property(e => e.TestId)
                    .HasColumnName("test_id")
                    .HasComment("Test ID (test.id)");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("log_ibfk_1");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Name, "project_name_u")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name")
                    .HasComment("Project name (1000 symbols)");
            });

            modelBuilder.Entity<RelFailReasonTest>(entity =>
            {
                entity.ToTable("rel_fail_reason_test");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.FailReasonId, "fail_reason_id");

                entity.HasIndex(e => e.TestId, "test_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(10000)
                    .HasColumnName("comment")
                    .HasComment("Fail reason comment (10000 symbols)");

                entity.Property(e => e.FailReasonId)
                    .HasColumnName("fail_reason_id")
                    .HasComment("Fail reason ID (fail_reason.id)");

                entity.Property(e => e.TestId)
                    .HasColumnName("test_id")
                    .HasComment("Test ID (test.id)");

                entity.HasOne(d => d.FailReason)
                    .WithMany(p => p.RelFailReasonTests)
                    .HasForeignKey(d => d.FailReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rel_fail_reason_test_ibfk_1");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.RelFailReasonTests)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rel_fail_reason_test_ibfk_2");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildNumber)
                    .HasColumnName("build_number")
                    .HasComment("Build number");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Test start time");

                entity.Property(e => e.SessionKey)
                    .HasMaxLength(1000)
                    .HasColumnName("session_key")
                    .HasComment("Session key of current test running");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Status name (255 symbols)");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.AuthorId, "author_id");

                entity.HasIndex(e => e.ProjectId, "project_id");

                entity.HasIndex(e => e.SessionId, "session_id");

                entity.HasIndex(e => e.StatusId, "status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasComment("Author info ID (author.id)");

                entity.Property(e => e.Browser)
                    .HasMaxLength(255)
                    .HasColumnName("browser")
                    .HasDefaultValueSql("''")
                    .HasComment("Browser used for tests execution (255 symbols)");

                entity.Property(e => e.EndTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("end_time")
                    .HasComment("Test end time");

                entity.Property(e => e.Env)
                    .HasMaxLength(255)
                    .HasColumnName("env")
                    .HasComment("Node name where tests are executed (255 symbols)");

                entity.Property(e => e.MethodName)
                    .HasMaxLength(10000)
                    .HasColumnName("method_name")
                    .HasComment("Test method name (10000 symbols)");

                entity.Property(e => e.Name)
                    .HasMaxLength(10000)
                    .HasColumnName("name")
                    .HasComment("Test name (10000 symbols)");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasComment("Project ID (project.id)");

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasComment("ID of current test execution session (session.id)");

                entity.Property(e => e.StartTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("start_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Test start time");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasComment("Test execution status (status.id)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("test_ibfk_3");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("test_ibfk_1");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("test_ibfk_2");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("test_ibfk_4");
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("token");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "token_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Value, "token_value_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.VariantId, "token_variant_id_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("creation_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Value)
                    .HasMaxLength(32)
                    .HasColumnName("value");

                entity.Property(e => e.VariantId).HasColumnName("variant_id");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.Tokens)
                    .HasForeignKey(d => d.VariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("token_variant_id_fk");
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.ToTable("variant");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Id, "variant_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GrammarMistakeOnSaveProject).HasColumnName("grammar_mistake_on_save_project");

                entity.Property(e => e.GrammarMistakeOnSaveTest).HasColumnName("grammar_mistake_on_save_test");

                entity.Property(e => e.IsDynamicVersionInFooter).HasColumnName("is_dynamic_version_in_footer");

                entity.Property(e => e.UseAjaxForTestsPage).HasColumnName("use_ajax_for_tests_page");

                entity.Property(e => e.UseAlertForNewProject).HasColumnName("use_alert_for_new_project");

                entity.Property(e => e.UseFrameForNewProject).HasColumnName("use_frame_for_new_project");

                entity.Property(e => e.UseGeolocationForNewProject).HasColumnName("use_geolocation_for_new_project");

                entity.Property(e => e.UseNewTabForNewProject).HasColumnName("use_new_tab_for_new_project");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

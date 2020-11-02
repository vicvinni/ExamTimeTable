using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExamTimetableModel
{
    public partial class ExamTimetableContext : DbContext
    {
        public ExamTimetableContext()
        {
        }

        public ExamTimetableContext(DbContextOptions<ExamTimetableContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<SubjectModules> SubjectModules { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ExamTimetable;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.ExamId)
                    .HasColumnName("ExamID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ExamDate).HasColumnType("date");

                entity.Property(e => e.ExamRoom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExamNavigation)
                    .WithOne(p => p.Exam)
                    .HasForeignKey<Exam>(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubjectModules>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.ModeuleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.ExamNavigation)
                    .WithMany(p => p.SubjectModules)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__SubjectMo__ExamI__4222D4EF");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.SubjectModules)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_SubjectModules");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.Property(e => e.SubjectId)
                    .HasColumnName("SubjectID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithOne(p => p.Subjects)
                    .HasForeignKey<Subjects>(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subjects");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

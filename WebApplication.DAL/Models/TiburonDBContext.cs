using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.DAL.Models
{
    public partial class TiburonDBContext : DbContext
    {
        public TiburonDBContext()
        {
        }

        public TiburonDBContext(DbContextOptions<TiburonDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Interview> Interview { get; set; }
        public virtual DbSet<InterviewQuestionAnswer> InterviewQuestionAnswer { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TiburonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        internal object where()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.AnswerText).HasMaxLength(50);
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<InterviewQuestionAnswer>(entity =>
            {
                entity.HasKey(e => new { e.InterviewId, e.QuestionId, e.AnswerId });

                entity.ToTable("Interview_Question_Answer");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.InterviewQuestionAnswer)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Interview_Question_Answer_ToAnswer");

                entity.HasOne(d => d.Interview)
                    .WithMany(p => p.InterviewQuestionAnswer)
                    .HasForeignKey(d => d.InterviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Interview_Question_Answer_ToInterview");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.InterviewQuestionAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Interview_Question_Answer_ToQuestion");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionText).HasMaxLength(100);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.Property(e => e.SurveyId)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.Property(e => e.ServeyName).HasMaxLength(50);
            });
        }
    }
}

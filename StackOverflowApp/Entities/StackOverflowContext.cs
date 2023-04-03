using Microsoft.EntityFrameworkCore;

namespace StackOverflowApp.Entities
{
    public class StackOverflowContext: DbContext
    {
        public StackOverflowContext(DbContextOptions<StackOverflowContext> options) : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);


            modelBuilder.Entity<Question>(q =>
            {
                q.Property(x => x.Rating)
                .HasDefaultValue(0);

                q.Property(x => x.Title)
                .HasMaxLength(500);

                q.Property(x => x.ContentOfQuestion)
                .HasColumnName("Content_of_question");

                q.HasMany(x => x.Comments)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId);

                q.HasMany(x=>x.Tags)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId);

                q.HasMany(x=>x.Answers)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId);
            });


            modelBuilder.Entity<Answer>(a =>
            {
                a.Property(x => x.ContentOfAnswer)
                .HasColumnName("Content_of_answer");

                a.Property(x => x.Rating)
                .HasDefaultValue(0);

                a.HasMany(x => x.Comments)
                .WithOne(x => x.Answer)
                .HasForeignKey(x => x.AnswerId)
                .OnDelete(DeleteBehavior.ClientCascade);

            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasMany(x => x.Questions)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);

                u.HasMany(x=>x.Comments)
                .WithOne(X=>X.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.ClientCascade);


                u.HasMany(x => x.Answers)
                .WithOne(X => X.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.ClientCascade);
                ;
            });

        }
    }
}

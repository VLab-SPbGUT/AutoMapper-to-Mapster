using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Data
{
    public class StudentContext(DbContextOptions<StudentContext> options) : DbContext(options)
    {
        public DbSet<Discipline> Disciplines { get;set; }

        public DbSet<Lesson> Lessons { get;set; }

        public DbSet<ExerciseBlock> ExerciseBlocks { get;set; }

        public DbSet<Exercise> Exercises { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discipline>().OwnsOne(p=>p.Student);

            modelBuilder.Entity<Lesson>().OwnsOne(p => p.Theory);

            modelBuilder.Entity<ExerciseBlock>().OwnsOne(p => p.Theory);

            modelBuilder.Entity<ExerciseBlock>().OwnsOne(p => p.GeneralInformation);

            modelBuilder.Entity<Exercise>().OwnsOne(p => p.MethodicalInstructions);

            modelBuilder.Entity<Exercise>().OwnsOne(p => p.Test);

            modelBuilder.Entity<Exercise>().OwnsOne(p => p.Example);

            modelBuilder.Entity<AnswerOption>().OwnsOne(p => p.Answer);
        }
    }
}

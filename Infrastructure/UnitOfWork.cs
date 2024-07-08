using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public sealed class UnitOfWork(StudentContext context)
    {
        public readonly IRepository<Discipline> DisciplineRepository = new DisciplineRepository(context);

        public readonly IRepository<Lesson> LessonRepository = new LessonRepository(context);

        public readonly IRepository<Exercise> ExerciseRepository = new ExerciseRepository(context);   

        public readonly IRepository<ExerciseBlock> ExerciseBlockRepository = new ExerciseBlockRepository(context);

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

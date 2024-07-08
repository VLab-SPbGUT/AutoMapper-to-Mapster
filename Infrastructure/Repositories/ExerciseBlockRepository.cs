using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ExerciseBlockRepository(StudentContext context) : BaseRepository<ExerciseBlock>(context)
    {
    }
}

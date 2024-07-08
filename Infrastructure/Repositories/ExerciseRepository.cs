using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ExerciseRepository(StudentContext context) : BaseRepository<Exercise>(context)
    {
        public override async Task<Exercise?> GetEntityByIdAsync(Guid id)
        {
            return await context.Exercises
                .Include(p => p.Answers).FirstOrDefaultAsync(p=>p.Id == id);
        }
    }
}

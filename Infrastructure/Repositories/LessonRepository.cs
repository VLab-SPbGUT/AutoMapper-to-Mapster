using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class LessonRepository(StudentContext context) : BaseRepository<Lesson>(context)
    {
    }
}

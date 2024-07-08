using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public sealed class DisciplineRepository(StudentContext context) : BaseRepository<Discipline>(context)
    {
    }
}

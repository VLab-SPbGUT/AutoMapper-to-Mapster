using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<T>(StudentContext context) : IRepository<T> where T : class
    {
        internal readonly StudentContext _context = context;

        public virtual void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual async Task<ICollection<T>> GetEntitiesByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<ICollection<T>> GetAllEntitiesAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetEntityByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T?> GetEntityByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}

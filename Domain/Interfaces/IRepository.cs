﻿using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void AddEntity(T entity);

        void DeleteEntity(T entity);

        void UpdateEntity(T entity);

        Task<ICollection<T>> GetAllEntitiesAsync();

        Task<ICollection<T>> GetEntitiesByAsync(Expression<Func<T, bool>> predicate);

        Task<T?> GetEntityByIdAsync(Guid id);

        Task<T?> GetEntityByAsync(Expression<Func<T, bool>> predicate);
    }
}

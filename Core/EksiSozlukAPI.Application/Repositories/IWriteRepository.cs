using EksiSozlukAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
namespace EksiSozlukAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);
        Task<bool> RemoveByIdAsync(string id);
        bool Update(T entity);
        Task<int> SaveAsync();

    }
}

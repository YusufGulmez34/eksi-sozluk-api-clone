﻿using EksiSozlukAPI.Application.Repositories;
using EksiSozlukAPI.Domain.Entities.Common;
using EksiSozlukAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EksiSozlukAPI.Persistence.Repositories
{
    public abstract class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        private readonly EksiSozlukAPIDbContext _context;

        public WriteRepository(EksiSozlukAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public EksiSozlukAPIDbContext Context => _context;

        public virtual async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entry = await Table.AddAsync(entity);            
            return entry.State == EntityState.Added;

        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entry = Table.Remove(entity);
            return entry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            T entity = await Table.FirstOrDefaultAsync(e => e.Id == id);
            return Remove(entity);
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(T entity)
        {
            
            EntityEntry entry = Table.Update(entity);
            return entry.State == EntityState.Modified;
        }
    }
}

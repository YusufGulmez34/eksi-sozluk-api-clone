using EksiSozlukAPI.Application.Repositories;
using EksiSozlukAPI.Domain.Entities.Common;
using EksiSozlukAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EksiSozlukAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly EksiSozlukAPIDbContext _context;

        public ReadRepository(EksiSozlukAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public EksiSozlukAPIDbContext Context => _context; 
        public IQueryable<T> FindAll()
        {
            
            IQueryable<T>  query = Table.AsQueryable();
            if (query == null || query.Count() == 0)
            {
                return null;
            }
            return query;
        }

        public async Task<T> FindByIdAsync(string id)
        {
            T entity = await Table.FirstOrDefaultAsync(e => e.Id == Guid.Parse(id));
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> filter)
        {
            T entity = await Table.FirstOrDefaultAsync(filter);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public IQueryable<T> FindWhere(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> entity = Table.Where(filter);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }
    }
}

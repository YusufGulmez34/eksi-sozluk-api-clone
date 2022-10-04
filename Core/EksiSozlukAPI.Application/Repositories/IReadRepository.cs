using EksiSozlukAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace EksiSozlukAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindWhere(Expression<Func<T, bool>> filter);
        Task<T> FindSingleAsync(Expression<Func<T, bool>> filter);
        Task<T> FindByIdAsync(string id);
        IQueryable<T> FindPaged(int pageNumber, int pageSize, Expression<Func<T, bool>> filter);
    }
}

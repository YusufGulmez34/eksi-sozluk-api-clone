using EksiSozlukAPI.Application.Repositories.Entry;
using EksiSozlukAPI.Persistence.Contexts;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Repositories.Entry
{
    public class EntryReadRepository : ReadRepository<E.Entry>, IEntryReadRepository
    {
        public EntryReadRepository(EksiSozlukAPIDbContext context) : base(context)
        {
        }
    }
}

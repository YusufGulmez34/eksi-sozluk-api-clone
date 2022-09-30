using EksiSozlukAPI.Application.Repositories.Entry;
using EksiSozlukAPI.Persistence.Contexts;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Repositories.Entry
{
    public class EntryWriteRepository : WriteRepository<E.Entry>, IEntryWriteRepository
    {
        public EntryWriteRepository(EksiSozlukAPIDbContext context) : base(context)
        {
        }
    }
}

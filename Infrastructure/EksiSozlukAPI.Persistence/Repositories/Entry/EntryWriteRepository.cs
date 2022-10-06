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
        public override async Task<bool> AddAsync(E.Entry entity)
        {
            bool result = await base.AddAsync(entity);
            if (!result) return false;
            E.Title title = Context.Titles.First(t => t.Id == entity.TitleId);
            title.EntryCount++;
            Context.Titles.Update(title);
            return true;
        }
    }
}

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

        public List<E.Entry> GetEntryListByTitleId(int pageNumber, int pageSize, string titleId)
        {
            return (from entry in Context.Entries
                    join title in Context.Titles
                    on entry.TitleId equals title.Id
                    join user in Context.Users
                    on entry.UserId equals user.Id
                    where entry.TitleId == Guid.Parse(titleId)                
                    orderby entry.CreatedDate ascending                   
                    select new E.Entry
                    {
                        Id = entry.Id,
                        Title = title,
                        User = user,
                        Body = entry.Body,
                        CreatedDate = entry.CreatedDate,
                        UpdatedDate = entry.UpdatedDate,
                        FavCount = entry.FavCount,
                    }).Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
        }
    }
}

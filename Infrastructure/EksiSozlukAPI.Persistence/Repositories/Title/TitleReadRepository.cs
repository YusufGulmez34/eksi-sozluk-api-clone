using EksiSozlukAPI.Application.Repositories.Title;
using EksiSozlukAPI.Persistence.Contexts;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Repositories.Title
{
    internal class TitleReadRepository : ReadRepository<E.Title>, ITitleReadRepository
    {
        public TitleReadRepository(EksiSozlukAPIDbContext context) : base(context)
        {
        }

        public async Task<List<E.Title>> GetTitleListByChannelId(int channelId, int pageNumber, int pageSize)
        {
            DateTime lastHour = DateTime.UtcNow.Subtract(TimeSpan.FromHours(3));
            DateTime now = DateTime.UtcNow;
            var list = (from title in Table
                        where title.ChannelId == channelId
                        select new E.Title()
                        {
                            Id = title.Id,
                            Name = title.Name,
                            EntryCount = title.Entries.Where(e => e.CreatedDate >= lastHour && e.CreatedDate <= now).Count()
                        }).Take(300).ToList();
            return list.OrderByDescending(t => t.EntryCount).Take(300).ToList();
        }

        public async Task<List<E.Title>> GetTitleListByJournal(int pageNumber, int pageSize)
        {
            DateTime lastHour = DateTime.UtcNow.Subtract(TimeSpan.FromHours(3));
            DateTime now = DateTime.UtcNow;
            var list = (from title in Table
                        select new E.Title()
                        {
                            Id = title.Id,
                            Name = title.Name,
                            EntryCount = title.Entries.Where(e => e.CreatedDate >= lastHour && e.CreatedDate <= now).Count()
                        }).Take(300).ToList();
            return list.OrderByDescending(t => t.EntryCount).ToList();
        }
    }
}

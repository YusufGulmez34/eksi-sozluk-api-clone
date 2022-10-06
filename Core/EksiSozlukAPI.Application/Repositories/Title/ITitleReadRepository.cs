using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Application.Repositories.Title
{
    public interface ITitleReadRepository : IReadRepository<E.Title>
    {
        Task<List<E.Title>> GetTitleListByJournal(int pageNumber, int pageSize);
        Task<List<E.Title>> GetTitleListByChannelId(int channelId, int pageNumber, int pageSize);


    }
}

using EksiSozlukAPI.Application.Repositories.Title;
using EksiSozlukAPI.Persistence.Contexts;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Repositories.Title
{
    public class TitleWriteRepository : WriteRepository<E.Title>, ITitleWriteRepository
    {
        public TitleWriteRepository(EksiSozlukAPIDbContext context) : base(context)
        {
        }
    }
}

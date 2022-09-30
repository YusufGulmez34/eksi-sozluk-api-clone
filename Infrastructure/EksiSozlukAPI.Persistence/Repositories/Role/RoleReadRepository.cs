using EksiSozlukAPI.Application.Repositories.Role;
using EksiSozlukAPI.Persistence.Contexts;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Repositories.Role
{
    public class RoleReadRepository : ReadRepository<E.Role>, IRoleReadRepository
    {
        public RoleReadRepository(EksiSozlukAPIDbContext context) : base(context)
        {
        }


    }
}

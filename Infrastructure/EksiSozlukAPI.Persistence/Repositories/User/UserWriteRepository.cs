using EksiSozlukAPI.Application.Repositories.User;
using EksiSozlukAPI.Persistence.Contexts;
using E = EksiSozlukAPI.Domain.Entities;
namespace EksiSozlukAPI.Persistence.Repositories.User
{
    public class UserWriteRepository : WriteRepository<E.User>, IUserWriteRepository
    {
        public UserWriteRepository(EksiSozlukAPIDbContext context) : base(context)
        {
        }
        public override async Task<bool> AddAsync(E.User entity)
        {
            Guid roleId = Context.Roles.First(r => r.Name == "user").Id;
            entity.UserRoles.Add(new () { RoleId = roleId });
            await Context.SaveChangesAsync();
            return await base.AddAsync(entity);
        }
    }
}

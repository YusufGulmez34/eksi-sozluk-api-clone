using EksiSozlukAPI.Application.Repositories.User;
using EksiSozlukAPI.Persistence.Contexts;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Repositories.User
{
    public class UserReadRepository : ReadRepository<E.User>, IUserReadRepository
    {
        public UserReadRepository(EksiSozlukAPIDbContext context) : base(context)
        {
        }

        public List<string> GetUserRolesById(int userId)
        {
            return (from user in Context.Users
                    join user_roles in Context.UserRoles
                    on user.Id equals user_roles.UserId
                    join role in Context.Roles
                    on user_roles.RoleId equals role.Id
                    where user.Id == userId
                    select role.Name).ToList();
        }
    }
}

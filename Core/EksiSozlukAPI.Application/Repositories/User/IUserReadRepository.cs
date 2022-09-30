using E = EksiSozlukAPI.Domain.Entities;
namespace EksiSozlukAPI.Application.Repositories.User
{
    public interface IUserReadRepository : IReadRepository<E.User>
    {
         List<string> GetUserRolesById(string userId);

    }
}

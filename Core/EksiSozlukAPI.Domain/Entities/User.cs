

using EksiSozlukAPI.Domain.Entities.Common;

namespace EksiSozlukAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Entry> Entries { get; set; }

        public User()
        {
            UserRoles = new List<UserRole>();
            Entries = new List<Entry>();
        }

    }
}

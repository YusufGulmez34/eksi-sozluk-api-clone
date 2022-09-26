using EksiSozlukAPI.Domain.Entities.Common;

namespace EksiSozlukAPI.Domain.Entities
{
    public class Entry : BaseEntity
    {
        public string Message { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public Guid TitleId { get; set; }
        public Title Title { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

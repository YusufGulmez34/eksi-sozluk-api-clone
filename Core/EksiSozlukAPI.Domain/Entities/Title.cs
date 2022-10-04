using EksiSozlukAPI.Domain.Entities.Common;

namespace EksiSozlukAPI.Domain.Entities
{
    public class Title : BaseEntity
    {
        public string Name { get; set; }
        public int EntryCount { get; set; }
        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; }
        public ICollection<Entry> Entries { get; set; }
        public Title()
        {
            Entries = new List<Entry>();
        }
    }
}

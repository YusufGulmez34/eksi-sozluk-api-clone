using EksiSozlukAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Domain.Entities
{
    public class Title : BaseEntity
    {
        public string Name { get; set; }
        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; }
        ICollection<Entry>? Entries { get; set; }
        public int EntryCount { get; set; }
    }
}

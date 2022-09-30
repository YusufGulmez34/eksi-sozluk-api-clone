using EksiSozlukAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Domain.Entities
{
    public class Entry : BaseEntity
    {
        public string Body { get; set; }
        public int FavCount { get; set; }
        public Guid TitleId { get; set; }
        public Title Title { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

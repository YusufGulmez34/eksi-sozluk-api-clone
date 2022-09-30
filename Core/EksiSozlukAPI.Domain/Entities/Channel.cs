using EksiSozlukAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Domain.Entities
{
    public class Channel : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Title> Titles { get; set; }
        public Channel()
        {
            Titles = new List<Title>();
        }
    }
}

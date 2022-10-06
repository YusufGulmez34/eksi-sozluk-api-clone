using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.DTOs
{
    public class EntryListItem
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int FavCount { get; set; }
        public EntryTitle Title { get; set; }
        public EntryUser User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

﻿using EksiSozlukAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Entry> Entries { get; set; }
    }
}

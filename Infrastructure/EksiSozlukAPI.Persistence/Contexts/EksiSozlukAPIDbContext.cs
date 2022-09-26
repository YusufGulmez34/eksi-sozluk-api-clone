using EksiSozlukAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Persistence.Contexts
{
    public class EksiSozlukAPIDbContext : DbContext
    {
        public EksiSozlukAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entry> Entry { get; set; }
        public DbSet<Channel> Channel { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<User> User { get; set; }
    }
}
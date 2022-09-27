using EksiSozlukAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using cloudscribe.EFCore.PostgreSql.Conventions;

namespace EksiSozlukAPI.Persistence.Contexts
{
    public class EksiSozlukAPIDbContext : DbContext
    {

        public EksiSozlukAPIDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplySnakeCaseConventions();
        }

        public DbSet<Entry> Entry { get; set; }
        public DbSet<Channel> Channel { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<User> User { get; set; }


    }
}
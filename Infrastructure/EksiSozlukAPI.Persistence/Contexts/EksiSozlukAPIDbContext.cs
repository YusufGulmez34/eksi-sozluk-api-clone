using EksiSozlukAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using cloudscribe.EFCore.PostgreSql.Conventions;
using EksiSozlukAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EksiSozlukAPI.Persistence.Contexts
{
    public class EksiSozlukAPIDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Entry> Entries { get; set; }


        public EksiSozlukAPIDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplySnakeCaseConventions();

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Role>().HasData(new List<Role>()
            {
                new () { Id = 1, Name = "admin" },
                new () { Id = 2, Name = "user" }
            });

            modelBuilder.Entity<Channel>().HasData(new List<Channel>()
            {
                new () { Id = 1, Name = "spor" },
                new () { Id = 2, Name = "siyaset" },
                new () { Id = 3, Name = "sinema" },
                new () { Id = 4, Name = "sanat" },
                new () { Id = 5, Name = "bilim" },
                new () { Id = 7, Name = "edebiyat" }
            });

            base.OnModelCreating(modelBuilder);
        }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

using LocalMind.API.Models.UserAdditionalDetails;
using LocalMind.API.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace LocalMind.API.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAdditionalDetail> UserAdditionalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAdditionalDetail>()
                .HasOne(userAdditionalDetail => userAdditionalDetail.User)
                .WithOne(user => user.UserAdditionalDetail)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}

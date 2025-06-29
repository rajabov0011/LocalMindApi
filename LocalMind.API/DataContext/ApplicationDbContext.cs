using LocalMind.API.Models.ChatDetails;
using LocalMind.API.Models.Chats;
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
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatDetail> ChatDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAdditionalDetail>()
                .HasOne(userAdditionalDetail => userAdditionalDetail.User)
                .WithOne(user => user.UserAdditionalDetail)
                .HasForeignKey<UserAdditionalDetail>(
                    userAdditionalDetail => userAdditionalDetail.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}

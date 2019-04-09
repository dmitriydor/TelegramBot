using Microsoft.EntityFrameworkCore;

namespace TestBot.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.From);
        }

        public DbSet<User> Users { get; set; }
    }
}

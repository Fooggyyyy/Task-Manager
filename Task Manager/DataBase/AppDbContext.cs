using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Task_Manager.Models;

namespace Task_Manager.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskInManage> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskInManage>()
                .HasKey(t => t.Id);
        }
    }
}
using Microsoft.EntityFramework;
using rat2.models;
using System.Data.Entity;

namespace rat2
{
    public class BotDbContext : DbContext
    {
        public DbSet<usersmodel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere"); // Замените на строку подключения к вашей базе данных
        }
    }
}
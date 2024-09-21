using System.Data.Entity;
using rat2.models;

namespace rat2
{
    public class BotDbContext : DbContext
    {
        public BotDbContext() : base("name=BotDbConnection") // Указываем имя строки подключения
        {
        }

        public DbSet<UsersModel> Users { get; set; }
    }
}
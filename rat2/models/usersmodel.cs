using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rat2.models
{
    [Table("Users")]  // Если хотите указать конкретное имя таблицы
    public class UsersModel
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public string Username { get; set; } // Username of the user
        public string Role { get; set; } // Role of the user (admin, tester, etc.)
        public bool IsBlacklisted { get; set; } // Indicates if user is blacklisted
    }
}

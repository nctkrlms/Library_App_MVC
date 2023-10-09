using System.ComponentModel.DataAnnotations;

namespace Library_App.Data.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; } = 2;
        public virtual Role? Role { get; set; }
        public List<Book>? Books { get; set; }
    }
}

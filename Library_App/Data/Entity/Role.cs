using System.ComponentModel.DataAnnotations;

namespace Library_App.Data.Entity
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}

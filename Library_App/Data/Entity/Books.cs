using Library_App.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_App.Data.Entity
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime? BorrowDate { get; set; }
        [ForeignKey("AppUserId")]
        public string? AppUserId { get; set; }
        public virtual ApplicationUser? user { get; set; }
        public bool IsDeleted { get; set; }




    }
}
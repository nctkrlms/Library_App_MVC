using Library_App.Data.Entity;

namespace Library_App.Data
{
    public class AddBookViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsBorrowed { get; set; } = false;
        public DateTime? BorrowDate { get; set; } = null;
        public bool IsDeleted { get; set; } = false;

    }
}

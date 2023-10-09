namespace Library_App.Data.Entity
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime? BorrowDate { get; set; }
        public bool IsDeleted { get; set; }


        public int? UserId { get; set; }
        public User? user { get; set; }

    }
}

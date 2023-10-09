using Library_App.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}

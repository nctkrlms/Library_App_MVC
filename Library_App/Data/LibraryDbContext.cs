using Library_App.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        
        public DbSet<Books> Books { get; set; }
    }
}
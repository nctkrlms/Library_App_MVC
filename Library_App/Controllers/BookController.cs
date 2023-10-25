using Library_App.Areas.Identity.Data;
using Library_App.Data;
using Library_App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library_App.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public BookController(LibraryDbContext libraryDbContext, UserManager<ApplicationUser> userManager)
        {
            this.libraryDbContext = libraryDbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        
        public async Task<IActionResult> Index()
        {
            UserBookViewModel model = new UserBookViewModel();

            if (!User.Identity.IsAuthenticated)
            {
                // Kullanıcı oturum açmamışsa, sadece kitapları listeleyin
                var books = await libraryDbContext.Books.ToListAsync();
                var users = await userManager.Users.ToListAsync();
                model.Books = books;
                model.UserList = users;

                return View(model);
            }
            else
            {
                var user = await userManager.GetUserAsync(User);
                model.User = user;

                var books = await libraryDbContext.Books.ToListAsync();
                var users = await userManager.Users.ToListAsync();
                model.Books = books;
                model.UserList = users;
                return View(model);
            }
        }
        
        
        
        
        
        [HttpGet]

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddBook(AddBookViewModel addBookViewModel)
        {
            var book = new Books()
            {
                Name = addBookViewModel.Name,
                Description = addBookViewModel.Description,
                Author = addBookViewModel.Author,
                ImageUrl = addBookViewModel.ImageUrl,
                IsBorrowed = addBookViewModel.IsBorrowed,
                BorrowDate = addBookViewModel.BorrowDate,
                IsDeleted = addBookViewModel.IsDeleted
            };
            await libraryDbContext.Books.AddAsync(book);
            await libraryDbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        [HttpGet]

        public async Task<IActionResult> Detail(int id)
        {
            var book = await libraryDbContext.Books.FindAsync(id);
            return View(book);
        }

        [HttpPost]
        [Authorize] // Bu aksiyonu sadece giriş yapmış kullanıcılar çağırabilsin
        public IActionResult AssignBook(int bookId, DateTime borrowDate)
        {
            // Burada giriş yapmış olan kullanıcının kimliğini alın
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Burada kitap kaydını veritabanında güncelleyin ve kullanıcı kimliğini atayın
            var book = libraryDbContext.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                book.AppUserId = userId; // Kitabın sahibi olarak kullanıcı kimliğini atayın
                book.BorrowDate = borrowDate.Date;

                libraryDbContext.SaveChanges();
                
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound("Kitap bulunamadı!");
            }
            
        }

        [HttpPost]
        public IActionResult UpdateIsBorrowed(int bookId)
        {
            var book = libraryDbContext.Books.Find(bookId);
            if (book != null)
            {
                // Kitap bulundu ve güncelleme yapılacak
                book.IsBorrowed = true;
                libraryDbContext.SaveChanges(); // Değişiklikleri veritabanına kaydet

                return Ok("Kitap kiralama işlemi başarılı!"); // Başarılı yanıt
            }

            // Kitap bulunamadı veya güncelleme sırasında hata oluştu
            return BadRequest("Kitap kiralama işlemi başarısız!");
        }

        [HttpPost]
        public IActionResult ReturnBook(int bookId)
        {
            var book = libraryDbContext.Books.Find(bookId);

            if (book != null)
            {
                // Kitabı teslim et
                book.AppUserId = null; // Kullanıcı ID'sini null'a çek
                book.IsBorrowed = false;
                libraryDbContext.SaveChanges();
                return Ok("Kitap kiralama işlemi başarılı!");
            }

            return BadRequest("Kitap kiralama işlemi başarısız!");
        }
    }
}

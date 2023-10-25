


using Library_App.Areas.Identity.Data;
using Library_App.Data.Entity;

    

namespace Library_App.Data{
public class UserBookViewModel
{
    public List<Books>? Books { get; set; }
    public List<ApplicationUser>? UserList { get; set; }
    public ApplicationUser? User { get; set; }
}
 }
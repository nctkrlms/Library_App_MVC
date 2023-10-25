using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_App.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace Library_App.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Books>? Books { get; set; }

}


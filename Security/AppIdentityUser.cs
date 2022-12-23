using Microsoft.AspNetCore.Identity;

namespace CRUD1.Security
{
    public class AppIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        // UserName, Email, etc vienen de IdentityUser


    }
}

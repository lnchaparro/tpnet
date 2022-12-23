using Microsoft.AspNetCore.Identity;

namespace CRUD1.Security
{
    public class AppIdentityRole : IdentityRole
    {
        public string Description { get; set; }

        // Name viene de IdentityRole

    }
}

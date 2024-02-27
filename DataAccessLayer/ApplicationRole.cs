using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer
{
    public class ApplicationRole : IdentityRole
    {
        public bool Rols { get; set; }
        // other properties and methods
    }
}
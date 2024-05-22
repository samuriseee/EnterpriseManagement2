using Microsoft.AspNetCore.Identity;

namespace WebApplication8.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Role { get; set; } = 0!;

    }
}


using Microsoft.AspNetCore.Identity;

namespace TestClean.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? ProfileImageUrl { get; set; }
    }
}

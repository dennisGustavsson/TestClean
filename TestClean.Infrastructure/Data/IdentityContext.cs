using Microsoft.EntityFrameworkCore;
using TestClean.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TestClean.Infrastructure.Data;

public class IdentityContext : IdentityDbContext<ApplicationUser>
{
    public IdentityContext(DbContextOptions options) : base(options)
    {
    }
}

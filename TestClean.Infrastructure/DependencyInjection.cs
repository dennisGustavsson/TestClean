using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestClean.Domain.Interfaces;
using TestClean.Infrastructure.Data;
using TestClean.Infrastructure.Repositories;



namespace TestClean.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add database context
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Add repositories
            services.AddScoped< IMeetingRepository, MeetingRepository>();
            // Add other repositories...

            return services;
        }
    }
}

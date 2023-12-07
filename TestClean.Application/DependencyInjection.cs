using Microsoft.Extensions.DependencyInjection;
using TestClean.Application.Interfaces;
using TestClean.Application.Services;


namespace TestClean.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<IMeetingService, MeetingService>();
            return services;
        }
            

    }
}

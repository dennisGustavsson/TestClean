using Microsoft.Extensions.DependencyInjection;
using TestClean.Application.Interfaces;
using TestClean.Application.Meeting.Commands;
using TestClean.Application.Services;


namespace TestClean.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<IMeetingService, MeetingService>();
/*            services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(CreateMeeting).Assembly));*/
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));


            return services;
        }
            

    }
}

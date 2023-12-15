using Microsoft.Extensions.DependencyInjection;
using TestClean.Application.Interfaces;
using TestClean.Application.Meeting.CommandHandlers;
using TestClean.Application.Meeting.Commands;
using TestClean.Application.Services;
using MediatR;
using TestClean.Domain.Entities;
using System.Net.NetworkInformation;

namespace TestClean.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<IMeetingService, MeetingService>();
            services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(CreateMeeting).Assembly));


            return services;
        }
            

    }
}

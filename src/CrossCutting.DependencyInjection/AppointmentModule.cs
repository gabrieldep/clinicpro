using Appointment.Application;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection;

internal static class AppointmentModule
{
    public static void AddAppointmentModule(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(CreateAppointment).Assembly);
            config.RegisterServicesFromAssembly(typeof(UpdateAppointment).Assembly);
            config.RegisterServicesFromAssembly(typeof(DeleteAppointment).Assembly);
        });
    }
}
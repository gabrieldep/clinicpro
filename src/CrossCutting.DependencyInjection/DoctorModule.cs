using Doctor.Application;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection;

internal static class DoctorModule
{
    public static void AddDoctorModule(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(CreateDoctor).Assembly);
        });
    }
}
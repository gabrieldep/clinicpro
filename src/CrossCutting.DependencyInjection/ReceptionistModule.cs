using Doctor.Application;
using Microsoft.Extensions.DependencyInjection;
using Patient.Application;
using Receptionist.Application;

namespace CrossCutting.DependencyInjection;

internal static class ReceptionistModule
{
    public static void AddReceptionistModule(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(CreateReceptionist).Assembly);
        });
    }
}
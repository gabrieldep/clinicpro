using Doctor.Application;
using Microsoft.Extensions.DependencyInjection;
using Patient.Application;

namespace CrossCutting.DependencyInjection;

internal static class PatientModule
{
    public static void AddPatientModule(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(CreatePatient).Assembly);
            config.RegisterServicesFromAssembly(typeof(DeletePatient).Assembly);
            config.RegisterServicesFromAssembly(typeof(UpdatePatient).Assembly);
            config.RegisterServicesFromAssembly(typeof(GetPatientAppointments).Assembly);
        });
    }
}
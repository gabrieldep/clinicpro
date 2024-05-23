using Appointment.Domain;
using Data.Repositories;
using Doctor.Domain;
using Microsoft.Extensions.DependencyInjection;
using Patient.Domain;
using Person.Domain;
using Receptionist.Domain;
using Registration.Domain;

namespace CrossCutting.DependencyInjection;

internal static class DataModule
{
    public static void AddDataModule(this IServiceCollection services)
    {
        services
            .AddScoped<IPatientRepository, PatientRepository>()
            .AddScoped<IDoctorRepository, DoctorRepository>()
            .AddScoped<IAppointmentRepository, AppointmentRepository>()
            .AddScoped<IReceptionistRepository, ReceptionistRepository>()
            .AddScoped<IRegistrationRepository, RegistrationRepository>()
            .AddScoped<IPersonRepository, PersonRepository>();
    }
}

using Doctor.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Patient.Application.Validators;

namespace CrossCutting.DependencyInjection;

internal static class ValidatorModule
{
    public static void AddValidatorModule(this IServiceCollection services)
    {
        services.AddTransient<IValidator<DoctorTimesAvaiable>, GetAppointmentTimesValidator>();
        services.AddTransient<IValidator<PatientAppointments>, GetPatientAppointmentsValidator>();
    }
}
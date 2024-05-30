using Doctor.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection;

internal static class ValidatorModule
{
    public static void AddValidatorModule(this IServiceCollection services)
    {
        services.AddTransient<IValidator<DoctorTimesAvaiable>, GetAppointmentTimesValidator>();
    }
}
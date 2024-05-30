using Doctor.Domain;
using FluentValidation;

namespace Doctor.Application.Validators;

public class GetAppointmentTimesValidator : AbstractValidator<DoctorTimesAvaiable>
{
    private readonly IDoctorRepository _doctors;

    public GetAppointmentTimesValidator(IDoctorRepository doctors)
    {
        _doctors = doctors;
        
        RuleFor(x => x.DoctorId)
            .NotEmpty().NotNull().WithMessage("Doctor ID é necessário para completar a requisição.")
            .MustAsync(BeAValidGuidAsync).WithMessage("Não foi possível encontrar carteira com esse GUID.");
    }
    
    private async Task<bool> BeAValidGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        var doctor = await _doctors.GetAsync(guid, cancellationToken);
        return doctor != null;
    }
}
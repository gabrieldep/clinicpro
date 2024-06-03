using FluentValidation;
using Patient.Domain;

namespace Patient.Application.Validators;

public class GetPatientAppointmentsValidator : AbstractValidator<PatientAppointments>
{
    private readonly IPatientRepository _patients;

    public GetPatientAppointmentsValidator(IPatientRepository patients)
    {
        _patients = patients;
        
        RuleFor(x => x.PatientId)
            .NotEmpty().NotNull().WithMessage("Patient ID é necessário para completar a requisição.")
            .MustAsync(BeAValidGuidAsync).WithMessage("Não foi possível encontrar paciente com esse GUID.");
    }
    
    private async Task<bool> BeAValidGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        var patient = await _patients.GetAsync(guid, cancellationToken);
        return patient != null;
    }
}
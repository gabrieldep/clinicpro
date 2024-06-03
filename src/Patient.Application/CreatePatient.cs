using MediatR;
using Patient.Domain;

namespace Patient.Application;

public class CreatePatient : IRequest<Guid>
{
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; }
    public string CPF { get; set; }
    public DateOnly Birth { get; set; }
}

public class CreatePatientHandler(IPatientRepository patients) : IRequestHandler<CreatePatient, Guid>
{
    public async Task<Guid> Handle(CreatePatient request, CancellationToken cancellationToken)
    {
        var patient = new Domain.Patient()
        {
            UserName = request.User,
            Password = request.Password,
            Name = request.Name,
            Birth = request.Birth,
            CPF = request.CPF
        };

        await patients.InsertAsync(patient, cancellationToken);
        return patient.Id;
    }
}
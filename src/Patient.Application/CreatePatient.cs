using MediatR;
using Patient.Domain;

namespace Patient.Application;

public class CreatePatient : IRequest<Guid>
{
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; }
    public DateOnly Birth { get; set; }
}

public class CreatePersonHandler(IPatientRepository receptionists) : IRequestHandler<CreatePatient, Guid>
{
    public async Task<Guid> Handle(CreatePatient request, CancellationToken cancellationToken)
    {
        var receptionist = new Domain.Patient()
        {
            UserName = request.User,
            Password = request.Password,
            Name = request.Name,
            Birth = request.Birth
        };

        await receptionists.InsertAsync(receptionist, cancellationToken);
        return receptionist.Id;
    }
}
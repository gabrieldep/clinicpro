using Doctor.Domain;
using MediatR;
using Patient.Domain;

namespace Doctor.Application;

public class CreateDoctor : IRequest<Guid>
{
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; }
    public DateOnly Birth { get; set; }
}

public class CreatePersonHandler(IDoctorRepository receptionists) : IRequestHandler<CreateDoctor, Guid>
{
    public async Task<Guid> Handle(CreateDoctor request, CancellationToken cancellationToken)
    {
        var receptionist = new Domain.Doctor()
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
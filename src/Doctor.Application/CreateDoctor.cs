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

public class CreateDoctorHandler(IDoctorRepository doctors) : IRequestHandler<CreateDoctor, Guid>
{
    public async Task<Guid> Handle(CreateDoctor request, CancellationToken cancellationToken)
    {
        var doctor = new Domain.Doctor()
        {
            UserName = request.User,
            Password = request.Password,
            Name = request.Name,
            Birth = request.Birth
        };

        await doctors.InsertAsync(doctor, cancellationToken);
        return doctor.Id;
    }
}
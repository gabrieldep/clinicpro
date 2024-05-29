using MediatR;
using Receptionist.Domain;

namespace Receptionist.Application;

public class CreateReceptionist : IRequest<Guid>
{
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; }
    public DateOnly Birth { get; set; }
}

public class CreatePersonHandler(IReceptionistRepository receptionists) : IRequestHandler<CreateReceptionist, Guid>
{
    public async Task<Guid> Handle(CreateReceptionist request, CancellationToken cancellationToken)
    {
        var receptionist = new Receptionist.Domain.Receptionist()
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
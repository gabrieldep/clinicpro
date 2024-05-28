using MediatR;
using Person.Domain;

namespace Person.Application;

public class CreatePerson : IRequest<Guid>
{
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; }
    public DateOnly Birth { get; set; }
}

public class CreatePersonHandler(IPersonRepository people) : IRequestHandler<CreatePerson, Guid>
{
    public async Task<Guid> Handle(CreatePerson request, CancellationToken cancellationToken)
    {
        var person = new Person.Domain.Person()
        {
            UserName = request.User,
            Password = request.Password,
            Name = request.Name,
            Birth = request.Birth
        };

        await people.InsertAsync(person, cancellationToken);
        return person.Id;
    }
}
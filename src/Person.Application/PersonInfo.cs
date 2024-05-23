using MediatR;
using Person.Domain;

namespace Person.Application;

public class PersonInfo : IRequest<bool>
{
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class PersonInfoHandler(IPersonRepository people) : IRequestHandler<PersonInfo, bool>
{
    public async Task<bool> Handle(PersonInfo request, CancellationToken cancellationToken)
    {
        var login = await people.UserExists(request.User, request.Password);
        return login;
    }
}
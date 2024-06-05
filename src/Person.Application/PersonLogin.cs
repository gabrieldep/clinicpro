using MediatR;
using Person.Domain;

namespace Person.Application;

public class PersonLogin : IRequest<bool>
{
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class PersonLoginHandler(IPersonRepository people) : IRequestHandler<PersonLogin, bool>
{
    public async Task<bool> Handle(PersonLogin request, CancellationToken cancellationToken)
    {
        var login = await people.UserExists(request.User, request.Password);
        return login;
    }
}
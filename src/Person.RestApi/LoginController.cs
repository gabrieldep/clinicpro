using Core.RestApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Person.Application;

namespace Person.RestApi;

[ApiController]
[Route("api/person/login")]
public class LoginController(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SaveChanges]
    public async Task<IActionResult> PostAsync([FromBody] PersonInfoRequest request, CancellationToken cancellationToken)
    {
        var command = new PersonInfo { User = request.User, Password = request.Password};
        var login = await sender.Send(command, cancellationToken);
        return Ok(login);
    }
}

public record PersonInfoRequest
{
    public string User { get; set; }
    public string Password { get; set; }
}
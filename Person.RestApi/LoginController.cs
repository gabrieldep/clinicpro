using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Person.Application;

namespace Person.RestApi;

[ApiController]
[Route("api/person")]
public class LoginController(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostAsync([FromBody] PersonInfoRequest request, CancellationToken cancellationToken)
    {
        var command = new PersonInfo { User = request.User, Password = request.PassWord};
        var login = await sender.Send(command, cancellationToken);
        return Ok(login);
    }
}

public record PersonInfoRequest
{
    public string User { get; set; }
    public string PassWord { get; set; }
}
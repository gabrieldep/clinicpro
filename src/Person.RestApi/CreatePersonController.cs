using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Person.Application;

namespace Person.RestApi;

[ApiController]
[Route("api/create-person")]
public class CreatePersonController(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostAsync([FromBody] CreatePersonInfoRequest request,
        CancellationToken cancellationToken)
    {
        var birthDate = new DateOnly(request.Birth.Year, request.Birth.Month, request.Birth.Day);

        var command = new CreatePerson()
        {
            User = request.User,
            Password = request.Password,
            Name = request.Name,
            Birth = birthDate
        };
        var personId = await sender.Send(command, cancellationToken);
        return Ok(personId);
    }
}

public record CreatePersonInfoRequest
{
    public string User { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public BirthDate Birth { get; set; }
}

public record BirthDate
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int DayOfWeek { get; set; }
}

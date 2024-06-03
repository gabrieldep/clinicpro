using Core.RestApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Person.Domain;
using Receptionist.Application;

namespace Receptionist.RestApi;

[ApiController]
[Route("api/create-receptionist")]
public class CreateReceptionistController(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]   
    [SaveChanges]
    public async Task<IActionResult> PostAsync([FromBody] CreateReceptionistInfoRequest request,
        CancellationToken cancellationToken)
    {
        var birthDate = new DateOnly(request.Birth.Year, request.Birth.Month, request.Birth.Day);

        var command = new CreateReceptionist()
        {
            User = request.User,
            Password = request.Password,
            Name = request.Name,
            Birth = birthDate,
            CPF = request.CPF
        };
        var receptionistId = await sender.Send(command, cancellationToken);
        return Ok(receptionistId);
    }
}

public record CreateReceptionistInfoRequest
{
    public string User { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public BirthDate Birth { get; set; }
}
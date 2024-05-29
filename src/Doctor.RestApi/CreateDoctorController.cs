using Core.RestApi.Filters;
using Doctor.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Person.Domain;

namespace Doctor.RestApi;

[ApiController]
[Route("api/create-doctor")]
public class CreateDoctorController(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]   
    [SaveChanges]
    public async Task<IActionResult> PostAsync([FromBody] CreateDoctorInfoRequest request,
        CancellationToken cancellationToken)
    {
        var birthDate = new DateOnly(request.Birth.Year, request.Birth.Month, request.Birth.Day);

        var command = new CreateDoctor()
        {
            User = request.User,
            Password = request.Password,
            Name = request.Name,
            Birth = birthDate
        };
        var patientId = await sender.Send(command, cancellationToken);
        return Ok(patientId);
    }
}

public record CreateDoctorInfoRequest
{
    public string User { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public BirthDate Birth { get; set; }
}
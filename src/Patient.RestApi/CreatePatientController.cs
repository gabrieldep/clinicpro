using Core.RestApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Application;
using Person.Domain;

namespace Patient.RestApi;

[ApiController]
[Route("api/create-patient")]
public class CreatePatientController(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]   
    [SaveChanges]
    public async Task<IActionResult> PostAsync([FromBody] CreatePatientInfoRequest request,
        CancellationToken cancellationToken)
    {
        var birthDate = new DateOnly(request.Birth.Year, request.Birth.Month, request.Birth.Day);

        var command = new CreatePatient()
        {
            User = request.User,
            Password = request.Password,
            Name = request.Name,
            Birth = birthDate,
            CPF = request.CPF
        };
        var patientId = await sender.Send(command, cancellationToken);
        return Ok(patientId);
    }
}

public record CreatePatientInfoRequest
{
    public string User { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public BirthDate Birth { get; set; }
}
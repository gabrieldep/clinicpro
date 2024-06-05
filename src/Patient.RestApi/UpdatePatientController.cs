using Core.RestApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Application;
using Person.Domain;

namespace Patient.RestApi;

[ApiController]
[Route("api/patient/update-patient")]
public class UpdatePatientController(ISender sender) : ControllerBase
{
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]   
    [SaveChanges]
    public async Task<IActionResult> PostAsync([FromBody] UpdatePatientInfoRequest request,
        CancellationToken cancellationToken)
    {
        var birthDate = new DateOnly(request.Birth.Year, request.Birth.Month, request.Birth.Day);

        var command = new UpdatePatient()
        {
            PatientId = request.PatientId,
            Name = request.Name,
            Birth = birthDate,
            CPF = request.CPF
        };
        var patientId = await sender.Send(command, cancellationToken);
        return Ok(patientId);
    }
}

public record UpdatePatientInfoRequest
{
    public Guid PatientId { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public BirthDate Birth { get; set; }
}
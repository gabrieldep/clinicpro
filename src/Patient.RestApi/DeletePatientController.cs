using Core.RestApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Application;

namespace Patient.RestApi;

[ApiController]
[Route("api/patient/{patientId}/delete-patient")]
public class DeletePatientController(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]   
    [SaveChanges]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid patientId, CancellationToken cancellationToken)
    {
        var command = new DeletePatient()
        {
            PatientId = patientId
        };
        var wasDeleted = await sender.Send(command, cancellationToken);
        return Ok(wasDeleted);
    }
}
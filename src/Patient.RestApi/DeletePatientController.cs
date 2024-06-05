using Core.RestApi.Filters;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Application;
using Patient.Application.Validators;

namespace Patient.RestApi;

[ApiController]
[Route("api/patient/{patientId}/delete-patient")]
public class DeletePatientController(ISender sender, IValidator<DeletePatientInfo> validator) : ControllerBase
{
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]   
    [SaveChanges]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid patientId, CancellationToken cancellationToken)
    {
        var patientAppointments = new DeletePatientInfo() { PatientId = patientId };

        var validationResult = await validator.ValidateAsync(patientAppointments, cancellationToken);
        if (!validationResult.IsValid)
            return NotFound(validationResult.Errors);
        
        var command = new DeletePatient()
        {
            PatientId = patientId
        };
        var wasDeleted = await sender.Send(command, cancellationToken);
        return Ok(wasDeleted);
    }
}
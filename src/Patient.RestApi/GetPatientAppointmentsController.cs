using Core.RestApi.Filters;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Application;
using Patient.Application.Validators;
using Person.Domain;

namespace Patient.RestApi;

[ApiController]
[Route("api/patient/{patientId}/get-appointments-patient")]
public class GetPatientAppointmentsController(ISender sender, IValidator<PatientAppointments> validator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SaveChanges]
    public async Task<IActionResult> GetAsync([FromRoute] Guid patientId, CancellationToken cancellationToken)
    {
        var patientAppointments = new PatientAppointments() { PatientId = patientId };

        var validationResult = await validator.ValidateAsync(patientAppointments, cancellationToken);
        if (!validationResult.IsValid)
            return NotFound(validationResult.Errors);
        
        var command = new GetPatientAppointments()
        {
            PatientId = patientId
        };
        var patientAppointmentsDTO = await sender.Send(command, cancellationToken);
        return Ok(patientAppointmentsDTO);
    }
}
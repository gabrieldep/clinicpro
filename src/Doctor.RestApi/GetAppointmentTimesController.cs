using Core.RestApi.Filters;
using Doctor.Application;
using Doctor.Application.Validators;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.RestApi;

[ApiController]
[Route("api/doctor/{doctorId}/get-appointment-times")]
public class GetAppointmentTimesController(ISender sender, IValidator<DoctorTimesAvaiable> validator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SaveChanges]
    public async Task<IActionResult> GetAsync([FromRoute]Guid doctorId, CancellationToken cancellationToken)
    {
        var doctorTimesAvaiable = new DoctorTimesAvaiable() { DoctorId = doctorId };

        var validationResult = await validator.ValidateAsync(doctorTimesAvaiable, cancellationToken);
        if (!validationResult.IsValid)
            return NotFound(validationResult.Errors);
        
        var command = new GetAppointmentTimes
        {
            DoctorId = doctorId
        };
        var appointmentTimes = await sender.Send(command, cancellationToken);
        return Ok(appointmentTimes);
    }
}
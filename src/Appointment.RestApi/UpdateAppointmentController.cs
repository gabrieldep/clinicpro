using Appointment.Application;
using Core.RestApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.RestApi;

[ApiController]
[Route("api/appointment/update-appointment")]
public class UpdateAppointmentController(ISender sender) : ControllerBase
{
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SaveChanges]
    public async Task<IActionResult> PutAsync([FromBody] UpdateAppointmentRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateAppointment
        {
            AppointmentId = request.AppointmentId,
            MedicalSchedule = request.MedicalSchedule
        };
        var appointment = await sender.Send(command, cancellationToken);
        return Ok(appointment);
    }
}

public record UpdateAppointmentRequest
{
    public Guid AppointmentId { get; set; }
    public DateTime MedicalSchedule { get; set; }
}
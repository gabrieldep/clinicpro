using Appointment.Application;
using Core.RestApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.RestApi;

[ApiController]
[Route("api/schedule-appointment")]
public class ScheduleAppointmentController(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SaveChanges]
    public async Task<IActionResult> PostAsync([FromBody] AppointmentRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateAppointment
        {
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            MedicalSchedule = request.MedicalSchedule
        };
        var appointmentGuid = await sender.Send(command, cancellationToken);
        return Ok(appointmentGuid);
    }
}

public record AppointmentRequest
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime MedicalSchedule { get; set; }
}
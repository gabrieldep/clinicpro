using Appointment.Application;
using Core.RestApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.RestApi;

[ApiController]
[Route("api/appointment/{appointmentId}/cancel-appointment")]
public class CancelAppointmentController(ISender sender) : ControllerBase
{
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SaveChanges]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid appointmentId, CancellationToken cancellationToken)
    {
        var command = new DeleteAppointment
        {
            AppointmentId = appointmentId,
        };
        var wasDeleted = await sender.Send(command, cancellationToken);
        return Ok(wasDeleted);
    }
}
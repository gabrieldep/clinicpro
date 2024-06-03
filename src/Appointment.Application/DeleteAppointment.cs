using Appointment.Domain;
using MediatR;

namespace Appointment.Application;

public class DeleteAppointment : IRequest<bool>
{
    public Guid AppointmentId { get; set; }
}

public class DeleteAppointmentHandler(IAppointmentRepository appointments) : IRequestHandler<DeleteAppointment, bool>
{
    public async Task<bool> Handle(DeleteAppointment request, CancellationToken cancellationToken)
    {
        var wasDeleted = await appointments.DeleteAsync(request.AppointmentId, cancellationToken);
        return wasDeleted;
    }
}
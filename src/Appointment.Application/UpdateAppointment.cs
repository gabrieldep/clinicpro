using Appointment.Domain;
using MediatR;

namespace Appointment.Application;

public class UpdateAppointment : IRequest<Appointment.Domain.Appointment>
{
    public Guid AppointmentId { get; set; }
    public DateTime MedicalSchedule { get; set; }
}

public class UpdateAppointmentHandler(IAppointmentRepository appointments)
    : IRequestHandler<UpdateAppointment, Appointment.Domain.Appointment>
{
    public async Task<Appointment.Domain.Appointment> Handle(UpdateAppointment request,
        CancellationToken cancellationToken)
    {
        var appointment = await appointments.GetAsync(request.AppointmentId, cancellationToken);
        appointment.MedicalSchedule = request.MedicalSchedule;
        return appointment;
    }
}
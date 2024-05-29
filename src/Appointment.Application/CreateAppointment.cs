using Appointment.Domain;
using MediatR;

namespace Appointment.Application;

public class CreateAppointment : IRequest<Guid>
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime MedicalSchedule { get; set; }
}

public class CreateAppointmentHandler(IAppointmentRepository appointments) : IRequestHandler<CreateAppointment, Guid>
{
    public async Task<Guid> Handle(CreateAppointment request, CancellationToken cancellationToken)
    {
        var appointment = new Appointment.Domain.Appointment()
        {
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            MedicalSchedule = request.MedicalSchedule
        };
        await appointments.InsertAsync(appointment, cancellationToken);
        return appointment.Id;
    }
}
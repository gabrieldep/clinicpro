using Appointment.Application.DTOs;
using Appointment.Domain;
using MediatR;

namespace Appointment.Application;

public class UpdateAppointment : IRequest<AppointmentDTO>
{
    public Guid AppointmentId { get; set; }
    public DateTime MedicalSchedule { get; set; }
}

public class UpdateAppointmentHandler(IAppointmentRepository appointments)
    : IRequestHandler<UpdateAppointment, AppointmentDTO>
{
    public async Task<AppointmentDTO> Handle(UpdateAppointment request,
        CancellationToken cancellationToken)
    {
        var appointment = await appointments.GetWithDocAndPatientAsync(request.AppointmentId, cancellationToken);
        appointment.MedicalSchedule = request.MedicalSchedule;
        var appointmentDto = new AppointmentDTO()
        {
            MedicalSchedule = appointment.MedicalSchedule,
            PatientName = appointment.Patient.Name,
            DoctorName = appointment.Doctor.Name,
            DoctorId = appointment.DoctorId,
            PatientId = appointment.PatientId
        };
        return appointmentDto;
    }
}
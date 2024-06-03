using Appointment.Application.DTOs;
using Appointment.Domain;
using MediatR;
using Patient.Application.DTOs;
using Patient.Domain;

namespace Patient.Application;

public class GetPatientAppointments : IRequest<PatientAppointmentsDTO>
{
    public Guid PatientId { get; set; }
}

public class GetPatientAppointmentsHandler(IAppointmentRepository appointments, IPatientRepository patients)
    : IRequestHandler<GetPatientAppointments, PatientAppointmentsDTO>
{
    public async Task<PatientAppointmentsDTO> Handle(GetPatientAppointments request,
        CancellationToken cancellationToken)
    {
        var patientAppointments = await appointments
            .GetPatientAppointments(request.PatientId, cancellationToken);
        var patient = await patients.GetAsync(request.PatientId, cancellationToken);
        
        var appointmentsDto = new PatientAppointmentsDTO()
        {
            PatientId = patient.Id,
            PatientName = patient.Name,
            AppointmentDtos = patientAppointments.Select(pa =>
                new AppointmentDTO()
                {
                    MedicalSchedule = pa.MedicalSchedule,
                    DoctorId = pa.DoctorId,
                    DoctorName = pa.Doctor.Name
                }).ToList()
        };
        return appointmentsDto;
    }
}
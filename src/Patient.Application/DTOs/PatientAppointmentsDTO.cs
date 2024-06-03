using Appointment.Application.DTOs;

namespace Patient.Application.DTOs;

public class PatientAppointmentsDTO
{
    public Guid PatientId { get; set; }
    public string PatientName { get; set; }
    public List<AppointmentDTO> AppointmentDtos { get; set; }
}
namespace Appointment.Application.DTOs;

public class AppointmentDTO
{
    public DateTime MedicalSchedule { get; set; }
    public Guid DoctorId { get; set; }
    public string DoctorName { get; set; }
    public string PatientName { get; set; }
    public Guid PatientId { get; set; }
}
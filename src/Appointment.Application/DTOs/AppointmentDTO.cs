namespace Appointment.Application.DTOs;

public class AppointmentDTO
{
    public DateTime MedicalSchedule { get; set; }
    public Guid DoctorId { get; set; }
    public string DoctorName { get; set; }
}
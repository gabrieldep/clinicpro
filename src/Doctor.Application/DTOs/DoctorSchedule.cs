namespace Doctor.Application.DTOs;

public class DoctorSchedule
{
    public Guid DoctorId { get; set; }
    public List<AppointmentTime> AvailableTimes { get; set; } = null!;
}
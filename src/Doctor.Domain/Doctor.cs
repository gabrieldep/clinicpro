using Core.Domain;

namespace Doctor.Domain;

public class Doctor : Entity
{
    public IEnumerable<Appointment.Domain.Appointment> Appointments { get; set; }
}
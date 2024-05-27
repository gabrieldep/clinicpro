using Core.Domain;

namespace Patient.Domain;

public class Patient : Entity
{
    public IEnumerable<Appointment.Domain.Appointment> Appointments { get; set; }
}
using Core.Domain;

namespace Appointment.Domain;

public class Appointment : Entity
{
    public Patient.Domain.Patient Patient { get; set; }
    public DateTime MedicalSchedule { get; set; }
    public Doctor.Domain.Doctor Doctor { get; set; }
}
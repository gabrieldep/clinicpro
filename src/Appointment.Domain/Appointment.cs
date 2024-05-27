using Core.Domain;

namespace Appointment.Domain;

public class Appointment : Entity
{
    public Guid PatientId { get; set; }
    public Patient.Domain.Patient Patient { get; set; }
    
    
    public DateTime MedicalSchedule { get; set; }
    
    public Guid DoctorId { get; set; }
    public Doctor.Domain.Doctor Doctor { get; set; }
}
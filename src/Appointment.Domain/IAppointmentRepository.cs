namespace Appointment.Domain;

public interface IAppointmentRepository
{
    Task InsertAsync(Appointment appointment, CancellationToken cancellationToken);
    Task<Appointment> GetAsync(Guid appointmentId, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid appointmentId, CancellationToken cancellationToken);
    Task<IQueryable<Appointment>> GetAppointmentsFromNow(Guid doctorId, CancellationToken cancellationToken);
    Task<IQueryable<Appointment>> GetPatientAppointments(Guid patientId, CancellationToken cancellationToken);
}
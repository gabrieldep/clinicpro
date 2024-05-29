namespace Appointment.Domain;

public interface IAppointmentRepository
{
    Task InsertAsync(Appointment appointment, CancellationToken cancellationToken);
    Task<IQueryable<Appointment>> GetAppointmentsFromNow(Guid doctorId, CancellationToken cancellationToken);
}
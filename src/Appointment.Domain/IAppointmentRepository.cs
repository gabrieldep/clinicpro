namespace Appointment.Domain;

public interface IAppointmentRepository
{
    Task InsertAsync(Appointment appointment, CancellationToken cancellationToken);
}
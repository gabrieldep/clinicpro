using Appointment.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class AppointmentRepository(DbContext db) : IAppointmentRepository
{
    public Task InsertAsync(Appointment.Domain.Appointment appointment, CancellationToken cancellationToken)
    {
        return db.Set<Appointment.Domain.Appointment>().AddAsync(appointment, cancellationToken).AsTask();
    }
}
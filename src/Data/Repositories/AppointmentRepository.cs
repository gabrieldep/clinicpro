using Appointment.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class AppointmentRepository(DbContext db) : IAppointmentRepository
{
    public Task InsertAsync(Appointment.Domain.Appointment appointment, CancellationToken cancellationToken)
    {
        return db.Set<Appointment.Domain.Appointment>().AddAsync(appointment, cancellationToken).AsTask();
    }

    public async Task<IQueryable<Appointment.Domain.Appointment>> GetAppointmentsFromNow(Guid doctorId, CancellationToken cancellationToken)
    {
        var appointments = db.Set<Appointment.Domain.Appointment>()
            .Where(s => 
                s.DoctorId == doctorId
                && s.MedicalSchedule >= DateTime.Now);
        return await Task.FromResult(appointments);
    }
}
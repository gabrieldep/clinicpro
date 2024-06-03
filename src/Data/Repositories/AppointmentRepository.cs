using Appointment.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class AppointmentRepository(DbContext db) : IAppointmentRepository
{
    public Task InsertAsync(Appointment.Domain.Appointment appointment, CancellationToken cancellationToken)
    {
        return db.Set<Appointment.Domain.Appointment>().AddAsync(appointment, cancellationToken).AsTask();
    }

    public async Task<Appointment.Domain.Appointment> GetAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        return await db.Set<Appointment.Domain.Appointment>()
            .FindAsync(appointmentId, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        var appointment = await GetAsync(appointmentId, cancellationToken);
        if (appointment == null) return false;

        db.Set<Appointment.Domain.Appointment>().Remove(appointment);
        return true;
    }

    public async Task<IQueryable<Appointment.Domain.Appointment>> GetAppointmentsFromNow(Guid doctorId, CancellationToken cancellationToken)
    {
        var appointments = db.Set<Appointment.Domain.Appointment>()
            .Where(s => 
                s.DoctorId == doctorId
                && s.MedicalSchedule >= DateTime.Now);
        return await Task.FromResult(appointments);
    }

    public async Task<IQueryable<Appointment.Domain.Appointment>> GetPatientAppointments(Guid patientId, CancellationToken cancellationToken)
    {
        var appointments = db.Set<Appointment.Domain.Appointment>()
            .Where(s =>
                s.PatientId == patientId);
        return await Task.FromResult(appointments);
    }
}
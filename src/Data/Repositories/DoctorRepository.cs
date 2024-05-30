using Doctor.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class DoctorRepository(DbContext db) : IDoctorRepository
{
    public Task InsertAsync(Doctor.Domain.Doctor doctor, CancellationToken cancellationToken)
    {
        return db.Set<Person.Domain.Person>().AddAsync(doctor, cancellationToken).AsTask();
    }

    public async Task<Doctor.Domain.Doctor> GetAsync(Guid doctorId, CancellationToken cancellationToken)
    {
        return await db.Set<Doctor.Domain.Doctor>().FindAsync(doctorId, cancellationToken);
    }
}
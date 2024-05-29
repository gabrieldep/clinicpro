using Doctor.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class DoctorRepository(DbContext db) : IDoctorRepository
{
    public Task InsertAsync(Doctor.Domain.Doctor doctor, CancellationToken cancellationToken)
    {
        return db.Set<Person.Domain.Person>().AddAsync(doctor, cancellationToken).AsTask();
    }
}
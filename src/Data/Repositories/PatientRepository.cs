using Microsoft.EntityFrameworkCore;
using Patient.Domain;

namespace Data.Repositories;

public class PatientRepository(DbContext db) : IPatientRepository
{
    public Task InsertAsync(Patient.Domain.Patient patient, CancellationToken cancellationToken)
    {
        return db.Set<Person.Domain.Person>().AddAsync(patient, cancellationToken).AsTask();
    }
}
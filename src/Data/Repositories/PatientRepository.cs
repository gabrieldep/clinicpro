using Microsoft.EntityFrameworkCore;
using Patient.Domain;

namespace Data.Repositories;

public class PatientRepository(DbContext db) : IPatientRepository
{
    public Task InsertAsync(Patient.Domain.Patient patient, CancellationToken cancellationToken)
    {
        return db.Set<Person.Domain.Person>().AddAsync(patient, cancellationToken).AsTask();
    }

    public async Task<Patient.Domain.Patient> GetAsync(Guid patientId, CancellationToken cancellationToken)
    {
        return await db.Set<Patient.Domain.Patient>()
            .FindAsync(patientId, cancellationToken);
    }
}
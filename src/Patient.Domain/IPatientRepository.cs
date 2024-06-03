namespace Patient.Domain;

public interface IPatientRepository
{
    Task InsertAsync(Patient patient, CancellationToken cancellationToken);
    Task<Patient> GetAsync(Guid patientId, CancellationToken cancellationToken);
}
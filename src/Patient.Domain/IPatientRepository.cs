namespace Patient.Domain;

public interface IPatientRepository
{
    Task InsertAsync(Patient patient, CancellationToken cancellationToken);
}
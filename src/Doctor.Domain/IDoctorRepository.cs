namespace Doctor.Domain;

public interface IDoctorRepository
{
    Task InsertAsync(Doctor doctor, CancellationToken cancellationToken);
}
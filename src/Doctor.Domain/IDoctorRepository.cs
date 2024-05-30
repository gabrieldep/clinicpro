namespace Doctor.Domain;

public interface IDoctorRepository
{
    Task InsertAsync(Doctor doctor, CancellationToken cancellationToken);
    Task<Doctor> GetAsync(Guid walletId, CancellationToken cancellationToken);
}
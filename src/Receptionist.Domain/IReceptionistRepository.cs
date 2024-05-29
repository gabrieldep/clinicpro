namespace Receptionist.Domain;

public interface IReceptionistRepository
{
    Task InsertAsync(Receptionist receptionist, CancellationToken cancellationToken);
}
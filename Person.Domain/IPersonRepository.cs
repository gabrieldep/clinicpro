namespace Person.Domain;

public interface IPersonRepository
{
    Task<bool> UserExists(string user, string password);
}
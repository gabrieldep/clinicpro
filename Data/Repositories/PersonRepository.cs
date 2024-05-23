using Microsoft.EntityFrameworkCore;
using Person.Domain;

namespace Data.Repositories;

public class PersonRepository(DbContext db) : IPersonRepository
{
    public async Task<bool> UserExists(string user, string password)
    {
        var person = db.Set<Person.Domain.Person>()
            .Where(p => p.UserName == user && p.Password == password);
        return await person.AnyAsync();
    }
}
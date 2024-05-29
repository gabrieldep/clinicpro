using Microsoft.EntityFrameworkCore;
using Receptionist.Domain;

namespace Data.Repositories;

public class ReceptionistRepository(DbContext db) : IReceptionistRepository
{
    public Task InsertAsync(Receptionist.Domain.Receptionist receptionist, CancellationToken cancellationToken)
    {
        return db.Set<Person.Domain.Person>().AddAsync(receptionist, cancellationToken).AsTask();
    }
}
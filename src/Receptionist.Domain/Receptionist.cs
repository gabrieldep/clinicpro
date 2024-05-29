using Person.Domain;

namespace Receptionist.Domain;

public class Receptionist : Person.Domain.Person
{
    public override PersonType Type { get; set; } = PersonType.Receptionist;
}
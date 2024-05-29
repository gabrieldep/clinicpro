using Core.Domain;
using Person.Domain;

namespace Patient.Domain;

public class Patient : Person.Domain.Person
{
    public override PersonType Type { get; set; } = PersonType.Patient;
}
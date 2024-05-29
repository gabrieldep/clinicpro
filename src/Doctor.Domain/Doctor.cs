using Core.Domain;
using Person.Domain;

namespace Doctor.Domain;

public class Doctor : Person.Domain.Person
{
    public override PersonType Type { get; set; } = PersonType.Doctor;
}
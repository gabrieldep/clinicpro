using Core.Domain;

namespace Person.Domain;

public abstract class Person : Entity
{
    public abstract PersonType Type { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public DateOnly Birth { get; set; }
}
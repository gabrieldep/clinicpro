using Core.Domain;

namespace Person.Domain;

public class Person : Entity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public DateOnly Birth { get; set; }
}
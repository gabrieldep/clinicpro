namespace Person.Domain;

public record BirthDate
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int DayOfWeek { get; set; }
}
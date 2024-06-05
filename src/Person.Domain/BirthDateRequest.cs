namespace Person.Domain;

public record BirthDate
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }

    public bool IsNullOrEmpty() => Year != 0 && Month != 0 && Day != 0;
}
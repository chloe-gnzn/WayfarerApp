namespace Template.Models.Entities;

/// <summary>
/// Short, single-outing activity. Flat per-person pricing, no group discount.
/// </summary>
public class Experience : TravelItem
{
    public Experience(
        int id,
        string name,
        Destination destination,
        string summary,
        decimal basePrice,
        int capacity,
        int reserved,
        IEnumerable<string> highlights,
        int hours)
        : base(id, name, destination, summary, basePrice, capacity, reserved, highlights)
    {
        Hours = hours;
    }

    public int Hours { get; }

    public override string Kind => "Experience";
    public override string DurationLabel => $"{Hours} hrs";

    public override decimal CalculatePrice(int travelers) => BasePrice * Math.Max(travelers, 1);
}

namespace Template.Models.Entities;

/// <summary>
/// Multi-day guided tour. Groups of four or more receive a discount.
/// </summary>
public class TourPackage : TravelItem
{
    public const int GroupThreshold = 4;
    public const decimal GroupDiscount = 0.10m;

    public TourPackage(
        int id,
        string name,
        Destination destination,
        string summary,
        decimal basePrice,
        int capacity,
        int reserved,
        IEnumerable<string> highlights,
        int days,
        Difficulty difficulty)
        : base(id, name, destination, summary, basePrice, capacity, reserved, highlights)
    {
        Days = days;
        Difficulty = difficulty;
    }

    public int Days { get; }
    public Difficulty Difficulty { get; }

    public override string Kind => "Tour";
    public override string DurationLabel => $"{Days} days";
    public override string PriceNote => $"per traveler, {GroupDiscount:P0} off for {GroupThreshold}+";

    public override decimal CalculatePrice(int travelers)
    {
        var subtotal = BasePrice * Math.Max(travelers, 1);
        if (travelers >= GroupThreshold)
            subtotal -= subtotal * GroupDiscount;
        return Math.Round(subtotal, 0);
    }
}

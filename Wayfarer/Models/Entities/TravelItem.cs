namespace Template.Models.Entities;

/// <summary>
/// Abstract base for everything sold on Wayfarer.
/// Encapsulates seat inventory, exposes a polymorphic pricing contract.
/// </summary>
public abstract class TravelItem : IBookable
{
    private int _reserved;

    protected TravelItem(
        int id,
        string name,
        Destination destination,
        string summary,
        decimal basePrice,
        int capacity,
        int reserved,
        IEnumerable<string> highlights)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive.");

        Id = id;
        Name = name;
        Destination = destination;
        Summary = summary;
        BasePrice = basePrice;
        Capacity = capacity;
        _reserved = Math.Clamp(reserved, 0, capacity);
        Highlights = highlights.ToList().AsReadOnly();
    }

    public int Id { get; }
    public string Name { get; }
    public Destination Destination { get; }
    public string Summary { get; }
    public decimal BasePrice { get; }
    public IReadOnlyList<string> Highlights { get; }

    // IBookable
    public int Capacity { get; }
    public int SeatsLeft => Capacity - _reserved;
    public bool IsSoldOut => SeatsLeft <= 0;
    public int PercentFilled => (int)Math.Round(100.0 * _reserved / Capacity);

    public bool CanReserve(int seats) => seats > 0 && seats <= SeatsLeft;

    public void Reserve(int seats)
    {
        if (!CanReserve(seats))
            throw new InvalidOperationException($"Cannot reserve {seats} seat(s); only {SeatsLeft} left.");
        _reserved += seats;
    }

    public void Release(int seats)
    {
        _reserved = Math.Max(0, _reserved - Math.Max(0, seats));
    }

    // Polymorphic members
    public abstract string Kind { get; }
    public abstract string DurationLabel { get; }
    public abstract decimal CalculatePrice(int travelers);
    public virtual string PriceNote => "per traveler";
}

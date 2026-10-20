namespace Template.Models.Entities;

public class Destination
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public Region Region { get; init; }
    public string Tagline { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string BestSeason { get; init; } = string.Empty;
    public double Rating { get; init; }
    /// <summary>Background tint of the destination art.</summary>
    public string Accent { get; init; } = "#98DC9A";
    /// <summary>Foreground colour of the destination art and its text.</summary>
    public string Deep { get; init; } = "#0F3D2B";

    public string Display => $"{Name}, {Country}";
}

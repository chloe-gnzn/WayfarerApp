namespace Template.Models.Entities;

public class Booking
{
    public Booking(
        int id,
        TravelItem item,
        string travelerName,
        string email,
        int travelers,
        DateTime travelDate,
        string? notes)
    {
        Id = id;
        Item = item;
        TravelerName = travelerName;
        Email = email;
        Travelers = travelers;
        TravelDate = travelDate;
        Notes = notes;
        CreatedAt = DateTime.Now;
        Status = BookingStatus.Confirmed;
    }

    public int Id { get; }
    public TravelItem Item { get; }
    public string TravelerName { get; }
    public string Email { get; }
    public int Travelers { get; }
    public DateTime TravelDate { get; }
    public string? Notes { get; }
    public DateTime CreatedAt { get; }
    public BookingStatus Status { get; private set; }

    public string Reference => $"WF-{Id:D4}";
    public decimal Total => Item.CalculatePrice(Travelers);

    public void Cancel()
    {
        if (Status == BookingStatus.Cancelled) return;
        Item.Release(Travelers);
        Status = BookingStatus.Cancelled;
    }
}

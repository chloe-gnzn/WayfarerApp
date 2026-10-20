using System.ComponentModel.DataAnnotations;

namespace Template.Models.Forms;

public class BookingForm
{
    [Range(1, int.MaxValue, ErrorMessage = "Choose a trip to book.")]
    public int ItemId { get; set; }

    [Required(ErrorMessage = "Tell us the lead traveler's full name.")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 60 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "We need an email to send your confirmation.")]
    [EmailAddress(ErrorMessage = "That email doesn't look right. Try name@example.com.")]
    public string Email { get; set; } = string.Empty;

    [Range(1, 12, ErrorMessage = "Groups can be 1 to 12 travelers.")]
    public int Travelers { get; set; } = 1;

    [Required(ErrorMessage = "Pick a departure date.")]
    [FutureDate]
    public DateTime? TravelDate { get; set; }

    [StringLength(300, ErrorMessage = "Notes can be at most 300 characters.")]
    public string? Notes { get; set; }

    [MustBeTrue(ErrorMessage = "Please accept the booking terms to continue.")]
    public bool AcceptTerms { get; set; }
}

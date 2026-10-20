using System.ComponentModel.DataAnnotations;

namespace Template.Models.Forms;

public class FutureDateAttribute : ValidationAttribute
{
    public FutureDateAttribute()
    {
        ErrorMessage = "Departure must be a date after today.";
    }

    public override bool IsValid(object? value)
    {
        if (value is null) return true; // [Required] handles empty values
        return value is DateTime date && date.Date > DateTime.Today;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Template.Models.Forms;

public class MustBeTrueAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) => value is true;
}

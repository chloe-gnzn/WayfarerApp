using System.Globalization;

namespace Template.Data;

public static class Fmt
{
    public static string Money(decimal value) =>
        "$" + value.ToString("N0", CultureInfo.InvariantCulture);

    public static string Date(DateTime value) =>
        value.ToString("MMM d, yyyy", CultureInfo.InvariantCulture);
}

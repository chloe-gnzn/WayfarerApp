using Template.Models.Entities;
using Template.Models.Forms;

namespace Template.Data;

public static class SampleData
{
    private static readonly object Sync = new();
    private static int _nextBookingId = 1003;

    public static readonly List<Destination> Destinations = new()
    {
        new Destination
        {
            Id = 1, Name = "Kyoto", Country = "Japan", Region = Region.Asia,
            Tagline = "Temple lanes, tea houses, quiet mornings.",
            Description = "Japan's old capital rewards early risers: empty shrine paths at dawn, wooden machiya streets, and tea ceremonies that slow the whole day down.",
            BestSeason = "Mar-May, Oct-Nov", Rating = 4.9, Accent = "#FFB4C4", Deep = "#6B1740"
        },
        new Destination
        {
            Id = 2, Name = "Lisbon", Country = "Portugal", Region = Region.Europe,
            Tagline = "Tiled hills, trams and long lunches.",
            Description = "Seven hills of pastel facades, tiled stairways and fado-filled taverns, with the Alentejo's wine country a short drive away.",
            BestSeason = "Apr-Jun, Sep-Oct", Rating = 4.8, Accent = "#FFD84A", Deep = "#2A33D6"
        },
        new Destination
        {
            Id = 3, Name = "Cusco", Country = "Peru", Region = Region.Americas,
            Tagline = "Stone roads above the clouds.",
            Description = "The Inca capital sits at 3,400 meters and is the gateway to the Sacred Valley and the classic trek to Machu Picchu.",
            BestSeason = "May-Sep", Rating = 4.9, Accent = "#98DC9A", Deep = "#0F3D2B"
        },
        new Destination
        {
            Id = 4, Name = "Marrakech", Country = "Morocco", Region = Region.Africa,
            Tagline = "Medina maze, Atlas peaks, desert camps.",
            Description = "Spice-scented souks, riad courtyards and a road that climbs the High Atlas before dropping into Saharan dunes.",
            BestSeason = "Mar-May, Oct-Nov", Rating = 4.7, Accent = "#FF9F6B", Deep = "#4A1A5C"
        },
        new Destination
        {
            Id = 5, Name = "Queenstown", Country = "New Zealand", Region = Region.Oceania,
            Tagline = "Alpine lakes and adrenaline.",
            Description = "A glacier-carved lakeside town ringed by mountains, with some of the Southern Hemisphere's best hiking and river adventures.",
            BestSeason = "Dec-Mar", Rating = 4.8, Accent = "#7ED6E8", Deep = "#0B3552"
        },
        new Destination
        {
            Id = 6, Name = "Reykjavik", Country = "Iceland", Region = Region.Europe,
            Tagline = "Fjords, geysers and midnight light.",
            Description = "A small, creative capital that doubles as a base for glaciers, lava fields, hot springs and the northern lights.",
            BestSeason = "Jun-Aug, Sep-Mar (aurora)", Rating = 4.8, Accent = "#C5BEFF", Deep = "#2B1F78"
        }
    };

    public static readonly List<TravelItem> Items = new()
    {
        new TourPackage(1, "Temple Lanes & Tea Houses", Destinations[0],
            "Six unhurried days between Kyoto's shrines, gardens and family-run tea houses.",
            1450m, 16, 11,
            new[] { "Private dawn visit to Fushimi Inari", "Tea ceremony in a machiya house", "Day trip to Nara", "Ryokan stay with kaiseki dinner" },
            6, Difficulty.Easy),
        new TourPackage(2, "Inca Trail Crossing", Destinations[2],
            "Eight days from Cusco to Machu Picchu on foot, with porters, cooks and a certified guide.",
            2380m, 12, 9,
            new[] { "Four-day guided Inca Trail", "Sacred Valley acclimatization", "Sunrise at Machu Picchu", "All permits included" },
            8, Difficulty.Challenging),
        new TourPackage(3, "Alentejo Table & Tiles", Destinations[1],
            "Five days of azulejo workshops, cork forests and vineyard lunches around Lisbon.",
            1190m, 14, 6,
            new[] { "Hands-on tile painting class", "Two winery lunches", "Sintra palace walk", "Boutique hotel in Alfama" },
            5, Difficulty.Easy),
        new TourPackage(4, "Medina to Sahara", Destinations[3],
            "Seven days from Marrakech's souks over the Atlas to a private desert camp.",
            1760m, 12, 12,
            new[] { "Riad stay in the medina", "Atlas mountain village hike", "Night in a Sahara camp", "Camel trek at sunset" },
            7, Difficulty.Moderate),
        new TourPackage(5, "Fjord & Fire", Destinations[5],
            "Six days of glaciers, black-sand beaches and geothermal pools along Iceland's south coast.",
            2050m, 10, 4,
            new[] { "Glacier walk with crampons", "Golden Circle by minibus", "Private hot-spring evening", "Aurora watch (Sep-Mar)" },
            6, Difficulty.Moderate),
        new TourPackage(6, "Southern Lakes Loop", Destinations[4],
            "Six days of lake-edge hikes, vineyard stops and an optional canyon ride around Queenstown.",
            1980m, 12, 5,
            new[] { "Routeburn Track day hike", "Milford Sound cruise", "Central Otago wine tasting", "Lakeside lodge" },
            6, Difficulty.Moderate),
        new Experience(7, "Sunrise Fushimi Walk", Destinations[0],
            "Climb the vermilion gates before the crowds with a local photographer-guide.",
            65m, 20, 14,
            new[] { "Small group, max 20", "Breakfast pastry stop", "Photo tips from a local guide" },
            3),
        new Experience(8, "Fado Night & Tasca Crawl", Destinations[1],
            "Three family taverns, one live fado set, and a guide who knows the owners.",
            85m, 16, 5,
            new[] { "Four small plates and drinks", "Live fado performance", "Hosted by a Lisbon native" },
            4),
        new Experience(9, "Glacier Lagoon Kayak", Destinations[5],
            "Paddle between icebergs on a calm lagoon with a safety-trained guide.",
            140m, 10, 3,
            new[] { "Dry suits and gear provided", "Hot drinks on the shore", "Beginner friendly" },
            5),
        new Experience(10, "Skippers Canyon Jet Ride", Destinations[4],
            "Two hours of canyon walls, gold-rush history and fast, wet turns.",
            120m, 12, 7,
            new[] { "Waterproof jackets provided", "Gold-panning stop", "Hotel pickup in Queenstown" },
            2)
    };

    public static readonly List<Booking> Bookings = new()
    {
        new Booking(1001, Items[0], "Maya Santos", "maya@example.com", 2, new DateTime(2026, 12, 5), "Vegetarian meals, please."),
        new Booking(1002, Items[7], "Daniel Reyes", "daniel@example.com", 4, new DateTime(2027, 1, 18), null)
    };

    public static TravelItem? FindItem(int id) => Items.FirstOrDefault(i => i.Id == id);

    public static Booking? TryBook(BookingForm form, out string error)
    {
        lock (Sync)
        {
            var item = FindItem(form.ItemId);
            if (item is null)
            {
                error = "That trip is no longer available. Please choose another.";
                return null;
            }

            if (!item.CanReserve(form.Travelers))
            {
                error = item.IsSoldOut
                    ? $"{item.Name} is sold out."
                    : $"Only {item.SeatsLeft} seat(s) left on {item.Name}. Lower your group size and try again.";
                return null;
            }

            item.Reserve(form.Travelers);
            var booking = new Booking(
                _nextBookingId++,
                item,
                form.FullName.Trim(),
                form.Email.Trim(),
                form.Travelers,
                form.TravelDate!.Value,
                string.IsNullOrWhiteSpace(form.Notes) ? null : form.Notes.Trim());

            Bookings.Insert(0, booking);
            error = string.Empty;
            return booking;
        }
    }

    public static void Cancel(Booking booking)
    {
        lock (Sync)
        {
            booking.Cancel();
        }
    }
}

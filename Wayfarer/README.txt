WAYFARER - Travel & Tourism (Blazor Web App, .NET 8, Tailwind CSS v4)
=====================================================================

QUICK START
-----------
Requirement: .NET 8 SDK  (https://dotnet.microsoft.com/download/dotnet/8.0)

1. Unzip the folder.
2. Open a terminal inside the "Wayfarer" folder.
3. Run:   dotnet run
   (or double-click run.bat on Windows / run: ./run.sh on Mac/Linux)
4. Open http://localhost:5080

The compiled CSS (wwwroot/css/app.css) is already included, so Node.js is NOT
needed to launch the app.

EDITING STYLES (optional, needs Node.js)
----------------------------------------
   npm install
   npm run build:css        (one-time build)
   npm run watch:css        (rebuild on every save)

DESIGN
------
Fog-blue canvas, indigo ink, iris buttons. Bricolage Grotesque (headings) and Instrument Sans (body)
are self-hosted in wwwroot/fonts. Each destination has its own colour pair and geometric art,
drawn in Components/Shared/Swatch.razor (colours live on Destination.Accent / Destination.Deep).

PAGES
-----
/          Home      - hero, "departing soon", destination index
/explore   Explore   - search, region filter, kind tabs, sorting, details modal
/book      Book      - validated EditForm with loading + success states
/trips     My trips  - totals, filter tabs, cancel with confirmation

OOP DESIGN (Models/Entities)
----------------------------
IBookable (interface)   - Capacity, SeatsLeft, CanReserve, Reserve, Release
TravelItem (abstract)   - implements IBookable; encapsulated seat counter;
                          abstract Kind / DurationLabel / CalculatePrice
TourPackage : TravelItem  - group discount pricing (inheritance + polymorphism)
Experience  : TravelItem  - flat per-person pricing
Booking                 - composition (has a TravelItem), guarded state changes
Destination             - immutable (init-only) value-like entity

figma/travel-ui.html is a standalone HTML frame of the Home page (links ../wwwroot/css/app.css).
Data is in-memory (resets when the app restarts). No database required.

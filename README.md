[![](https://img.shields.io/nuget/v/soenneker.extensions.datetime.dayofweek.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.dayofweek/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.dayofweek/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.dayofweek/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.datetime.dayofweek.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.dayofweek/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.dayofweek/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.dayofweek/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.DateTime.DayOfWeek

Moves a `DateTime` to the strictly previous or next occurrence of a weekday, with optional day boundaries and time-zone-aware UTC results.

## Installation

```bash
dotnet add package Soenneker.Extensions.DateTime.DayOfWeek
```

## Navigate by weekday

```csharp
using Soenneker.Extensions.DateTime.DayOfWeek;

System.DateTime monday = new(2026, 8, 31, 15, 30, 0, DateTimeKind.Utc);

System.DateTime previousFriday = monday.ToPreviousDayOfWeek(DayOfWeek.Friday);
System.DateTime nextMonday = monday.ToNextDayOfWeek(DayOfWeek.Monday);
```

Navigation is strict. If the input is already on the requested weekday, the previous/next result is seven days away. `ToPreviousDayOfWeek()` and `ToNextDayOfWeek()` preserve the time of day and `Kind`.

Use the boundary variants when the clock fields should be reset:

```csharp
System.DateTime previousFridayStart = monday.ToStartOfPreviousDayOfWeek(DayOfWeek.Friday);
System.DateTime nextFridayEnd = monday.ToEndOfNextDayOfWeek(DayOfWeek.Friday);
```

Start methods return local clock midnight. End methods return one tick before the following date. These non-time-zone methods operate directly on the input fields and preserve `Kind`.

## Time-zone-aware navigation

```csharp
TimeZoneInfo eastern = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
System.DateTime utc = new(2026, 8, 29, 18, 0, 0, DateTimeKind.Utc);

System.DateTime nextMondayStartUtc =
    utc.ToStartOfNextTzDayOfWeek(DayOfWeek.Monday, eastern);

System.DateTime previousFridayEndUtc =
    utc.ToEndOfPreviousTzDayOfWeek(DayOfWeek.Friday, eastern);
```

The time-zone variants first determine the input instant's local weekday, select the strictly previous or next matching local date, and return its boundary as a UTC `DateTime`:

- `ToStartOfPreviousTzDayOfWeek()`
- `ToStartOfNextTzDayOfWeek()`
- `ToEndOfPreviousTzDayOfWeek()`
- `ToEndOfNextTzDayOfWeek()`

If the input `Kind` is not `Utc`, its fields are treated as UTC rather than converted from the machine's local zone. Supply an actual UTC value to avoid ambiguity.

Boundaries use local calendar math. A midnight in a daylight-saving gap advances to the first valid local minute; an ambiguous midnight selects the earlier UTC instant. End values are one tick before the next valid local day boundary.

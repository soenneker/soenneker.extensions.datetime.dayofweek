[![](https://img.shields.io/nuget/v/soenneker.extensions.datetime.dayofweek.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.dayofweek/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.dayofweek/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.dayofweek/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.datetime.dayofweek.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.dayofweek/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.dayofweek/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.dayofweek/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.DateTime.DayOfWeek

A collection of helpful DateTime day of week based extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.DateTime.DayOfWeek
```

## Quick start

```csharp
using Soenneker.Extensions.DateTime.DayOfWeek;

DateTime dateTime = DateTime.UtcNow;
var result = dateTime.ToPreviousDayOfWeek(dayOfWeek);
```

## Common operations

- `ToPreviousDayOfWeek()` - Calculates the date of the previous occurrence of the specified day of the week. Returns the date of the previous occurrence of the specified day of the week.
- `ToNextDayOfWeek()` - Calculates the date of the next occurrence of the specified day of the week. Returns the date of the next occurrence of the specified day of the week.
- `ToStartOfPreviousDayOfWeek()` - Calculates the start of the day for the previous occurrence of the specified day of the week. Returns a `System.DateTime` representing the start of the previous specified day of the week.
- `ToStartOfNextDayOfWeek()` - Calculates the start of the day for the next occurrence of the specified day of the week. Returns a `System.DateTime` representing the start of the next specified day of the week.
- `ToEndOfPreviousDayOfWeek()` - Calculates the end of the day for the previous occurrence of the specified day of the week. Returns a `System.DateTime` representing the end of the previous specified day of the week.
- `ToEndOfNextDayOfWeek()` - Calculates the end of the day for the next occurrence of the specified day of the week. Returns a `System.DateTime` representing the end of the next specified day of the week.
- `ToStartOfPreviousTzDayOfWeek()` - Calculates the start of the previous occurrence of the specified day of the week, adjusted for the specified time zone. Returns the start of the previous occurrence of the specified day of the week, adjusted to the start of the day in the specified time zone.
- `ToStartOfNextTzDayOfWeek()` - Calculates the start of the next occurrence of the specified day of the week, adjusted for the specified time zone. Returns the start of the next occurrence of the specified day of the week, adjusted to the start of the day in the specified time zone.
- `ToEndOfPreviousTzDayOfWeek()` - Calculates the end of the previous occurrence of the specified day of the week, adjusted for the specified time zone. Returns the end of the previous occurrence of the specified day of the week, adjusted to the end of the day in the specified time zone.
- `ToEndOfNextTzDayOfWeek()` - Calculates the end of the next occurrence of the specified day of the week, adjusted for the specified time zone. Returns the end of the next occurrence of the specified day of the week, adjusted to the end of the day in the specified time zone.

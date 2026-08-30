using System.Diagnostics.Contracts;
using Soenneker.Extensions.DateTime.Day;

namespace Soenneker.Extensions.DateTime.DayOfWeek;

/// <summary>
/// A collection of helpful DateTime day of week based extension methods
/// </summary>
public static class DateTimeDayOfWeekExtension
{
    /// <summary>
    /// Calculates the date of the previous occurrence of the specified day of the week.
    /// </summary>
    /// <param name="dateTime">The date from which to calculate the previous occurrence.</param>
    /// <param name="dayOfWeek">The day of the week to find.</param>
    /// <returns>The date of the previous occurrence of the specified day of the week.</returns>
    [Pure]
    public static System.DateTime ToPreviousDayOfWeek(this System.DateTime dateTime, System.DayOfWeek dayOfWeek)
    {
        int daysToSubtract = (dateTime.DayOfWeek - dayOfWeek + 7) % 7;
        daysToSubtract = daysToSubtract == 0 ? 7 : daysToSubtract;
        System.DateTime previousDay = dateTime.AddDays(-daysToSubtract);

        return previousDay;
    }

    /// <summary>
    /// Calculates the date of the next occurrence of the specified day of the week.
    /// </summary>
    /// <param name="dateTime">The date from which to calculate the next occurrence.</param>
    /// <param name="dayOfWeek">The day of the week to find.</param>
    /// <returns>The date of the next occurrence of the specified day of the week.</returns>
    [Pure]
    public static System.DateTime ToNextDayOfWeek(this System.DateTime dateTime, System.DayOfWeek dayOfWeek)
    {
        int daysToAdd = (dayOfWeek - dateTime.DayOfWeek + 7) % 7;
        daysToAdd = daysToAdd == 0 ? 7 : daysToAdd;
        System.DateTime nextDay = dateTime.AddDays(daysToAdd);

        return nextDay;
    }

    /// <summary>
    /// Calculates the start of the day for the previous occurrence of the specified day of the week.
    /// </summary>
    /// <param name="dateTime">The reference date from which to calculate.</param>
    /// <param name="dayOfWeek">The day of the week to find the previous occurrence of.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the start of the previous specified day of the week.</returns>
    [Pure]
    public static System.DateTime ToStartOfPreviousDayOfWeek(this System.DateTime dateTime, System.DayOfWeek dayOfWeek)
    {
        System.DateTime result = dateTime.ToPreviousDayOfWeek(dayOfWeek).ToStartOfDay();
        return result;
    }

    /// <summary>
    /// Calculates the start of the day for the next occurrence of the specified day of the week.
    /// </summary>
    /// <param name="dateTime">The reference date from which to calculate.</param>
    /// <param name="dayOfWeek">The day of the week to find the next occurrence of.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the start of the next specified day of the week.</returns>
    [Pure]
    public static System.DateTime ToStartOfNextDayOfWeek(this System.DateTime dateTime, System.DayOfWeek dayOfWeek)
    {
        System.DateTime result = dateTime.ToNextDayOfWeek(dayOfWeek).ToStartOfDay();
        return result;
    }

    /// <summary>
    /// Calculates the end of the day for the previous occurrence of the specified day of the week.
    /// </summary>
    /// <param name="dateTime">The reference date from which to calculate.</param>
    /// <param name="dayOfWeek">The day of the week to find the previous occurrence of.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the end of the previous specified day of the week.</returns>
    [Pure]
    public static System.DateTime ToEndOfPreviousDayOfWeek(this System.DateTime dateTime, System.DayOfWeek dayOfWeek)
    {
        System.DateTime result = dateTime.ToPreviousDayOfWeek(dayOfWeek).ToEndOfDay();
        return result;
    }

    /// <summary>
    /// Calculates the end of the day for the next occurrence of the specified day of the week.
    /// </summary>
    /// <param name="dateTime">The reference date from which to calculate.</param>
    /// <param name="dayOfWeek">The day of the week to find the next occurrence of.</param>
    /// <returns>A <see cref="System.DateTime"/> representing the end of the next specified day of the week.</returns>
    [Pure]
    public static System.DateTime ToEndOfNextDayOfWeek(this System.DateTime dateTime, System.DayOfWeek dayOfWeek)
    {
        System.DateTime result = dateTime.ToNextDayOfWeek(dayOfWeek).ToEndOfDay();
        return result;
    }

    /// <summary>
    /// Calculates the start of the previous occurrence of the specified day of the week, adjusted for the specified time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date from which to calculate the previous occurrence.</param>
    /// <param name="dayOfWeek">The day of the week to find.</param>
    /// <param name="tzInfo">The time zone to consider for the calculation.</param>
    /// <returns>The start of the previous occurrence of the specified day of the week, adjusted to the start of the day in the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToStartOfPreviousTzDayOfWeek(this System.DateTime utcNow, System.DayOfWeek dayOfWeek, System.TimeZoneInfo tzInfo)
    {
        return GetTzDayOfWeekBoundary(utcNow, dayOfWeek, tzInfo, next: false, end: false);
    }

    /// <summary>
    /// Calculates the start of the next occurrence of the specified day of the week, adjusted for the specified time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date from which to calculate the next occurrence.</param>
    /// <param name="dayOfWeek">The day of the week to find.</param>
    /// <param name="tzInfo">The time zone to consider for the calculation.</param>
    /// <returns>The start of the next occurrence of the specified day of the week, adjusted to the start of the day in the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToStartOfNextTzDayOfWeek(this System.DateTime utcNow, System.DayOfWeek dayOfWeek, System.TimeZoneInfo tzInfo)
    {
        return GetTzDayOfWeekBoundary(utcNow, dayOfWeek, tzInfo, next: true, end: false);
    }

    /// <summary>
    /// Calculates the end of the previous occurrence of the specified day of the week, adjusted for the specified time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date from which to calculate the previous occurrence.</param>
    /// <param name="dayOfWeek">The day of the week to find.</param>
    /// <param name="tzInfo">The time zone to consider for the calculation.</param>
    /// <returns>The end of the previous occurrence of the specified day of the week, adjusted to the end of the day in the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToEndOfPreviousTzDayOfWeek(this System.DateTime utcNow, System.DayOfWeek dayOfWeek, System.TimeZoneInfo tzInfo)
    {
        return GetTzDayOfWeekBoundary(utcNow, dayOfWeek, tzInfo, next: false, end: true);
    }

    /// <summary>
    /// Calculates the end of the next occurrence of the specified day of the week, adjusted for the specified time zone.
    /// </summary>
    /// <param name="utcNow">The UTC date from which to calculate the next occurrence.</param>
    /// <param name="dayOfWeek">The day of the week to find.</param>
    /// <param name="tzInfo">The time zone to consider for the calculation.</param>
    /// <returns>The end of the next occurrence of the specified day of the week, adjusted to the end of the day in the specified time zone.</returns>
    [Pure]
    public static System.DateTime ToEndOfNextTzDayOfWeek(this System.DateTime utcNow, System.DayOfWeek dayOfWeek, System.TimeZoneInfo tzInfo)
    {
        return GetTzDayOfWeekBoundary(utcNow, dayOfWeek, tzInfo, next: true, end: true);
    }

    private static System.DateTime GetTzDayOfWeekBoundary(System.DateTime utc, System.DayOfWeek dayOfWeek, System.TimeZoneInfo timeZoneInfo,
        bool next, bool end)
    {
        System.DateTime utcInstant = utc.Kind == System.DateTimeKind.Utc
            ? utc
            : System.DateTime.SpecifyKind(utc, System.DateTimeKind.Utc);
        System.DateTime local = System.TimeZoneInfo.ConvertTimeFromUtc(utcInstant, timeZoneInfo);

        int distance = next
            ? (dayOfWeek - local.DayOfWeek + 7) % 7
            : (local.DayOfWeek - dayOfWeek + 7) % 7;
        if (distance == 0)
            distance = 7;

        int signedDistance = next ? distance : -distance;
        System.DateTime boundary = local.Date.AddDays(signedDistance + (end ? 1 : 0));
        System.DateTime resolved = ResolveLocalBoundary(boundary, timeZoneInfo);

        return end ? resolved.AddTicks(-1) : resolved;
    }

    private static System.DateTime ResolveLocalBoundary(System.DateTime boundary, System.TimeZoneInfo timeZoneInfo)
    {
        boundary = System.DateTime.SpecifyKind(boundary, System.DateTimeKind.Unspecified);

        while (timeZoneInfo.IsInvalidTime(boundary))
            boundary = boundary.AddMinutes(1);

        if (timeZoneInfo.IsAmbiguousTime(boundary))
        {
            System.TimeSpan[] offsets = timeZoneInfo.GetAmbiguousTimeOffsets(boundary);
            System.TimeSpan chosenOffset = offsets[0] >= offsets[1] ? offsets[0] : offsets[1];
            return System.DateTime.SpecifyKind(boundary - chosenOffset, System.DateTimeKind.Utc);
        }

        return System.TimeZoneInfo.ConvertTimeToUtc(boundary, timeZoneInfo);
    }
}

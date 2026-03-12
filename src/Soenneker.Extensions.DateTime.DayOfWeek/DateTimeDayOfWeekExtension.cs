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
        System.DateTime result = utcNow.ToTz(tzInfo).ToStartOfPreviousDayOfWeek(dayOfWeek).ToUtc(tzInfo);
        return result;
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
        System.DateTime result = utcNow.ToTz(tzInfo).ToStartOfNextDayOfWeek(dayOfWeek).ToUtc(tzInfo);
        return result;
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
        System.DateTime result = utcNow.ToTz(tzInfo).ToEndOfPreviousDayOfWeek(dayOfWeek).ToUtc(tzInfo);
        return result;
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
        System.DateTime result = utcNow.ToTz(tzInfo).ToEndOfNextDayOfWeek(dayOfWeek).ToUtc(tzInfo);
        return result;
    }
}

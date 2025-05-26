using AwesomeAssertions;
using Xunit;

namespace Soenneker.Extensions.DateTime.DayOfWeek.Tests;

public class DateTimeDayOfWeekExtensionTests
{
    [Theory]
    [InlineData(System.DayOfWeek.Monday)]
    [InlineData(System.DayOfWeek.Tuesday)]
    [InlineData(System.DayOfWeek.Wednesday)]
    [InlineData(System.DayOfWeek.Thursday)]
    [InlineData(System.DayOfWeek.Friday)]
    [InlineData(System.DayOfWeek.Saturday)]
    [InlineData(System.DayOfWeek.Sunday)]
    public void ToPreviousDayOfWeek_ReturnsCorrectDate(System.DayOfWeek dayOfWeek)
    {
        // Arrange
        var referenceDate = new System.DateTime(2024, 4, 15); // This is a Monday
        System.DateTime expectedDate = referenceDate.AddDays(-7 + ((int)dayOfWeek + 6) % 7); // Logic to find previous week's day

        // Act
        System.DateTime result = referenceDate.ToPreviousDayOfWeek(dayOfWeek);

        // Assert
        result.Should().Be(expectedDate);
    }

    [Theory]
    [InlineData(System.DayOfWeek.Monday)]
    [InlineData(System.DayOfWeek.Tuesday)]
    [InlineData(System.DayOfWeek.Wednesday)]
    [InlineData(System.DayOfWeek.Thursday)]
    [InlineData(System.DayOfWeek.Friday)]
    [InlineData(System.DayOfWeek.Saturday)]
    [InlineData(System.DayOfWeek.Sunday)]
    public void ToNextDayOfWeek_ReturnsCorrectDate(System.DayOfWeek dayOfWeek)
    {
        // Arrange
        var referenceDate = new System.DateTime(2024, 4, 15); // This is a Monday
        int daysUntilNext = (7 - (int)referenceDate.DayOfWeek + (int)dayOfWeek) % 7;
        daysUntilNext = daysUntilNext == 0 ? 7 : daysUntilNext; // Ensure we move to next week if it's the same day
        System.DateTime expectedDate = referenceDate.AddDays(daysUntilNext);

        // Act
        System.DateTime result = referenceDate.ToNextDayOfWeek(dayOfWeek);

        // Assert
        result.Should().Be(expectedDate);
    }
}

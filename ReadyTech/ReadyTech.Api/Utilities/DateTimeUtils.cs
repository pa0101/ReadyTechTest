using System.Globalization;

namespace ReadyTech.Api.Utilities
{
    public static class DateTimeUtils
    {
        public static string FormatDateTimeToISO8601(DateTime dateTime) =>
            TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time"))
            .ToString("yyyy-MM-dd'T'HH:mm:sszzz", CultureInfo.InvariantCulture);
    }
}

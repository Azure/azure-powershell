using System.Text;

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// This is a helper class for cmdlets that use Iso8601 durations that need support for weeks and months.
    /// </summary>
    public static class Iso8601DurationHelper
    {
        /// <summary>
        /// Interval types
        /// </summary>
        public enum IntervalTypes
        {
            Minute,
            Hour,
            Day,
            Week,
            Month
        }

        /// <summary>
        /// Creates an Iso8601 duration
        /// </summary>
        /// <param name="intervalType"></param>
        /// <param name="intervalCount"></param>
        /// <returns></returns>
        public static string CreateIso8601Duration(IntervalTypes intervalType, uint intervalCount)
        {
            StringBuilder stringBuilder = new StringBuilder();

            // Create basic ISO 8601 duration - Basic string builder implementation
            // XmlConvert.ToString(timeSpan) only supports up to days. Weeks and months need to be supported
            stringBuilder.Append("P");

            if (intervalType == IntervalTypes.Hour ||
                intervalType == IntervalTypes.Minute)
            {
                stringBuilder.Append("T");
            }

            if (intervalType == IntervalTypes.Month ||
                intervalType == IntervalTypes.Minute)
            {
                stringBuilder.Append(intervalCount + "M");
            }

            if (intervalType == IntervalTypes.Week)
            {
                stringBuilder.Append(intervalCount + "W");
            }

            if (intervalType == IntervalTypes.Day)
            {
                stringBuilder.Append(intervalCount + "D");
            }

            if (intervalType == IntervalTypes.Hour)
            {
                stringBuilder.Append(intervalCount + "H");
            }

            string interval = stringBuilder.ToString();
            return interval;
        }
    }
}

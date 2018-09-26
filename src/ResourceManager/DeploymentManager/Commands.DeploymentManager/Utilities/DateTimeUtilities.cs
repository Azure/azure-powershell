// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.DeploymentManager.Utilities
{
    using System;

    internal static class DateTimeUtilities
    {
        /// <summary>
        /// Gets the current date time with abbreviated time zone.
        /// </summary>
        /// <returns>The current date time with time zone.</returns>
        internal static string GetCurrentDateTimeWithTimeZone()
        {
            const string Format = "{0:MM/dd/yy H:mm:ss} {1}";

            DateTime current = DateTime.Now;
            return StringUtilities.SafeInvariantFormat(Format, current, DateTimeUtilities.GetAbbreviatedTimeZone(current));
        }


        /// <summary>
        /// Gets the abbreviated time zone for the specified date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>The abbreviated time zone.</returns>
        internal static string GetAbbreviatedTimeZone(DateTime dateTime)
        {
            string timeZoneName = string.Empty;
            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dateTime))
            {
                timeZoneName = TimeZone.CurrentTimeZone.DaylightName;
            }
            else
            {
                timeZoneName = TimeZone.CurrentTimeZone.StandardName;
            }

            string abbreviated = string.Empty;
            string[] tokens = timeZoneName.Split(' ');
            foreach (var token in tokens)
            {
                if (!StringUtilities.IsNullOrWhiteSpace(token))
                {
                    abbreviated += token.Substring(0, 1);
                }
            }

            return abbreviated;
        }

    }
}

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

using System.Text;

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// This is a helper class for cmdlets that use Iso8601 durations that need support for weeks and months.
    /// </summary>
    public static class Iso8601DurationHelper
    {
        /// <summary>
        /// Creates an Iso8601 duration
        /// </summary>
        /// <param name="intervalType">The provided interval type</param>
        /// <param name="intervalCount">The interval count</param>
        /// <returns>A formatted IS08601 duration to pass to a service endpoint</returns>
        public static string CreateIso8601Duration(string intervalType, uint intervalCount)
        {
            StringBuilder stringBuilder = new StringBuilder();

            // Create basic ISO 8601 duration - Basic string builder implementation
            // XmlConvert.ToString(timeSpan) only supports up to days. Weeks and months need to be supported
            stringBuilder.Append("P");

            if (intervalType == "Hour" ||
                intervalType == "Minute")
            {
                stringBuilder.Append("T");
            }

            if (intervalType == "Month" ||
                intervalType == "Minute")
            {
                stringBuilder.Append(intervalCount + "M");
            }

            if (intervalType == "Week")
            {
                stringBuilder.Append(intervalCount + "W");
            }

            if (intervalType == "Day")
            {
                stringBuilder.Append(intervalCount + "D");
            }

            if (intervalType == "Hour")
            {
                stringBuilder.Append(intervalCount + "H");
            }

            string interval = stringBuilder.ToString();
            return interval;
        }
    }
}

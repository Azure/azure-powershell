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
    using System.Globalization;
    using System.Linq;
    using System.Text;

    internal static class StringUtilities
    {
        private const int DefaultIndentLength = 4;

        internal static string InvariantFormat(string format, params object[] args)
        {
            if (args.Length > 0)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    format,
                    args);
            }
            else
            {
                return format;
            }
        }

        internal static string SafeInvariantFormat(string format, params object[] args)
        {
            const string NullString = "<null>";

            if (args == null)
            {
                // When the argument is null replace with an array of one
                // containing the null string.
                args = new string[] { NullString };
            }
            else
            {
                // Iterate all the args replacing any nulls with the null string.
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == null)
                    {
                        args[i] = NullString;
                    }
                }
            }

            return StringUtilities.InvariantFormat(format, args);
        }

        internal static void InvariantAppend(
                    this StringBuilder builder,
                    string format,
                    params object[] args)
        {
            const string NullString = "<null>";

            if (args == null)
            {
                // When the argument is null replace with an array of one
                // containing the null string.
                args = new string[] { NullString };
            }
            else
            {
                // Iterate all the args replacing any nulls with the null string.
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == null)
                    {
                        args[i] = NullString;
                    }
                }
            }

            if (args.Length > 0)
            {
                builder.AppendFormat(CultureInfo.InvariantCulture, format, args);
            }
            else
            {
                builder.Append(format);
            }
        }

        internal static bool IsNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            if (value.Trim().Length == 0)
            {
                return true;
            }

            return false;
        }

        internal static string ToLocalTimeForUserDisplay(this DateTime dateTime)
        {
            return dateTime.ToLocalTime().ToString("G", CultureInfo.InvariantCulture);
        }

        internal static string ToDisplayFormat(this TimeSpan timeSpan)
        {
            var trimmedTimeSpan = new TimeSpan(timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

            return trimmedTimeSpan.ToString();
        }

        internal static void AppendFormatWithLeftIndentAndNewLine(this StringBuilder sb, int indentFactor, string format, params object[] args)
        {
            string resultString;

            if (args == null || !args.Any())
            {
                resultString = format;
            }
            else
            {
                resultString = StringUtilities.SafeInvariantFormat(format, args);
            }

            if (indentFactor > 0)
            {
                resultString = resultString.PadLeft(resultString.Length + (StringUtilities.DefaultIndentLength * indentFactor));
            }

            sb.AppendLine();
            sb.Append(resultString);
        }

        internal static void AppendFormatWithLeftIndentAndNewLineIfNotNull(this StringBuilder sb, int indentFactor, string name, string value)
        {
            if (!StringUtilities.IsNullOrWhiteSpace(value))
            {
                sb.AppendFormatWithLeftIndentAndNewLine(indentFactor, "{0}: {1}", name, value);
            }
        }

        internal static string FormatIfNotNull(string name, string value)
        {
            if (!StringUtilities.IsNullOrWhiteSpace(value))
            {
                return StringUtilities.SafeInvariantFormat("{0}: {1}", name, value);
            }

            return string.Empty;
        }
    }
}

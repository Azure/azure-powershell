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


namespace Microsoft.AzureStack.Commands
{
    using System;
    using System.Globalization;

    /// <summary>
    /// String Extension Methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Formats a string with given args and current culture.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        /// <returns>Formatted string</returns>
        public static string FormatArgs(this string format, params object[] args)
        {
            return string.Format(CultureInfo.CurrentCulture, format, args);
        }

        /// <summary>
        /// Formats a string with given args and invariant culture.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        /// <returns>Formatted string</returns>
        public static string FormatArgsInvariant(this string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }

        /// <summary>
        /// Compares two string values insensitively.
        /// </summary>
        /// <param name="original">The original string.</param>
        /// <param name="otherString">The other string.</param>
        public static bool EqualsInsensitively(this string original, string otherString)
        {
            return string.Equals(original, otherString, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compares start of string insensitively.
        /// </summary>
        /// <param name="original">The original string.</param>
        /// <param name="prefix">The prefix to compare.</param>
        public static bool StartsWithInsensitively(this string original, string prefix)
        {
            return original.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compares end of string insensitively.
        /// </summary>
        /// <param name="original">The original string.</param>
        /// <param name="suffix">The suffix to compare.</param>
        public static bool EndsWithInsensitively(this string original, string suffix)
        {
            return original.EndsWith(suffix, StringComparison.InvariantCultureIgnoreCase);
        }

    }
}

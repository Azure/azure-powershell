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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// String extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Coalesces a string. 
        /// </summary>
        /// <param name="original">The original string.</param>
        public static string CoalesceString(this string original)
        {
            return original ?? string.Empty;
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
        /// Compares two string values insensitively.
        /// </summary>
        /// <param name="original">The original string.</param>
        /// <param name="otherString">The other string.</param>
        public static bool StartsWithInsensitively(this string original, string otherString)
        {
            return original.CoalesceString().StartsWith(otherString.CoalesceString(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Splits the string with given separators and removes empty entries.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="separator">Separator characters.</param>
        public static string[] SplitRemoveEmpty(this string source, params char[] separator)
        {
            return source.CoalesceString().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Concatenates a number of strings with given separators.
        /// </summary>
        /// <param name="source">The source strings.</param>
        /// <param name="separator">The separator string.</param>
        public static string ConcatStrings(this IEnumerable<string> source, string separator = null)
        {
            return string.Join(separator ?? string.Empty, source);
        }

        /// <summary>
        /// Determines whether the specified source string is a valid decimal.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="allowedNumberStyle">The allowed number style.</param>
        public static bool IsDecimal(this string source, NumberStyles allowedNumberStyle)
        {
            decimal parsedDecimal;
            return decimal.TryParse(s: source, style: allowedNumberStyle, provider: null, result: out parsedDecimal);
        }

        /// <summary>
        /// Determines whether the specified source string is a valid date time.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="format">The format.</param>
        /// <param name="styles">The styles.</param>
        public static bool IsDateTime(this string source, string format, DateTimeStyles styles)
        {
            DateTime parsedDateTime;
            return DateTime.TryParseExact(s: source, format: format, provider: null, style: styles, result: out parsedDateTime);
        }

        /// <summary>
        /// Normalize a location string. 
        /// </summary>
        /// <param name="location">The location string.</param>
        public static string ToNormalizedLocation(this string location)
        {
            return location == null ? null : new string(location.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }

        /// <summary>
        /// Compare two location strings. 
        /// </summary>
        /// <param name="location1">The first location string.</param>
        /// <param name="location2">The second location string.</param>
        public static bool EqualsAsLocation(this string location1, string location2)
        {
            return location1.ToNormalizedLocation().EqualsInsensitively(location2.ToNormalizedLocation());
        }
    }
}
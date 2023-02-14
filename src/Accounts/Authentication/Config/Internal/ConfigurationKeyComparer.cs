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

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal
{
    internal class ConfigurationKeyComparer : IComparer<string>
    {
        private static readonly string[] _keyDelimiterArray = new[] { ConfigurationPath.KeyDelimiter };

        /// <summary>
        /// The default instance.
        /// </summary>
        public static ConfigurationKeyComparer Instance { get; } = new ConfigurationKeyComparer();

        /// <summary>
        /// Compares two strings.
        /// </summary>
        /// <param name="x">First string.</param>
        /// <param name="y">Second string.</param>
        /// <returns>Less than 0 if x is less than y, 0 if x is equal to y and greater than 0 if x is greater than y.</returns>
        public int Compare(string x, string y)
        {
            string[] xParts = x?.Split(_keyDelimiterArray, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
            string[] yParts = y?.Split(_keyDelimiterArray, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();

            // Compare each part until we get two parts that are not equal
            for (int i = 0; i < Math.Min(xParts.Length, yParts.Length); i++)
            {
                x = xParts[i];
                y = yParts[i];

                int value1 = 0;
                int value2 = 0;

                bool xIsInt = x != null && int.TryParse(x, out value1);
                bool yIsInt = y != null && int.TryParse(y, out value2);

                int result;

                if (!xIsInt && !yIsInt)
                {
                    // Both are strings
                    result = string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
                }
                else if (xIsInt && yIsInt)
                {
                    // Both are int
                    result = value1 - value2;
                }
                else
                {
                    // Only one of them is int
                    result = xIsInt ? -1 : 1;
                }

                if (result != 0)
                {
                    // One of them is different
                    return result;
                }
            }

            // If we get here, the common parts are equal.
            // If they are of the same length, then they are totally identical
            return xParts.Length - yParts.Length;
        }
    }
}

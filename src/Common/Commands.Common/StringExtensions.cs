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

using System.Globalization;

namespace Microsoft.WindowsAzure.Commands.Common
{
    /// <summary>
    /// Extension methods for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Formats the string with parameters and invariant culture.
        /// </summary>
        /// <param name="s">The string</param>
        /// <param name="args">The arguments</param>
        public static string FormatInvariant(this string s, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, s, args);
        }
    }
}

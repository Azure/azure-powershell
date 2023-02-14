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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    internal static class EnumerationUtilities
    {
        internal static string ToCommaDelimitedString<T>(this IEnumerable<T> items, string delimiter = ", ")
        {
            StringBuilder builder = new StringBuilder();
            int count = items.Count();
            foreach (T item in items)
            {
                builder.AppendFormat(
                    CultureInfo.InvariantCulture,
                    $"{item}");

                if (--count != 0)
                {
                    builder.Append(delimiter);
                }
            }

            if (builder.Length > 0)
            {
                builder.Append(".");
            }

            return builder.ToString();
        }
    }
}
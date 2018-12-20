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
using System.Reflection;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSNodeCounts
    {
        private static PropertyInfo[] psNodeCountsPropertyInfos;

        public static string FormatObject(PSNodeCounts psNodeCounts)
        {
            var propertyInfos = GetPropertyInfos();

            var propertyStrings = new List<string>();

            Tuple<string, int> totalPropertyInfo = null;

            foreach (var propertyInfo in propertyInfos)
            {
                var propertyValue = propertyInfo.GetValue(psNodeCounts);

                if (propertyValue != null
                    && propertyInfo.PropertyType == typeof (int))
                {
                    int intValue;

                    if (Int32.TryParse(propertyValue.ToString(), out intValue))
                    {
                        // Always print total at the end of string.
                        if (string.Equals(propertyInfo.Name, nameof(Total), StringComparison.OrdinalIgnoreCase))
                        {
                            totalPropertyInfo = new Tuple<string, int>(propertyInfo.Name, intValue);
                        }
                        // Only print numbers > 0 for other node states.
                        else if (intValue > 0)
                        {
                            propertyStrings.Add($"{propertyInfo.Name}: {propertyValue}");
                        }
                    }
                }
            }

            if (totalPropertyInfo != null)
            {
                propertyStrings.Add($"{totalPropertyInfo.Item1}: {totalPropertyInfo.Item2}");
            }

            return string.Join(", ", propertyStrings);
        }

        private static PropertyInfo[] GetPropertyInfos()
        {
            if (psNodeCountsPropertyInfos == null)
            {
                psNodeCountsPropertyInfos = typeof(PSNodeCounts).GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);
            }

            return psNodeCountsPropertyInfos;
        }
    }
}

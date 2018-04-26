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

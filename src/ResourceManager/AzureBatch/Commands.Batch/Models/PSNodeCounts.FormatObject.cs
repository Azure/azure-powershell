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
            foreach (var propertyInfo in propertyInfos)
            {
                var propertyValue = propertyInfo.GetValue(psNodeCounts);

                propertyStrings.Add($"{propertyInfo.Name}: {propertyValue}");
            }

            return string.Join(",", propertyStrings);
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

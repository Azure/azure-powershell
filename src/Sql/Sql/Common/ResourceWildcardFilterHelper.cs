using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Common
{
    public class ResourceWildcardFilterHelper
    {
        public List<T> SqlSubResourceWildcardFilter<T>(string value, IEnumerable<T> resources, string propertyName)
        {
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(propertyName))
            {
                IEnumerable<T> output = resources;
                WildcardPattern pattern = new WildcardPattern(value, WildcardOptions.IgnoreCase);
                output = output.Where(t => IsMatch(t, propertyName, pattern));

                return output.ToList();
            }
            else
            {
                return resources.ToList();
            }
        }

        private bool IsMatch<T>(T resource, string property, WildcardPattern pattern)
        {
            var value = (string)GetPropertyValue(resource, property);
            return !string.IsNullOrEmpty(value) && pattern.IsMatch(value);
        }

        private object GetPropertyValue<T>(T resource, string property)
        {
            System.Reflection.PropertyInfo pi = typeof(T).GetProperty(property);
            if (pi != null)
            {
                return pi.GetValue(resource, null);
            }

            return null;
        }
    }
}
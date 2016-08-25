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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class that builds query filters.
    /// </summary>
    public static class QueryFilterBuilder
    {
        /// <summary>
        /// Creates a filter from the given properties.
        /// </summary>
        /// <param name="subscriptionIds">The subscriptions to query.</param>
        /// <param name="resourceGroup">The name of the resource group/</param>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="tagName">The tag name.</param>
        /// <param name="tagValue">The tag value.</param>
        /// <param name="filter">The filter.</param>
        public static string CreateFilter(
            Guid[] subscriptionIds,
            string resourceGroup,
            string resourceType,
            string resourceName,
            string tagName,
            string tagValue,
            string filter,
            string nameContains = null,
            string resourceGroupNameContains = null)
        {
            var filterStringBuilder = new StringBuilder();

            if (subscriptionIds.CoalesceEnumerable().Any())
            {
                if (subscriptionIds.Length > 1)
                {
                    filterStringBuilder.Append("(");
                }

                filterStringBuilder.Append(subscriptionIds
                    .Select(subscriptionId => string.Format("subscriptionId EQ '{0}'", subscriptionId))
                    .ConcatStrings(" OR "));

                if (subscriptionIds.Length > 1)
                {
                    filterStringBuilder.Append(")");
                }
            }

            if (!string.IsNullOrWhiteSpace(resourceGroup))
            {
                if (filterStringBuilder.Length > 0)
                {
                    filterStringBuilder.Append(" AND ");
                }

                filterStringBuilder.AppendFormat("resourceGroup EQ '{0}'", resourceGroup);
            }

            var remainderFilter = QueryFilterBuilder.CreateFilter(resourceType, resourceName, tagName, tagValue, filter, nameContains, resourceGroupNameContains);

            if (filterStringBuilder.Length > 0 && !string.IsNullOrWhiteSpace(remainderFilter))
            {
                return filterStringBuilder.ToString() + " AND " + remainderFilter;
            }

            return filterStringBuilder.Length > 0
                ? filterStringBuilder.ToString()
                : remainderFilter;
        }

        /// <summary>
        /// Creates a filter from the given properties.
        /// </summary>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="tagName">The tag name.</param>
        /// <param name="tagValue">The tag value.</param>
        /// <param name="filter">The filter.</param>
        public static string CreateFilter(string resourceType, string resourceName, string tagName, string tagValue, string filter, string nameContains = null, string resourceGroupNameContains = null)
        {
            var filterStringBuilder = new StringBuilder();
            var substringStringBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(resourceType))
            {
                filterStringBuilder.AppendFormat("resourceType EQ '{0}'", resourceType);
            }

            if (!string.IsNullOrWhiteSpace(resourceName))
            {
                if (filterStringBuilder.Length > 0)
                {
                    filterStringBuilder.Append(" AND ");
                }

                filterStringBuilder.AppendFormat("name EQ '{0}'", resourceName);
            }

            if (!string.IsNullOrWhiteSpace(tagName))
            {
                if (filterStringBuilder.Length > 0)
                {
                    filterStringBuilder.Append(" AND ");
                }

                filterStringBuilder.AppendFormat("tagName EQ '{0}'", tagName);
            }

            if (!string.IsNullOrWhiteSpace(tagValue))
            {
                if (filterStringBuilder.Length > 0)
                {
                    filterStringBuilder.Append(" AND ");
                }

                filterStringBuilder.AppendFormat("tagValue EQ '{0}'", tagValue);
            }

            if (!string.IsNullOrWhiteSpace(nameContains))
            {
                if (filterStringBuilder.Length > 0)
                {
                    filterStringBuilder.Append(" AND ");
                }

                filterStringBuilder.AppendFormat("substringof('{0}', name)", nameContains);
            }

            if (!string.IsNullOrWhiteSpace(resourceGroupNameContains))
            {
                if (filterStringBuilder.Length > 0)
                {
                    filterStringBuilder.Append(" AND ");
                }

                filterStringBuilder.AppendFormat("substringof('{0}', resourceGroup)", resourceGroupNameContains);
            }

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.Trim().TrimStart('?').TrimStart('&');

                if (filter.StartsWith("$filter", StringComparison.InvariantCultureIgnoreCase))
                {
                    var indexOfEqual = filter.IndexOf("=", StringComparison.Ordinal);

                    if (indexOfEqual > 0 && indexOfEqual < filter.Length - 2)
                    {

                        filter = filter.Substring(filter.IndexOf("=", StringComparison.Ordinal) + 1).Trim();
                    }
                    else
                    {
                        throw new ArgumentException(
                            "If $filter is specified, it cannot be empty and must be of the format '$filter = <filter_value>'. The filter: " + filter,
                            "filter");
                    }
                }
            }

            if (filterStringBuilder.Length > 0 && !string.IsNullOrWhiteSpace(filter))
            {
                return "(" + filterStringBuilder.ToString() + ") AND (" + filter.CoalesceString() + ")";
            }

            return filterStringBuilder.Length > 0
                ? filterStringBuilder.ToString()
                : filter.CoalesceString();
        }
    }
}

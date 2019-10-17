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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    using System.Text.RegularExpressions;

    public static class ResourceIdParser
    {
        private static readonly Regex SubscriptionRegex =
            new Regex(@"^\/?subscriptions\/(?<subscriptionId>[a-f0-9-]+)", RegexOptions.IgnoreCase);

        private static readonly Regex ResourceGroupRegex =
            new Regex(@"^\/resourceGroups\/(?<resourceGroupName>[-\w\._\(\)]+)");

        private static readonly Regex ShortResourceIdRegex =
            new Regex(@"^\/providers/(?<shortResourceId>.+$)");

        
        /// <summary>
        /// Parse a full qualified azure resource ID.
        /// </summary>
        /// <param name="fullyQualifiedResourceId">The resource ID. For now only subscription resource IDs are supported.</param>
        /// <returns>The resource scope and short resource ID (resource provider/name).</returns>
        public static (string scope, string shortResourceId) ParseResourceId(string fullyQualifiedResourceId)
        {
            string remaining = fullyQualifiedResourceId;

            // Parse subscriptionId.
            Match subscriptionMatch = SubscriptionRegex.Match(remaining);
            string subscriptionId = subscriptionMatch.Groups["subscriptionId"].Value;
            remaining = remaining.Substring(subscriptionMatch.Length);

            // Parse resourceGroupName.
            Match resourceGroupMatch = ResourceGroupRegex.Match(remaining);
            string resourceGroupName = resourceGroupMatch.Groups["resourceGroupName"].Value;
            remaining = remaining.Substring(resourceGroupMatch.Length);

            // Parse shortResourceId.
            Match shortResourceIdMatch = ShortResourceIdRegex.Match(remaining);
            string shortResourceId = shortResourceIdMatch.Groups["shortResourceId"].Value;

            // The resourceId represents a resource group as a resource with
            // the format /subscription/{subscriptionId}/resourceGroups/{resourceGroupName},
            // which is a subscription-level resource ID. The resourceGroupName should belong to
            // the relativePath but not the scope.
            if (subscriptionMatch.Success && resourceGroupMatch.Success && !shortResourceIdMatch.Success)
            {
                shortResourceId = $"Microsoft.Resources/resourceGroups/{resourceGroupName}";
                resourceGroupName = string.Empty;
            }

            // Construct scope.
            string scope = $"/subscriptions/{subscriptionId.ToLowerInvariant()}";

            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                scope += $"/resourceGroups/{resourceGroupName}";
            }

            return (scope, shortResourceId);
        }
    }
}

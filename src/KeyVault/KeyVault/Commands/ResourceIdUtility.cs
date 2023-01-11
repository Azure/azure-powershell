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

using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.KeyVault
{
    internal class ResourceIdUtility
    {
        private static readonly Regex ManagementGroupRegex =
            new Regex(@"^\/?providers\/Microsoft.Management\/managementGroups\/(?<managementGroupId>[\w\d_\.\(\)-]+)", RegexOptions.IgnoreCase);

        private static readonly Regex SubscriptionRegex =
            new Regex(@"^\/?subscriptions\/(?<subscriptionId>[\w\d-]+)", RegexOptions.IgnoreCase);

        private static readonly Regex ResourceGroupRegex =
            new Regex(@"^\/resourceGroups\/(?<resourceGroupName>[-\w\._\(\)]+)", RegexOptions.IgnoreCase);

        private static readonly Regex RelativeResourceIdRegex =
            new Regex(@"^\/providers/(?<relativeResourceId>.+$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// Split a fully qualified resource identifier into two parts (resource scope, relative resource identifier).
        /// </summary>
        /// <param name="fullyQualifiedResourceId">The fully qualified resource identifier to split.</param>
        /// <returns>The resource scope and the relative resource identifier.</returns>
        public static (string scope, string relativeResourceId) SplitResourceId(string fullyQualifiedResourceId)
        {
            string remaining = fullyQualifiedResourceId;

            Match managementGroupMatch = ManagementGroupRegex.Match(remaining);
            string managementGroupId = managementGroupMatch.Groups["managementGroupId"].Value;
            remaining = remaining.Substring(managementGroupMatch.Length);

            Match subscriptionMatch = SubscriptionRegex.Match(remaining);
            string subscriptionId = subscriptionMatch.Groups["subscriptionId"].Value;
            remaining = remaining.Substring(subscriptionMatch.Length);

            Match resourceGroupMatch = ResourceGroupRegex.Match(remaining);
            string resourceGroupName = resourceGroupMatch.Groups["resourceGroupName"].Value;
            remaining = remaining.Substring(resourceGroupMatch.Length);

            Match relativeResourceIdMatch = RelativeResourceIdRegex.Match(remaining);
            string relativeResourceId = relativeResourceIdMatch.Groups["relativeResourceId"].Value;

            if (managementGroupMatch.Success)
            {
                return relativeResourceIdMatch.Success
                    ? ($"/providers/Microsoft.Management/ManagementGroups/{managementGroupId}", relativeResourceId)
                    : ("/", $"Microsoft.Management/ManagementGroups/{managementGroupId}");
            }

            if (subscriptionMatch.Success)
            {
                if (resourceGroupMatch.Success)
                {
                    return relativeResourceIdMatch.Success
                        ? ($"/subscriptions/{subscriptionId.ToLowerInvariant()}/resourceGroups/{resourceGroupName}", relativeResourceId)
                        : ($"/subscriptions/{subscriptionId.ToLowerInvariant()}", $"resourceGroups/{resourceGroupName}");
                }

                return ($"/subscriptions/{subscriptionId.ToLowerInvariant()}", relativeResourceId);
            }

            return ("/", relativeResourceId);
        }
    }
}
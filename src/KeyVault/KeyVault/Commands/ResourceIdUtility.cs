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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Linq;
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
        /// <summary>
        /// Gets the deployment name
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        public static string GetDeploymentName(string resourceId)
        {
            return ResourceIdUtility.GetResourceTypeOrName(resourceId: resourceId, getResourceName: true, useLastSegment: true);
        }
        /// <summary>
        /// Gets the name of the resource group from the resource id.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        public static string GetResourceGroupName(string resourceId)
        {
            return ResourceIdUtility.GetNextSegmentAfter(resourceId: resourceId, segmentName: Constants.ResourceGroups);
        }

        /// <summary>
        /// Gets the next segment after the one specified in <paramref name="segmentName"/>.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="segmentName">The segment name.</param>
        /// <param name="selectLastSegment">When set to true, gets the last segment (default) otherwise gets the first one.</param>
        private static string GetNextSegmentAfter(string resourceId, string segmentName, bool selectLastSegment = false)
        {
            var segment = ResourceIdUtility
                .GetSubstringAfterSegment(
                    resourceId: resourceId,
                    segmentName: segmentName,
                    selectLastSegment: selectLastSegment)
                .SplitRemoveEmpty('/')
                .FirstOrDefault();

            return string.IsNullOrWhiteSpace(segment)
                ? null
                : segment;
        }

        /// <summary>
        /// Gets a the substring after a segment.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="segmentName">The segment name.</param>
        /// <param name="selectLastSegment">When set to true, gets the last segment (default) otherwise gets the first one.</param>
        private static string GetSubstringAfterSegment(string resourceId, string segmentName, bool selectLastSegment = true)
        {
            var segment = string.Format("/{0}/", segmentName.Trim('/').ToUpperInvariant());

            var index = selectLastSegment
                ? resourceId.LastIndexOf(segment, StringComparison.InvariantCultureIgnoreCase)
                : resourceId.IndexOf(segment, StringComparison.InvariantCultureIgnoreCase);

            return index < 0
                ? null
                : resourceId.Substring(index + segment.Length);
        }
        /// <summary>
        /// Gets either a resource type or resource Id based on the value of the <paramref name="getResourceName"/> parameter.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="getResourceName">When set to true returns a resource name, otherwise a resource type.</param>
        /// <param name="includeProviderNamespace">Indicates if the provider namespace should be included in the resource name.</param>
        /// <param name="useLastSegment">Seek the last segment instead of the first match.</param>
        private static string GetResourceTypeOrName(string resourceId, bool getResourceName, bool includeProviderNamespace = true, bool useLastSegment = false)
        {
            var substring = ResourceIdUtility.GetSubstringAfterSegment(
                resourceId: resourceId,
                segmentName: Constants.Providers,
                selectLastSegment: useLastSegment);

            var segments = substring.CoalesceString().SplitRemoveEmpty('/');

            if (!segments.Any())
            {
                return null;
            }

            var providerNamespace = segments.First();

            var segmentString = segments.Skip(1)
                .TakeWhile(segment => !segment.EqualsInsensitively(Constants.Providers))
                .Where((segment, index) => getResourceName ? index % 2 != 0 : index % 2 == 0)
                .ConcatStrings("/");

            return getResourceName
                ? segmentString
                : includeProviderNamespace
                    ? string.Format("{0}/{1}", providerNamespace, segmentString)
                    : segmentString;
        }

    }
}
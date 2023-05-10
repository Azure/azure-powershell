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
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

    /// <summary>
    /// Class for building and parsing resource Ids.
    /// </summary>
    public static class ResourceIdUtility
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
        /// Processes the parameters to return a valid resource Id.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="extensionResourceType">The extension resource type string in the format: '{providerName}/{typeName}/{nestedTypeName}'</param>
        /// <param name="extensionResourceName">The extension resource name in the format: '{resourceName}[/{nestedResourceName}]'</param>
        public static string GetResourceId(string resourceId, string extensionResourceType, string extensionResourceName = null)
        {
            var resourceIdBuilder = new StringBuilder(resourceId.TrimEnd('/'));

            if (!string.IsNullOrWhiteSpace(extensionResourceType))
            {
                resourceIdBuilder.Append(ResourceIdUtility.ProcessResourceTypeAndName(resourceType: extensionResourceType, resourceName: extensionResourceName));
            }

            return resourceIdBuilder.ToString();
        }

        /// <summary>
        /// Processes the parameters to return a valid resource Id.
        /// </summary>
        /// <param name="subscriptionId">The subscription.</param>
        /// <param name="resourceGroupName">The resource group</param>
        /// <param name="resourceType">The resource type string in the format: '{providerName}/{typeName}/{nestedTypeName}'</param>
        /// <param name="resourceName">The resource name in the format: '{resourceName}[/{nestedResourceName}]'</param>
        /// <param name="extensionResourceType">The extension resource type string in the format: '{providerName}/{typeName}/{nestedTypeName}'</param>
        /// <param name="extensionResourceName">The extension resource name in the format: '{resourceName}[/{nestedResourceName}]'</param>
        public static string GetResourceId(Guid? subscriptionId, string resourceGroupName, string resourceType, string resourceName, string extensionResourceType = null, string extensionResourceName = null)
        {
            if (subscriptionId == null && !string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new InvalidOperationException("A resource group cannot be specified without a subscription.");
            }

            var resourceId = new StringBuilder();

            if (subscriptionId != null)
            {
                resourceId.AppendFormat("/subscriptions/{0}", Uri.EscapeDataString(subscriptionId.Value.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(resourceGroupName))
            {
                resourceId.AppendFormat("/resourceGroups/{0}", Uri.EscapeDataString(resourceGroupName));
            }

            if (!string.IsNullOrWhiteSpace(resourceType))
            {
                resourceId.Append(ResourceIdUtility.ProcessResourceTypeAndName(resourceType: resourceType, resourceName: resourceName));
            }

            if (!string.IsNullOrWhiteSpace(extensionResourceType))
            {
                resourceId.Append(ResourceIdUtility.ProcessResourceTypeAndName(resourceType: extensionResourceType, resourceName: extensionResourceName));
            }

            return resourceId.ToString();
        }

        /// <summary>
        /// Processes the parameters to return a valid resource Id.
        /// </summary>
        /// <param name="subscriptionId">The subscription.</param>
        public static string GetResourceGroupsId(Guid? subscriptionId)
        {
            if (subscriptionId == null)
            {
                throw new InvalidOperationException("A resource group cannot be specified without a subscription.");
            }

            return string.Format("/subscriptions/{0}/resourceGroups", Uri.EscapeDataString(subscriptionId.Value.ToString()));
        }

        /// <summary>
        /// Processes the parameters to return a valid resource Id.
        /// </summary>
        /// <param name="subscriptionId">The subscription.</param>
        /// <param name="resourceGroupName">The resource group</param>
        /// <param name="parentResource">The parent resource in the format: '{resourceType}/{typeName}'</param>
        /// <param name="resourceType">The resource type string in the format: '{providerName}/{typeName}'</param>
        /// <param name="resourceName">The resource name in the format: '{resourceName}'</param>
        /// <returns></returns>
        public static string GetResourceId(Guid subscriptionId, string resourceGroupName, string parentResource, string resourceType, string resourceName)
        {
            var provider = ResourceIdUtility.GetProviderFromLegacyResourceTypeString(resourceType);
            resourceType = ResourceIdUtility.GetTypeFromLegacyResourceTypeString(resourceType);

            var parameters = new[]
            {
                subscriptionId.ToString(),
                resourceGroupName,
                provider,
                parentResource.Trim('/'),
                resourceType.Trim('/'),
                resourceName.Trim('/'),
            };

            var parameteValues = parameters
                .Select(parameter => Uri.EscapeDataString(parameter))
                .Cast<object>()
                .ToArray();

            return string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/{2}/{3}/{4}/{5}", parameteValues);
        }

        /// <summary>
        /// Processes the parameters to return a valid resource collection Id.
        /// </summary>
        /// <param name="subscriptionId">The subscription.</param>
        /// <param name="resourceGroupName">The resource group</param>
        /// <param name="resourceType">The resource type string in the format: '{providerName}/{typeName}/{nestedTypeName}'</param>
        /// <param name="extensionResourceType">The extension resource type string in the format: '{providerName}/{typeName}/{nestedTypeName}'</param>
        public static string GetResourceCollectionId(Guid? subscriptionId, string resourceGroupName, string resourceType, string extensionResourceType = null)
        {
            if (subscriptionId == null && !string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new InvalidOperationException("A resource group cannot be specified without a subscription.");
            }

            var resourceId = new StringBuilder();

            if (subscriptionId != null)
            {
                resourceId.AppendFormat("/subscriptions/{0}", Uri.EscapeDataString(subscriptionId.Value.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(resourceGroupName))
            {
                resourceId.AppendFormat("/resourceGroups/{0}", Uri.EscapeDataString(resourceGroupName));
            }

            if (!string.IsNullOrWhiteSpace(resourceType))
            {
                resourceId.Append(ResourceIdUtility.ProcessResourceTypeAndName(resourceType: resourceType, resourceName: null));
            }

            if (!string.IsNullOrWhiteSpace(extensionResourceType))
            {
                resourceId.Append(ResourceIdUtility.ProcessResourceTypeAndName(resourceType: extensionResourceType, resourceName: null));
            }

            return resourceId.ToString();
        }

        /// <summary>
        /// Gets the provider namespace from the resource id.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        public static string GetProviderNamespace(string resourceId)
        {
            return ResourceIdUtility.GetNextSegmentAfter(resourceId: resourceId, segmentName: Constants.Providers);
        }

        /// <summary>
        /// Gets the management group id from the resource id.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        public static string GetManagementGroupId(string resourceId)
        {
            return resourceId.StartsWithInsensitively(Constants.ManagementGroupIdPrefix)
                ? ResourceIdUtility.GetNextSegmentAfter(resourceId: resourceId, segmentName: Constants.ManagementGroups)
                : null;
        }

        /// <summary>
        /// Gets the subscription id from the resource id.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        public static string GetSubscriptionId(string resourceId)
        {
            return ResourceIdUtility.GetNextSegmentAfter(resourceId: resourceId, segmentName: Constants.Subscriptions);
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
        /// Gets the id of the resource group from the resource id.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        public static string GetResourceGroupId(string resourceId)
        {
            var subscriptionId = ResourceIdUtility.GetSubscriptionId(resourceId);
            if (string.IsNullOrWhiteSpace(subscriptionId))
            {
                return null;
            }

            Guid subscriptionGuid;
            if (!Guid.TryParse(subscriptionId, out subscriptionGuid))
            {
                return null;
            }

            var resourceGroupName = ResourceIdUtility.GetResourceGroupName(resourceId);
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                return null;
            }

            return ResourceIdUtility.GetResourceId(
                subscriptionId: subscriptionGuid,
                resourceGroupName: resourceGroupName,
                resourceType: null,
                resourceName: null);
        }

        /// <summary>
        /// Gets a resource type
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="includeProviderNamespace">Indicates if the provider namespace should be included in the resource name.</param>
        public static string GetResourceType(string resourceId, bool includeProviderNamespace = true)
        {
            return ResourceIdUtility.GetResourceTypeOrName(resourceId: resourceId, includeProviderNamespace: includeProviderNamespace, getResourceName: false);
        }

        /// <summary>
        /// Gets a resource name
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        public static string GetResourceName(string resourceId)
        {
            return ResourceIdUtility.GetResourceTypeOrName(resourceId: resourceId, getResourceName: true);
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
        /// Gets the extension provider namespace from the resource id.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        public static string GetExtensionProviderNamespace(string resourceId)
        {
            return ResourceIdUtility.IsExtensionResourceId(resourceId)
                ? ResourceIdUtility.GetNextSegmentAfter(resourceId: resourceId, segmentName: Constants.Providers, selectLastSegment: true)
                : null;
        }

        /// <summary>
        /// Gets a resource type
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="includeProviderNamespace">Indicates if the provider namespace should be included in the resource name.</param>
        public static string GetExtensionResourceType(string resourceId, bool includeProviderNamespace = true)
        {
            return ResourceIdUtility.GetExtensionResourceTypeOrName(resourceId: resourceId, includeProviderNamespace: includeProviderNamespace, getResourceName: false);
        }

        /// <summary>
        /// Gets a resource name
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        public static string GetExtensionResourceName(string resourceId)
        {
            return ResourceIdUtility.GetExtensionResourceTypeOrName(resourceId: resourceId, getResourceName: true);
        }

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
        /// Gets either a resource type or resource Id based on the value of the <paramref name="getResourceName"/> parameter.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="getResourceName">When set to true returns a resource name, otherwise a resource type.</param>
        /// <param name="includeProviderNamespace">Indicates if the provider namespace should be included in the resource name.</param>
        private static string GetExtensionResourceTypeOrName(string resourceId, bool getResourceName, bool includeProviderNamespace = true)
        {
            return ResourceIdUtility.IsExtensionResourceId(resourceId)
                ? ResourceIdUtility.GetResourceTypeOrName(resourceId: resourceId, getResourceName: getResourceName, includeProviderNamespace: includeProviderNamespace, useLastSegment: true)
                : null;
        }

        /// <summary>
        /// Checks whether a resource id contains an extension resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        private static bool IsExtensionResourceId(string resourceId)
        {
            return resourceId
                .SplitRemoveEmpty('/')
                .Count(segment => segment.EqualsInsensitively(Constants.Providers)) == 2;
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
        /// Processes a resource type string and a resource name string and 
        /// </summary>
        /// <param name="resourceType">The resource type string in the format: '{providerName}/{typeName}/{nestedTypeName}'</param>
        /// <param name="resourceName">The resource name in the format: '{resourceName}[/{nestedResourceName}]'</param>
        private static string ProcessResourceTypeAndName(string resourceType, string resourceName)
        {
            var resourceId = new StringBuilder();
            var resourceTypeTokens = resourceType.SplitRemoveEmpty('/');
            var resourceNameTokens = resourceName.CoalesceString().SplitRemoveEmpty('/');

            resourceId.AppendFormat("/providers/{0}", Uri.EscapeDataString(resourceTypeTokens.First()));

            for (int i = 1; i < resourceTypeTokens.Length; ++i)
            {
                resourceId.AppendFormat("/{0}", Uri.EscapeDataString(resourceTypeTokens[i]));

                if (resourceNameTokens.Length > i - 1)
                {
                    resourceId.AppendFormat("/{0}", Uri.EscapeDataString(resourceNameTokens[i - 1]));
                }
            }

            return resourceId.ToString();
        }

        /// <summary>
        /// Gets the provider from the resource type for the legacy resource id format.
        /// </summary>
        /// <param name="legacyResourceType">The resource type.</param>
        private static string GetProviderFromLegacyResourceTypeString(string legacyResourceType)
        {
            if (legacyResourceType == null)
            {
                return null;
            }

            int indexOfSlash = legacyResourceType.IndexOf('/');
            if (indexOfSlash < 0)
            {
                return string.Empty;
            }
            else
            {
                return legacyResourceType.Substring(0, indexOfSlash);
            }
        }

        /// <summary>
        /// Gets the resource type from the resource type for the legacy resource id format.
        /// </summary>
        /// <param name="legacyResourceType">The resource type.</param>
        private static string GetTypeFromLegacyResourceTypeString(string legacyResourceType)
        {
            if (legacyResourceType == null)
            {
                return null;
            }

            int lastIndexOfSlash = legacyResourceType.LastIndexOf('/');
            if (lastIndexOfSlash < 0)
            {
                return string.Empty;
            }
            else
            {
                return legacyResourceType.Substring(lastIndexOfSlash + 1);
            }
        }
    }
}

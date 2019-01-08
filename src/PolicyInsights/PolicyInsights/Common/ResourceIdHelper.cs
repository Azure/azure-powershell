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

namespace Microsoft.Azure.Commands.PolicyInsights.Common
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

    /// <summary>
    /// Helper methods related to resource ID manipulation.
    /// </summary>
    public class ResourceIdHelper
    {
        /// <summary>
        /// The providers segment in a resource ID.
        /// </summary>
        private const string ProvidersSegment = "providers";

        /// <summary>
        /// Gets the segments of a resource ID that occur before a given fully qualified resource type.
        /// E.g. "/subscriptions/{subId}" for an input of "/subscriptions/{subId}/Microsoft.PolicyInsights/remediations/foo".
        /// </summary>
        /// <param name="resourceId">The full resource ID.</param>
        /// <param name="fullyQualifiedResourceType">A fully qualified resource type (i.e. "Microsoft.PolicyInsights/remediations".</param>
        public static string GetRootScope(string resourceId, string fullyQualifiedResourceType)
        {
            string result = null;
            var typeIndex = resourceId.LastIndexOf($"{ResourceIdHelper.ProvidersSegment}/{fullyQualifiedResourceType}", StringComparison.OrdinalIgnoreCase);
            if (typeIndex != -1)
            {
                result = resourceId.Substring(0, typeIndex);
            }

            return result;
        }

        /// <summary>
        /// Gets the resource name of a specified type from a full resource ID.
        /// </summary>
        /// <param name="resourceId">The full resource ID.</param>
        public static string GetResourceName(string resourceId)
        {
            return resourceId.SplitRemoveEmpty('/').LastOrDefault();
        }

        /// <summary>
        /// Gets a subscription scope
        /// </summary>
        /// <param name="subscriptionId">The subscription ID.</param>
        public static string GetSubscriptionScope(string subscriptionId)
        {
            return $"/subscriptions/{subscriptionId}";
        }

        /// <summary>
        /// Gets a resource group scope.
        /// </summary>
        /// <param name="subscriptionId">The subscription ID.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        public static string GetResourceGroupScope(string subscriptionId, string resourceGroupName)
        {
            return $"{ResourceIdHelper.GetSubscriptionScope(subscriptionId)}/resourceGroups/{resourceGroupName}";
        }

        /// <summary>
        /// Gets a management group scope.
        /// </summary>
        /// <param name="managementGroupId">The management group ID.</param>
        public static string GetManagementGroupScope(string managementGroupId)
        {
            return $"/providers/Microsoft.Management/managementGroups/{managementGroupId}";
        }
    }
}

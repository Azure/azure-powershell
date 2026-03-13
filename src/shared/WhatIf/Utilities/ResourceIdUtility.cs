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

namespace Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Utilities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Utility class for splitting Azure resource IDs into scope and relative resource ID.
    /// </summary>
    public static class ResourceIdUtility
    {
        private static readonly string[] ScopePrefixes = new[]
        {
            "/subscriptions/",
            "/providers/Microsoft.Management/managementGroups/",
            "/tenants/"
        };

        /// <summary>
        /// Splits a fully qualified resource ID into scope and relative resource ID.
        /// </summary>
        /// <param name="resourceId">The fully qualified resource ID.</param>
        /// <returns>A tuple of (scope, relativeResourceId).</returns>
        /// <example>
        /// Input: "/subscriptions/sub-id/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm"
        /// Output: ("/subscriptions/sub-id/resourceGroups/rg", "Microsoft.Compute/virtualMachines/vm")
        /// </example>
        public static (string scope, string relativeResourceId) SplitResourceId(string resourceId)
        {
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                return (string.Empty, string.Empty);
            }

            // Find the scope prefix
            string scopePrefix = null;
            int scopePrefixIndex = -1;

            foreach (var prefix in ScopePrefixes)
            {
                int index = resourceId.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);
                if (index == 0)
                {
                    scopePrefix = prefix;
                    scopePrefixIndex = index;
                    break;
                }
            }

            if (scopePrefixIndex == -1)
            {
                // No recognized scope prefix, return the whole ID as relative
                return (string.Empty, resourceId);
            }

            // Find the "/providers/" segment after the scope
            int providersIndex = resourceId.IndexOf("/providers/", scopePrefixIndex + scopePrefix.Length, StringComparison.OrdinalIgnoreCase);

            if (providersIndex == -1)
            {
                // No providers segment, the whole thing is the scope
                return (resourceId, string.Empty);
            }

            string scope = resourceId.Substring(0, providersIndex);
            string relativeResourceId = resourceId.Substring(providersIndex + "/providers/".Length);

            return (scope, relativeResourceId);
        }

        /// <summary>
        /// Extracts the scope from a resource ID.
        /// </summary>
        public static string GetScope(string resourceId)
        {
            return SplitResourceId(resourceId).scope;
        }

        /// <summary>
        /// Extracts the relative resource ID from a resource ID.
        /// </summary>
        public static string GetRelativeResourceId(string resourceId)
        {
            return SplitResourceId(resourceId).relativeResourceId;
        }

        /// <summary>
        /// Gets the resource group name from a resource ID.
        /// </summary>
        public static string GetResourceGroupName(string resourceId)
        {
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                return null;
            }

            var parts = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < parts.Length - 1; i++)
            {
                if (parts[i].Equals("resourceGroups", StringComparison.OrdinalIgnoreCase))
                {
                    return parts[i + 1];
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the subscription ID from a resource ID.
        /// </summary>
        public static string GetSubscriptionId(string resourceId)
        {
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                return null;
            }

            var parts = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < parts.Length - 1; i++)
            {
                if (parts[i].Equals("subscriptions", StringComparison.OrdinalIgnoreCase))
                {
                    return parts[i + 1];
                }
            }

            return null;
        }
    }
}
